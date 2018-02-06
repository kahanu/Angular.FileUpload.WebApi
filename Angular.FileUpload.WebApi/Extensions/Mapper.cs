using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Linq;

namespace Angular.FileUpload.WebApi.Extensions
{
    public static class Mapper
    {
        /// <summary>
        /// This maps a name/value collection like the multipart/form-data request
        /// to a complex object of your choice.
        /// </summary>
        /// <typeparam name="T">Your complex object.</typeparam>
        /// <param name="collection">The name/value collection (multipart/form-data).</param>
        /// <returns>Your populated complex object.</returns>
        public static T ToObject<T>(this NameValueCollection collection) where T : new() 
        {
            var formDictionary = collection.AllKeys
                     .Where(p => collection[p] != "null")
                     .ToDictionary(p => p, p => collection[p]);

            string json = JsonConvert.SerializeObject(formDictionary);
            var type = JsonConvert.DeserializeObject<T>(json);

            return type;
        }
    }
}