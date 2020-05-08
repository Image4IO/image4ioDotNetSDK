using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class DeleteImageResponse : BaseResponse
    {
        public File DeletedImage { get; set; }

        public class File
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "status")]
            public string Status { get; set; }
            [JsonProperty(PropertyName = "imagePath")]
            public string ImagePath { get; set; }
            [JsonProperty(PropertyName = "url")]
            public string Url { get; set; }
        }
    }

}
