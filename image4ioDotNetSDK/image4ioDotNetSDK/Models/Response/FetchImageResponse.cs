using image4ioDotNetSDK.Models.Response;

namespace image4ioDotNetSDK.Models
{
    public class FetchImageResponse : BaseResponse
    {
        public ImageResponse FetchedImage { get; set; }
    }
}


