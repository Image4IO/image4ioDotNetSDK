using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
   public class ListFolderResponse : BaseResponse
    {
        public List<Folder> Folders { get; set; } = new List<Folder>();

        public List<Image> Images { get; set; } = new List<Image>();

        public List<Stream> Streams { get; set; } = new List<Stream>();

        public string ContinuationToken { get; set; }

        public class Folder
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "path")]
            public string Path { get; set; }

            [JsonProperty(PropertyName = "parent")]
            public string Parent { get; set; }

        }

        public class Image
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
            public string ImagePath { get; set; }
            public string Url { get; set; }
        }

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

            [JsonProperty(PropertyName = "directUrl")]
            public string DirectUrl { get; set; }

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
      