using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Request
{
    public class UploadStreamRequest
    {
        public bool UseFilename { get; set; }

        public bool Overwrite { get; set; }

        public string Path { get; set; }

        public File Stream { get; set; }

        public class File
        {
            public Stream Data { get; set; }
            public string FileName { get; set; }
            public string Extension { get; set; }
        }
    }
}
