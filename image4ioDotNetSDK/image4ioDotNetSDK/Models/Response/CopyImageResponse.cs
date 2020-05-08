using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class CopyImageResponse : BaseResponse
    {
        public File CopiedImage { get; set; }

        public class File
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
            [JsonProperty(PropertyName = "userGivenName")]
            public string UserGivenName { get; set; }
            [JsonProperty(PropertyName = "size")]
            public Int64 Size { get; set; }
            [JsonProperty(PropertyName = "format")]
            public string Format { get; set; }
            [JsonProperty(PropertyName = "url")]
            public string Url { get; set; }
            [JsonProperty(PropertyName = "imagePath")]
            public string ImagePath { get; set; }
            [JsonProperty(PropertyName = "width")]
            public int Width { get; set; }
            [JsonProperty(PropertyName = "height")]
            public int Height { get; set; }
            [JsonProperty(PropertyName = "createdAtUTC")]
            public DateTime CreatedAtUTC { get; set; }
            [JsonProperty(PropertyName = "updatedAtUTC")]
            public DateTime UpdatedAtUTC { get; set; }
            [JsonProperty(PropertyName = "status")]
            public string Status { get; set; }
        }

    }
}
