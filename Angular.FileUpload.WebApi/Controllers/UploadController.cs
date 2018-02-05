using Angular.FileUpload.WebApi.RequestResponse;
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
    public class UploadController : ApiController
    {
        /// <summary>
        /// Post a single file with some additional form values.
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
                StringBuilder sb = new StringBuilder(); // Holds the response body

                // Read the form data and return an async task.
                //await Request.Content.ReadAsMultipartAsync(provider);
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

                var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');
                var extn = System.IO.Path.GetExtension(file1.Headers.ContentDisposition.FileName.Trim('\"'));
                var fileName = System.IO.Path.GetFileNameWithoutExtension(file1.Headers.ContentDisposition.FileName.Trim('\"'));
                var today = DateTime.Now.ToString("yyyyMMddHHmmss");
                var newFileName = fileName + "_" + today + extn;
                response.FormValues.Add("avatar", newFileName);


                response.Success = true;
                return response;
            }
            catch (System.Exception e)
            {
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                return new UploadResponse { Success = false, ErrorMessage = e.Message };
            }
        }
    }
    

}
