using image4ioDotNetSDK.Models;
using image4ioDotNetSDK.Models.Request;
using image4ioDotNetSDK.Models.Response;
using System.Threading.Tasks;

namespace image4ioDotNetSDK
{
    public interface IImage4ioAPI
    {
        UploadImageResponse UploadImage(UploadImageRequest model);
        Task<UploadImageResponse> UploadImageAsync(UploadImageRequest model);
        ImagesResponse GetImages(ImagesRequest model);
        Task<ImagesResponse> GetImagesAsync(ImagesRequest model);
        CreateFolderResponse CreateFolder(CreateFolderRequest model);
        Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest model);
        CopyImageResponse CopyImage(CopyImageRequest model);
        Task<CopyImageResponse> CopyImageAsync(CopyImageRequest model);
        MoveImageResponse MoveImage(MoveImageRequest model);
        Task<MoveImageResponse> MoveImageAsync(MoveImageRequest model);
        ListFolderResponse ListFolder(ListFolderRequest model);
        Task<ListFolderResponse> ListFolderAsync(ListFolderRequest model);
        DeleteImageResponse DeleteImage(DeleteImageRequest model);
        Task<DeleteImageResponse> DeleteImageAsync(DeleteImageRequest model);
        DeleteFolderResponse DeleteFolder(DeleteFolderRequest model);
        Task<DeleteFolderResponse> DeleteFolderAsync(DeleteFolderRequest model);
        FetchImageResponse FetchImage(FetchImageRequest model);
        Task<FetchImageResponse> FetchImageAsync(FetchImageRequest model);

        #region Stream
        StartUploadStreamResponse StartUploadStream(StartUploadStreamRequest request);
        Task<StartUploadStreamResponse> StartUploadStreamAsync(StartUploadStreamRequest request);
        BaseResponse UploadStreamPart(UploadStreamPartRequest request);
        Task<BaseResponse> UploadStreamPartAsync(UploadStreamPartRequest request);
        FinalizeStreamResponse FinalizeStream(FinalizeStreamRequest request);
        Task<FinalizeStreamResponse> FinalizeStreamAsync(FinalizeStreamRequest request);
        StreamsResponse GetStreams(StreamsRequest request);
        Task<StreamsResponse> GetStreamsAsync(StreamsRequest request);
        DeleteStreamResponse DeleteStream(DeleteStreamRequest request);
        Task<DeleteStreamResponse> DeleteStreamAsync(DeleteStreamRequest request);
        FetchStreamResponse FetchStream(FetchStreamRequest model);
        Task<FetchStreamResponse> FetchStreamAsync(FetchStreamRequest model);
        #endregion
    }
}
