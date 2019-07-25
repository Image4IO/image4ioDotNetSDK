using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class MoveResponseModel : BaseResponseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
