using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class FetchResponseModel : BaseResponseModel
    {
        public class FetchedFile
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string name { get; set; }
        }

        public class RootObject
        {
            [JsonProperty("fetched_file", NullValueHandling = NullValueHandling.Ignore)]
            public FetchedFile Fetched_File { get; set; }
        }
    }
}
