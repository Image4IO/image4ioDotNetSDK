using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class DeleteImageResponse : BaseResponse
    {
        public DeleteImage DeletedImage { get; set; }

        public class DeleteImage
        {
            [JsonProperty(PropertyName = "source")]
            public string Source { get; set; }
            [JsonProperty(PropertyName = "url")]
            public string Url { get; set; }
        }
    }

}
