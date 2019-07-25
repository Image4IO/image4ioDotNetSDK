using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class CopyResponseModel : BaseResponseModel
    {

        [JsonProperty("name")]
        public string Name { get; set; }


    }
}
