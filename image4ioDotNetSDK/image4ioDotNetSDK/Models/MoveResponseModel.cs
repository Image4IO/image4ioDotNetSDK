using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class MoveResponseModel : BaseResponseModel
    {

        public MovedFile movedfile { get; set; }
        public class MovedFile
        {
            public string name { get; set; }
            public string status { get; set; }

        }
    }
}
