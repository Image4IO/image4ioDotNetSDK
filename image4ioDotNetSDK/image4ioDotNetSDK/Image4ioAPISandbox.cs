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

        public CopyImageResponse CopyImage(CopyImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<CopyImageResponse> CopyImageAsync(CopyImageRequest model)
        {
            throw new NotImplementedException();
        }

        public CreateFolderResponse CreateFolder(CreateFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public DeleteFolderResponse DeleteFolder(DeleteFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteFolderResponse> DeleteFolderAsync(DeleteFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public DeleteImageResponse DeleteImage(DeleteImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteImageResponse> DeleteImageAsync(DeleteImageRequest model)
        {
            throw new NotImplementedException();
        }

        public DeleteStreamResponse DeleteStream(DeleteStreamRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteStreamResponse> DeleteStreamAsync(DeleteStreamRequest request)
        {
            throw new NotImplementedException();
        }

        public FetchImageResponse FetchImage(FetchImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<FetchImageResponse> FetchImageAsync(FetchImageRequest model)
        {
            throw new NotImplementedException();
        }

        public FetchStreamResponse FetchStream(FetchStreamRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<FetchStreamResponse> FetchStreamAsync(FetchStreamRequest model)
        {
            throw new NotImplementedException();
        }

        public FinalizeStreamResponse FinalizeStream(FinalizeStreamRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<FinalizeStreamResponse> FinalizeStreamAsync(FinalizeStreamRequest request)
        {
            throw new NotImplementedException();
        }

        public ImagesResponse GetImages(ImagesRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<ImagesResponse> GetImagesAsync(ImagesRequest model)
        {
            throw new NotImplementedException();
        }

        public StreamsResponse GetStreams(StreamsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<StreamsResponse> GetStreamsAsync(StreamsRequest request)
        {
            throw new NotImplementedException();
        }

        public ListFolderResponse ListFolder(ListFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<ListFolderResponse> ListFolderAsync(ListFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public MoveImageResponse MoveImage(MoveImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<MoveImageResponse> MoveImageAsync(MoveImageRequest model)
        {
            throw new NotImplementedException();
        }

        public StartUploadStreamResponse StartUploadStream(StartUploadStreamRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<StartUploadStreamResponse> StartUploadStreamAsync(StartUploadStreamRequest request)
        {
            throw new NotImplementedException();
        }

        public UploadImageResponse UploadImage(UploadImageRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<UploadImageResponse> UploadImageAsync(UploadImageRequest model)
        {
            throw new NotImplementedException();
        }

        public void UploadStreamPart(UploadStreamPartRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UploadStreamPartAsync(UploadStreamPartRequest request)
        {
            throw new NotImplementedException();
        }

        BaseResponse IImage4ioAPI.UploadStreamPart(UploadStreamPartRequest request)
        {
            throw new NotImplementedException();
        }

        Task<BaseResponse> IImage4ioAPI.UploadStreamPartAsync(UploadStreamPartRequest request)
        {
            throw new NotImplementedException();
        }
        /*
public UploadImageResponse Upload(UploadImageRequest model) => UploadAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<UploadImageResponse> UploadAsync(UploadImageRequest model)
{
var response = new UploadImageResponse
{
IsSuccessful = true,
uploadedFiles = new List<UploadImageResponse.UploadedFile>()
};

foreach (var image in model.Files)
{
response.uploadedFiles.Add(new UploadImageResponse.UploadedFile
{
  orginal_name = image.FileName,
  name = model.UseFilename ? model.Path + image.FileName : model.Path + Guid.NewGuid().ToString()
});
}

return response;
}


public ImagesResponse GetImages(ImagesRequest model) => GetImagesAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<ImagesResponse> GetImagesAsync(ImagesRequest model)
{
return new ImagesResponse
{
CreatedAtUTC = DateTime.UtcNow,
Format = "jpg",
Height = 600,
IsSuccessful = true,
Name = model.Name,
Size = 10000,
UpdatedAtUTC = DateTime.UtcNow,
UserGivenName = "image.jpg",
Width = 800
};
}


public CreateFolderResponse CreateFolder(CreateFolderRequest model) => CreateFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest model)
{
return new CreateFolderResponse
{
createdFolder = new CreateFolderResponse.CreatedFolder
{
  Name = model.Path.Split('/').Last(),
  Status = "created"
},
IsSuccessful = true
};
}


public CopyImageResponse CopyImage(CopyImageRequest model) => CopyImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<CopyImageResponse> CopyImageAsync(CopyImageRequest model)
{
return new CopyImageResponse
{
copiedfile = new CopyImageResponse.CopiedFile
{
  name = "image.jpg",
  status = "copied"
},
IsSuccessful = true
};
}


public MoveImageResponse MoveImage(MoveImageRequest model) => MoveImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<MoveImageResponse> MoveImageAsync(MoveImageRequest model)
{
return new MoveImageResponse
{
IsSuccessful = true,
movedfile = new MoveImageResponse.MovedFile
{
  Name = model.Source,
  Status = "copied"
}
};
}

public ListFolderResponse ListFolder(ListFolderRequest model) => ListFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<ListFolderResponse> ListFolderAsync(ListFolderRequest model)
{
return new ListFolderResponse
{
IsSuccessful = true,
files = new List<ListFolderResponse.File>
{
  new ListFolderResponse.File
  {
      CreatedAt=DateTime.Now,
      Folder="folder",
      Format="jpg",
      Height=600,
      Name="image.jpg",
      Orginal_name="imageorg.jpg",
      Size=10000,
      UpdatedAt=DateTime.UtcNow,
      Width=600
  }
},
folders = new List<ListFolderResponse.Folder>
{
  new ListFolderResponse.Folder
  {
      Name="folder2",
      Parent="/"
  }
}
};
}


public DeleteImageResponse DeleteImage(DeleteImageRequest model) => DeleteImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<DeleteImageResponse> DeleteImageAsync(DeleteImageRequest model)
{
return new DeleteImageResponse
{
IsSuccessful = true,
deletedfile = new DeleteImageResponse.DeletedFile
{
  name = "image.jpg",
  status = "copied"
}
};
}


public DeleteFolderResponse DeleteFolder(DeleteFolderRequest model) => DeleteFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<DeleteFolderResponse> DeleteFolderAsync(DeleteFolderRequest model)
{
return new DeleteFolderResponse
{
IsSuccessful = true,
deletedFolder = new DeleteFolderResponse.DeletedFolder
{
  name = model.Path.Split('/').Last(),
  status = "deleted"
}
};
}


public FetchImageResponse FetchImage(FetchImageRequest model) => FetchImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

public async Task<FetchImageResponse> FetchImageAsync(FetchImageRequest model)
{
return new FetchImageResponse
{
IsSuccessful = true,
fetchedfile = new FetchImageResponse.FetchedFile
{
  Name = model.Target_path + model.From.Split('/').Last(),
  Status = "fetched"
}
};
}
*/
    }
}
