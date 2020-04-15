using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class CopyRequestModel
    {

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target_path", NullValueHandling = NullValueHandling.Ignore)]
        public string Target_Path { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("use_filename")]
        public bool UseFilename { get; set; }

        [JsonProperty("overwrite")]
        public bool Overwrite { get; set; }
    }


}
