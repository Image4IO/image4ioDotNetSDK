using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class CopyRequestModel
    {

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target_path", NullValueHandling = NullValueHandling.Ignore)]
        public string Target_Path { get; set; }
    }


}
