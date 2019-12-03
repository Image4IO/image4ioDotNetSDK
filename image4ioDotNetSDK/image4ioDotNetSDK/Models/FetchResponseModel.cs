using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class FetchResponseModel : BaseResponseModel
    {

        public FetchedFile fetchedfile { get; set; }
        public class FetchedFile
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }

    }
}


