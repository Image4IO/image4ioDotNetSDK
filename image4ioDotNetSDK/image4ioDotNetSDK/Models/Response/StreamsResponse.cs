using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Response
{
    public class StreamResponse : BaseResponse
    {
        public List<Stream> Streams { get; set; } = new List<Stream>();

        public class Stream
        {
            [JsonProperty(PropertyName = "folder")]
            public string Folder { get; set; }

            [JsonProperty(PropertyName = "orginalName")]
            public string OrginalName { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "size")]
            public long Size { get; set; }

            [JsonProperty(PropertyName = "format")]
            public string Format { get; set; }

            [JsonProperty(PropertyName = "width")]
            public int Width { get; set; }

            [JsonProperty(PropertyName = "height")]
            public int Height { get; set; }

            [JsonProperty(PropertyName = "createdAt")]
            public DateTime CreatedAtUTC { get; set; }

            [JsonProperty(PropertyName = "updatedAt")]
            public DateTime UpdatedAtUTC { get; set; }

            [JsonProperty(PropertyName = "thumbnailUrl")]
            public string ThumbnailUrl { get; set; }

            [JsonProperty(PropertyName = "previewUrl")]
            public string PreviewUrl { get; set; }

            [JsonProperty(PropertyName = "hlsPlayback")]
            public string HlsPlayback { get; set; }

            [JsonProperty(PropertyName = "duration")]
            public double Duration { get; set; }

            [JsonProperty(PropertyName = "readyToStream")]
            public bool ReadyToStream { get; set; }
        }
    }
}
