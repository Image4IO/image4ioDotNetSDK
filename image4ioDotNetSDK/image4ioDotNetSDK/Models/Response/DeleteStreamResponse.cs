using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Response
{
    public class DeleteStreamResponse : BaseResponse
    {
        public DeletedStream DeleteStream { get; set; }

        public class DeletedStream
        {
            [JsonProperty(PropertyName = "source")]
            public string Source { get; set; }

            [JsonProperty(PropertyName = "url")]
            public string Url { get; set; }
        }
    }
}
