using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models.Request
{
    public class FinalizeStreamRequest
    {
        public string FileName { get; set; }
        public string Token { get; set; }
    }
}
