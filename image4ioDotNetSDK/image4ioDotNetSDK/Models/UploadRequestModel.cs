using System.Collections.Generic;
using System.IO;

namespace image4ioDotNetSDK.Models
{
    public class UploadRequestModel
    {
        public UploadRequestModel()
        {
            Files = new List<File>();
        }
        
        public bool UseFilename { get; set; }

        public bool Overwrite { get; set; }

        public string Path { get; set; }

        public List<File> Files { get; set; }

        public class File
        {
            public Stream Data { get; set; }
            public string Name { get; set; }
            public string FileName { get; set; }
        }

    }
}
