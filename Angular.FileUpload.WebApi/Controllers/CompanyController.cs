using Angular.FileUpload.WebApi.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public PostCompanyResponse PostCompany(PostCompanyRequest request)
        {
            string message = "Could not save the company.";
            var response = new PostCompanyResponse();

            try
            {
                if (request == null)
                {
                    return new PostCompanyResponse { Success = false, ErrorMessage = message };
                }

                

                // You would actually do a service call or some database update here.
                response.Company.Id = Guid.NewGuid();
                response.Company.CompanyName = request.CompanyToSave.CompanyName;
                response.Company.City = request.CompanyToSave.City;
                response.Company.State = request.CompanyToSave.State;
                response.Company.PostalCode = request.CompanyToSave.PostalCode;

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
