using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
   public  class DeleteRequestModel
    {
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
