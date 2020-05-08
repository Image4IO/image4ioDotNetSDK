using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Request
{
    public class UploadStreamPartRequest
    {
        public int PartId { get; set; }
        public string Token { get; set; }
        public string FileName { get; set; }
        public Stream StreamPart { get; set; }
    }
}
