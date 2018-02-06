using Angular.FileUpload.WebApi.Models;

namespace Angular.FileUpload.WebApi.RequestResponse
{
    public class PersonRequest : BaseRequest
    {

    }

    public class PersonResponse : BaseResponse
    {
        public PersonResponse()
        {
            Person = new PersonInformation();
        }
        public PersonInformation Person { get; set; }
    }
}