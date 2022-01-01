using image4ioDotNetSDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
   public class ListFolderResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "folders")]
        public List<FolderResponse> Folders { get; set; } = new List<FolderResponse>();
        [JsonProperty(PropertyName = "files")]
        public List<FileResponse> Files { get; set; } = new List<FileResponse>();
        [JsonProperty(PropertyName = "continuationToken")]
        public string ContinuationToken { get; set; }

    }
}
      