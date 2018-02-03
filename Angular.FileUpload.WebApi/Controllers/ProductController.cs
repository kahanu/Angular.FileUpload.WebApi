using Angular.FileUpload.WebApi.Models;
using Angular.FileUpload.WebApi.RequestResponse;
using System.Collections.Generic;
using System.Web.Http;

namespace Angular.FileUpload.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        public ProductResponse GetProducts()
        {
            var response = new ProductResponse();
            var products = new List<Product>()
            {
                new Product { Id = 1, Name = "Laptop", Price = 1299.00m },
                new Product { Id = 2, Name = "Cell Phone", Price = 899.00m },
                new Product { Id = 3, Name = "TV", Price = 649.00m },
                new Product { Id = 4, Name = "Broom", Price = 19.99m }
            };

            response.Success = true;
            response.Products = products;

            return response;
        }
    }
}
