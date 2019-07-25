using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class BaseResponseModel
    {
        [JsonIgnore]
        public bool IsSuccessfull { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }


        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }


        [JsonProperty("statusCode", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusCode { get; set; }
    }
}
