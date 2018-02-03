using Angular.FileUpload.WebApi.Models;
using System.Collections.Generic;

namespace Angular.FileUpload.WebApi.RequestResponse
{
    public class ProductResponse : BaseResponse
    {
        public ProductResponse()
        {
            Products = new List<Product>();
        }

        public List<Product> Products { get; set; }
    }
}