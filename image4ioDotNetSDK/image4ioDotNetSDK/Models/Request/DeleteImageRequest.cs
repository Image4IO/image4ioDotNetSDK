using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
   public  class DeleteImageRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
