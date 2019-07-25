using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class DeleteResponseModel : BaseResponseModel
    {
        [JsonProperty("deletedFile", NullValueHandling = NullValueHandling.Ignore)]
        public DeletedFile DeletedFile { get; set; }
    }
    public class DeletedFile
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

}
