using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class FetchImageRequest
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("targetPath")]
        public string TargetPath { get; set; }
        [JsonProperty("useFilename")]
        public bool UseFilename { get; set; }
    }
}
