using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
 public   class CreateFolderResponse : BaseResponse
    {

        public Folder CreatedFolder { get; set; }

        public class Folder
        {
            [JsonProperty(PropertyName = "path")]
            public string Path { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "status")]
            public string Status { get; set; }

        }

    }
}
