using Angular.FileUpload.WebApi.Models;
using System.Collections.Generic;

namespace Angular.FileUpload.WebApi.RequestResponse
{
    public class CompanyRequest : BaseRequest
    {
    }

    public class PostCompanyRequest : BaseRequest
    {
        
    }

    public class PostCompanyResponse : BaseResponse
    {
        public PostCompanyResponse()
        {
            Company = new CompanyInformation();
            FileList = new List<FileInformation>();
        }

        public CompanyInformation Company { get; set; }
        public List<FileInformation> FileList { get; set; }
    }

  

}