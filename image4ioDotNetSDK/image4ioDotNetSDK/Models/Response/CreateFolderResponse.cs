using image4ioDotNetSDK.Models.Response;
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
        [JsonProperty(PropertyName = "folder")]
        public FolderResponse Folder { get; set; }

    }
}
