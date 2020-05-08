using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Response
{
    public class StartUploadStreamResponse : BaseResponse
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Token { get; set; }
    }
}
