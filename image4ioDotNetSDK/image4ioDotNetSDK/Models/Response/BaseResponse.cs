using Newtonsoft.Json;
using System.Collections.Generic;

namespace image4ioDotNetSDK.Models
{
    public class BaseResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; } = new List<string>();

        [JsonProperty("messages")]
        public List<string> Messages { get; set; } = new List<string>();

    }
}
