﻿using System.Collections.Generic;
using System.IO;

namespace image4ioDotNetSDK.Models
{
    public class UploadImageRequest
    {
        public bool UseFilename { get; set; }

        public bool Overwrite { get; set; }

        public string Path { get; set; }

        public File Image { get; set; }

        public class File
        {
            public Stream Data { get; set; }
            public string FileName { get; set; }
            public string Extension { get; set; }
        }

    }
}
