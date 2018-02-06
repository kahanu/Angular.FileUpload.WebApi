using Angular.FileUpload.WebApi.Extensions;
using Angular.FileUpload.WebApi.Models;
using Angular.FileUpload.WebApi.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Angular.FileUpload.WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        /// <summary>
        /// This method has a different way of capturing files being uploaded and
        /// additional data.  The data comes in as a normal Http request body,
        /// and the file(s) are captured inside the method.
        /// </summary>
        /// <param name="request">The Company Information class.</param>
        /// <returns>PostCompanyResponse - The Company Information class.</returns>
        public async Task<PostCompanyResponse> PostCompany()
        {
            string message = "Could not save the company.";
            var response = new PostCompanyResponse();

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                // Get the multipart form-data request which includes the files and the additional data.
                var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

                // Do something with the files.
                FileInformation fileInfo = null;
                foreach (var file in provider.Files)
                {
                    fileInfo = new FileInformation();
                    fileInfo.FileName = Helpers.FileHelper.MakeUniqueFileName(file);
                    fileInfo.FileSize = Convert.ToInt32(file.Headers.ContentLength);
                    fileInfo.ContentType = file.Headers.ContentType.MediaType;

                    response.FileList.Add(fileInfo);
                }

                // Do something with the additional data included in the request.
                var company = provider.FormData.ToObject<CompanyInformation>();
                company.Id = Guid.NewGuid();

                // TODO: you would normally be saving the data to a data store at this point 
                // and creating a response that you will send back to the client.

                response.Company = company;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new PostCompanyResponse { Success = false, ErrorMessage = message };
            }
        }
    }
}
