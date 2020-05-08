using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
    public class DeleteFolderResponse : BaseResponse
    {
        public Folder DeletedFolder { get; set; }

        public class Folder
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "status")]
            public string Status { get; set; }
        }

    }
}