using Angular.FileUpload.WebApi.Extensions;
using Angular.FileUpload.WebApi.Helpers;
using Angular.FileUpload.WebApi.Models;
using Angular.FileUpload.WebApi.RequestResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Angular.FileUpload.WebApi.Controllers
{
    public class PersonController : ApiController
    {
        /// <summary>
        /// Post a single file with some additional form values where the files and
        /// the form data are collected inside the method using the Request context.
        /// </summary>
        /// <returns></returns>
        public async Task<UploadResponse> PostFile()
        {
            var response = new UploadResponse();

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            
            try
            {
                // Read the form data and return an async task.
                var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

                // This illustrates how to get the form data.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        response.FormValues.Add(key, val);
                    }
                }
                
                //access form data  
                NameValueCollection formData = provider.FormData;
                //access files  
                IList<HttpContent> files = provider.Files;
                HttpContent file1 = files[0];

                //var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');
                //var extn = System.IO.Path.GetExtension(file1.Headers.ContentDisposition.FileName.Trim('\"'));
                //var fileName = System.IO.Path.GetFileNameWithoutExtension(file1.Headers.ContentDisposition.FileName.Trim('\"'));
                //var today = DateTime.Now.ToString("yyyyMMddHHmmss");
                //var newFileName = fileName + "_" + today + extn;

                var newFileName = FileHelper.MakeUniqueFileName(file1);

                response.FormValues.Add("avatar", newFileName);


                response.Success = true;
                return response;
            }
            catch (Exception e)
            {
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                return new UploadResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// This option takes the form data and deserializes it from the form data name/value collection,
        /// and converts it into your strongly-typed C# object.
        /// </summary>
        /// <returns>PersonResponse</returns>
        [HttpPost]
        public async Task<PersonResponse> SavePerson()
        {
            var response = new PersonResponse();

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                // Get the multipart form-data request which includes the files and the additional data.
                var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

                // Do something with the additional data included in the request.
                var person = provider.FormData.ToObject<PersonInformation>();

                //access form data  
                NameValueCollection formData = provider.FormData;
                //access files  
                IList<HttpContent> files = provider.Files;
                HttpContent file1 = files[0];

                string newFileName = FileHelper.MakeUniqueFileName(file1);

                person.Avatar = newFileName;
               
                // TODO: you would normally be saving the data to a data store at this point 
                // and creating a response that you will send back to the client.

                response.Person = person;

                response.Success = true;
                return response;
            }
            catch (Exception e)
            {
                return new PersonResponse { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
