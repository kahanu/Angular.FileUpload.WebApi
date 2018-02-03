using Angular.FileUpload.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular.FileUpload.WebApi.RequestResponse
{
    public class CompanyRequest : BaseRequest
    {
    }

    public class GetCompanyResponse : BaseResponse
    {
        public GetCompanyResponse()
        {
            Company = new CompanyInformation();
        }

        public CompanyInformation Company { get; set; }

    }

    public class GetCompanyListResponse : BaseResponse
    {
        public GetCompanyListResponse()
        {
            CompanyList = new List<CompanyInformation>();
        }

        public List<CompanyInformation> CompanyList { get; set; }
    }

    public class PostCompanyRequest : BaseRequest
    {
        public CompanyInformation CompanyToSave { get; set; }
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