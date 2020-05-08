using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Request
{
    public class StreamsRequest
    {
        [JsonProperty("names")]
        public List<string> Names { get; set; }
    }
}
