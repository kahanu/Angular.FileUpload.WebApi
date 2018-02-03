using System.Collections.Generic;

namespace Angular.FileUpload.WebApi.RequestResponse
{
    public class UploadResponse : BaseResponse
    {
        public UploadResponse()
        {
            FormValues = new Dictionary<string, string>();
        }

        public Dictionary<string, string> FormValues { get; set; }
    }
}