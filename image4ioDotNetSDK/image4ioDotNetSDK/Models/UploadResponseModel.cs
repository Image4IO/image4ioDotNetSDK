using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class UploadResponseModel :BaseResponseModel
    {
        public List<UploadedFile> uploadedFiles { get; set; }

        
        public class UploadedFile
        {
            [JsonProperty("original_name", NullValueHandling = NullValueHandling.Ignore)]
            public string orginal_name { get; set; }

            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string name { get; set; }


            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            public string Status { get; set; }
        }




    }
}
