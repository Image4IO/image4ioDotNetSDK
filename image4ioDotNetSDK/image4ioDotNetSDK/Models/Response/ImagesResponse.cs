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
        public List<Image> Images { get; set; } = new List<Image>();

        public class Image
        {
            public string Name { get; set; }

            public string UserGivenName { get; set; }

            public Int64 Size { get; set; }

            public string Format { get; set; }

            public string Url { get; set; }

            public string ImagePath { get; set; }

            public int Width { get; set; }

            public int Height { get; set; }

            public DateTime CreatedAtUTC { get; set; }

            public DateTime UpdatedAtUTC { get; set; }
        }
    }
}
