using image4ioDotNetSDK.Models;
using System.Threading.Tasks;

namespace image4ioDotNetSDK
{
    public interface IImage4ioAPI
    {
        UploadResponseModel Upload(UploadRequestModel model);
        Task<UploadResponseModel> UploadAsync(UploadRequestModel model);
        GetResponseModel Get(GetRequestModel model);
        Task<GetResponseModel> GetAsync(GetRequestModel model);
        CreateFolderResponseModel CreateFolder(CreateFolderRequestModel model);
        Task<CreateFolderResponseModel> CreateFolderAsync(CreateFolderRequestModel model);
        CopyResponseModel Copy(CopyRequestModel model);
        Task<CopyResponseModel> CopyAsync(CopyRequestModel model);
        MoveResponseModel Move(MoveRequestModel model);
        Task<MoveResponseModel> MoveAsync(MoveRequestModel model);
        ListFolderResponseModel ListFolder(ListFolderRequestModel model);
        Task<ListFolderResponseModel> ListFolderAsync(ListFolderRequestModel model);
        DeleteResponseModel Delete(DeleteRequestModel model);
        Task<DeleteResponseModel> DeleteAsync(DeleteRequestModel model);
        DeleteFolderResponseModel DeleteFolder(DeleteFolderRequestModel model);
        Task<DeleteFolderResponseModel> DeleteFolderAsync(DeleteFolderRequestModel model);
        FetchResponseModel Fetch(FetchRequestModel model);
        Task<FetchResponseModel> FetchAsync(FetchRequestModel model);
    }
}
