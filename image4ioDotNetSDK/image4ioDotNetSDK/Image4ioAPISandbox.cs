using image4ioDotNetSDK.Models;
using image4ioDotNetSDK.Models.Request;
using image4ioDotNetSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK
{
    public class Image4ioAPISandbox : IImage4ioAPI
    {
        public Image4ioAPISandbox(string APIKey, string APISecret)
        {
        }

        public Task<CopyImageResponse> CopyImage(CopyImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<CreateFolderResponse> CreateFolder(CreateFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteFolderResponse> DeleteFolder(DeleteFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteImageResponse> DeleteImage(DeleteImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteStreamResponse> DeleteStream(DeleteStreamRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<FetchImageResponse> FetchImage(FetchImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<FetchStreamResponse> FetchStream(FetchStreamRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<GetImageResponse> GetImage(GetImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<GetStreamResponse> GetStream(GetStreamRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ListFolderResponse> ListFolder(ListFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<MoveImageResponse> MoveImage(MoveImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<PurgeResponse> Purge()
        {
            throw new NotImplementedException();
        }

        public Task<PurgeResponse> Purge(PurgeRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<UploadImageResponse> UploadImage(UploadImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<UploadStreamResponse> UploadStream(UploadStreamRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
