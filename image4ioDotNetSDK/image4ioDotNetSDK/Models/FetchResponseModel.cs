﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class FetchResponseModel : BaseResponseModel
    {

        public FetchedFile fetchedfile { get; set; }
        public class FetchedFile
        {
            public string name { get; set; }
            public string status { get; set; }
        }

    }
}


