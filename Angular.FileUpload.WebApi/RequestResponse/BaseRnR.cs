namespace Angular.FileUpload.WebApi.RequestResponse
{
    public class BaseRequest
    {

    }

    public class BaseResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
