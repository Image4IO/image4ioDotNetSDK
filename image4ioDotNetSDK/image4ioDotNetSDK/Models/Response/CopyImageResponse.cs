using image4ioDotNetSDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class CopyImageResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "image")]
        public ImageResponse Image { get; set; }

    }
}
