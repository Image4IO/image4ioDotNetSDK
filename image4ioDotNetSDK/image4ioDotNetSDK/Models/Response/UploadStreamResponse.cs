using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Response
{
    public class UploadStreamResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "uploadedStream")]
        public StreamResponse UploadedStream { get; set; }

    }
}
