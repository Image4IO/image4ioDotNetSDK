using image4ioDotNetSDK.Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class UploadImageResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "uploadedImage")]
        public ImageResponse UploadedImage { get; set; }

    }
}
