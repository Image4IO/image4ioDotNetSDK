using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Response
{
    public class FileResponse 
    {
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "size", NullValueHandling = NullValueHandling.Ignore)]
        public string Size { get; set; }
        [JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "imagePath", NullValueHandling = NullValueHandling.Ignore)]
        public string ImagePath { get; set; }
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "lastModified", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastModified { get; set; }
        [JsonProperty(PropertyName = "directUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string DirectUrl { get; set; }
        [JsonProperty(PropertyName = "previewUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviewUrl { get; set; }
        [JsonProperty(PropertyName = "thumbnailUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ThumbnailUrl { get; set; }
        [JsonProperty(PropertyName = "hlsPlayback", NullValueHandling = NullValueHandling.Ignore)]
        public string HlsPlayback { get; set; }
        [JsonProperty(PropertyName = "readyToStream", NullValueHandling = NullValueHandling.Ignore)]
        public bool ReadyToStream { get; set; }
        [JsonProperty(PropertyName = "duration", NullValueHandling = NullValueHandling.Ignore)]
        public double Duration { get; set; }
    }
}
