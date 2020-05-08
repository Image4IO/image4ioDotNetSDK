using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Response
{
    public class FinalizeStreamResponse : BaseResponse
    {
        public File UploadedStream { get; set; }

        public class File
        {
            public string Name { get; set; }

            public string UserGivenName { get; set; }

            public string Format { get; set; }

            public string ThumbnailUrl { get; set; }

            public bool ReadyToStream { get; set; }

            public string PreviewUrl { get; set; }

            public string HlsPlayback { get; set; }

            public double Duration { get; set; }

            public int Width { get; set; }

            public int Height { get; set; }

            public DateTime CreatedAtUTC { get; set; }

            public DateTime UpdatedAtUTC { get; set; }
        }
    }
}
