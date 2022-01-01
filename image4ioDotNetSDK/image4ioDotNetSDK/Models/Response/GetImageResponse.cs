using Newtonsoft.Json;
using image4ioDotNetSDK.Models.Response;

namespace image4ioDotNetSDK.Models
{
   public class GetImageResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "image")]
        public ImageResponse Image { get; set; }
        
    }
}
