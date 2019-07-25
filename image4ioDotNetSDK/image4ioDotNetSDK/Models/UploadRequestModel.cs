using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace image4ioDotNetSDK.Models
{
   public class UploadRequestModel
    {
        public UploadRequestModel()
        {
            Files = new List<Stream>();

        }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }


        [JsonProperty("files")]
        public List<Stream>  Files { get; set; }

      
    }
}
