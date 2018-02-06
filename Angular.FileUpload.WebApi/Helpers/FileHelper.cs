using System;
using System.Net.Http;

namespace Angular.FileUpload.WebApi.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Make a unique file name that contains a date number.
        /// </summary>
        /// <param name="file">The HttpContent file from the requested files.</param>
        /// <returns>The string filename with the date number.</returns>
        public static string MakeUniqueFileName(HttpContent file)
        {
            string newFileName = string.Empty;

            if (file != null)
            {
                var thisFileName = file.Headers.ContentDisposition.FileName.Trim('\"');
                var extn = System.IO.Path.GetExtension(file.Headers.ContentDisposition.FileName.Trim('\"'));
                var fileName = System.IO.Path.GetFileNameWithoutExtension(file.Headers.ContentDisposition.FileName.Trim('\"'));
                var today = DateTime.Now.ToString("yyyyMMddHHmmss");
                newFileName = fileName + "_" + today + extn;
            }
            
            return newFileName;
        }
    }
}