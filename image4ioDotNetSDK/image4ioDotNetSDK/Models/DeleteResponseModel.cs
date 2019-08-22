using Newtonsoft.Json;

namespace image4ioDotNetSDK.Models
{
    public class DeleteResponseModel : BaseResponseModel
    {
        public DeletedFile deletedfile { get; set; }

        public class DeletedFile
        {
            public string name { get; set; }
            public string status { get; set; }
        }
    }

}
