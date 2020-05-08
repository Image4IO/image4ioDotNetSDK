using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class MoveImageRequest
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }
        [JsonProperty(PropertyName = "targetPath", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetPath { get; set; }
    }
}
