﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
    public class ListFolderRequest
    {
        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("continuationToken", NullValueHandling = NullValueHandling.Ignore)]
        public string ContinuationToken { get; set; }
    }
}
