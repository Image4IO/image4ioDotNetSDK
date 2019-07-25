using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
   public class FetchRequestModel
    {
        [JsonProperty("from")]
        public  string From { get; set; }

        [JsonProperty("target_path")]
        public string Target_path { get; set; }
    }
}
