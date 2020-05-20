using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
   public class FetchStreamRequest
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("targetPath")]
        public string TargetPath { get; set; }
        [JsonProperty("filename")]
        public string Filename { get; set; }
    }
}
