using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class BaseResponseModel
    {
        [JsonIgnore]
        public bool IsSuccessfull { get; set; }

    }
}
