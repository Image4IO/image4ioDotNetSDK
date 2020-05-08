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
        public File DeletedStream { get; set; }

        public class File
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "status")]
            public string Status { get; set; }
        }
    }
}
