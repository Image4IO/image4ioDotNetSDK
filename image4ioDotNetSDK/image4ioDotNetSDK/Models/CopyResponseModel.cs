using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class CopyResponseModel : BaseResponseModel
    {
        public CopiedFile copiedfile { get; set; }
        public class CopiedFile
        {
            public string name { get; set; }
            public string status { get; set; }
        }


    }
}
