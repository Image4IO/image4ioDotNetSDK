﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
    public class CreateFolderRequestModel
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
