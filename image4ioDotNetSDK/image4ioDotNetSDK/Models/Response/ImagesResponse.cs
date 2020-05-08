using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
   public class ImagesResponse : BaseResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("userGivenName")]
        public string UserGivenName { get; set; }

        [JsonProperty("size")]
        public Int64 Size { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("createdAtUTC")]
        public DateTime CreatedAtUTC { get; set; }

        [JsonProperty("updatedAtUTC")]
        public DateTime UpdatedAtUTC { get; set; }
    }
}
