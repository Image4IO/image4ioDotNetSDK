using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Request
{
    public class StreamRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
