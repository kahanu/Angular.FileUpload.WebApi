using System;

namespace Angular.FileUpload.WebApi.Models
{
    public class CompanyInformation
    {
        public CompanyInformation()
        {
            Id = Guid.Empty;
        }

        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}