using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
 public   class CreateFolderResponseModel : BaseResponseModel
    {

        public CreatedFolder createdFolder { get; set; }

        public class CreatedFolder
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }

    }
}
