using image4ioDotNetSDK.Models;
using image4ioDotNetSDK.Models.Request;
using image4ioDotNetSDK.Models.Response;
using System.Threading.Tasks;

namespace image4ioDotNetSDK
{
    public interface IImage4ioAPI
    {
        Task<UploadImageResponse> UploadImage(UploadImageRequest model);
        Task<UploadStreamResponse> UploadStream(UploadStreamRequest request);
        Task<GetImageResponse> GetImage(GetImageRequest model);
        Task<GetStreamResponse> GetStream(GetStreamRequest request);
        Task<CreateFolderResponse> CreateFolder(CreateFolderRequest model);
        Task<CopyImageResponse> CopyImage(CopyImageRequest model);
        Task<MoveImageResponse> MoveImage(MoveImageRequest model);
        Task<ListFolderResponse> ListFolder(ListFolderRequest model);
        Task<DeleteStreamResponse> DeleteStream(DeleteStreamRequest request);
        Task<DeleteImageResponse> DeleteImage(DeleteImageRequest model);
        Task<DeleteFolderResponse> DeleteFolder(DeleteFolderRequest model);
        Task<FetchImageResponse> FetchImage(FetchImageRequest model);
        Task<FetchStreamResponse> FetchStream(FetchStreamRequest model);
        Task<PurgeResponse> Purge(PurgeRequest model);
    }
}
