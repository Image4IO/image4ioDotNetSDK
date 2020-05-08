using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class CopyImageRequest
    {

        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("targetPath",NullValueHandling=NullValueHandling.Ignore)]
        public string TargetPath { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("useFilename")]
        public bool UseFilename { get; set; }
        [JsonProperty("overwrite")]
        public bool Overwrite { get; set; }
    }


}
