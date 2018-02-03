using Angular.FileUpload.WebApi.RequestResponse;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Angular.FileUpload.WebApi.Controllers
{
    public class UploadController : ApiController
    {
        /// <summary>
        /// Post a single file with some additional form values.
        /// </summary>
        /// <returns></returns>
        public async Task<UploadResponse> PostFile()
        {
            var response = new UploadResponse();

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                StringBuilder sb = new StringBuilder(); // Holds the response body

                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the form data.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        response.FormValues.Add(key, val);
                    }
                }

                // This illustrates how to get the file names for uploaded files.
                foreach (var file in provider.FileData)
                {
                    response.FormValues.Add("avatar", file.Headers.ContentDisposition.FileName.Replace("\"", ""));
                }

                response.Success = true;
                return response;
            }
            catch (System.Exception e)
            {
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                return new UploadResponse { Success = false, ErrorMessage = e.Message };
            }
        }
    }
    

}
