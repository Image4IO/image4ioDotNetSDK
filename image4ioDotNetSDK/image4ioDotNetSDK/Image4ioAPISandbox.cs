using image4ioDotNetSDK.Models;
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

        public UploadResponseModel Upload(UploadRequestModel model) => UploadAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UploadResponseModel> UploadAsync(UploadRequestModel model)
        {
            var response = new UploadResponseModel
            {
                IsSuccessfull = true,
                uploadedFiles = new List<UploadResponseModel.UploadedFile>()
            };

            foreach (var image in model.Files)
            {
                response.uploadedFiles.Add(new UploadResponseModel.UploadedFile
                {
                    orginal_name = image.FileName,
                    name = model.UseFilename ? model.Path + image.FileName : model.Path + Guid.NewGuid().ToString()
                });
            }

            return response;
        }


        public GetResponseModel Get(GetRequestModel model) => GetAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetResponseModel> GetAsync(GetRequestModel model)
        {
            return new GetResponseModel
            {
                CreatedAtUTC = DateTime.UtcNow,
                Format = "jpg",
                Height = 600,
                IsSuccessfull = true,
                Name = model.Name,
                Size = 10000,
                UpdatedAtUTC = DateTime.UtcNow,
                UserGivenName = "image.jpg",
                Width = 800
            };
        }


        public CreateFolderResponseModel CreateFolder(CreateFolderRequestModel model) => CreateFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateFolderResponseModel> CreateFolderAsync(CreateFolderRequestModel model)
        {
            return new CreateFolderResponseModel
            {
                createdFolder = new CreateFolderResponseModel.CreatedFolder
                {
                    Name = model.Path.Split('/').Last(),
                    Status = "created"
                },
                IsSuccessfull = true
            };
        }


        public CopyResponseModel Copy(CopyRequestModel model) => CopyAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CopyResponseModel> CopyAsync(CopyRequestModel model)
        {
            return new CopyResponseModel
            {
                copiedfile = new CopyResponseModel.CopiedFile
                {
                    name = "image.jpg",
                    status = "copied"
                },
                IsSuccessfull = true
            };
        }


        public MoveResponseModel Move(MoveRequestModel model) => MoveAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<MoveResponseModel> MoveAsync(MoveRequestModel model)
        {
            return new MoveResponseModel
            {
                IsSuccessfull = true,
                movedfile = new MoveResponseModel.MovedFile
                {
                    Name = model.Source,
                    Status = "copied"
                }
            };
        }

        public ListFolderResponseModel ListFolder(ListFolderRequestModel model) => ListFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListFolderResponseModel> ListFolderAsync(ListFolderRequestModel model)
        {
            return new ListFolderResponseModel
            {
                IsSuccessfull = true,
                files = new List<ListFolderResponseModel.File>
                {
                    new ListFolderResponseModel.File
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
                folders = new List<ListFolderResponseModel.Folder>
                {
                    new ListFolderResponseModel.Folder
                    {
                        Name="folder2",
                        Parent="/"
                    }
                }
            };
        }


        public DeleteResponseModel Delete(DeleteRequestModel model) => DeleteAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<DeleteResponseModel> DeleteAsync(DeleteRequestModel model)
        {
            return new DeleteResponseModel
            {
                IsSuccessfull = true,
                deletedfile = new DeleteResponseModel.DeletedFile
                {
                    name = "image.jpg",
                    status = "copied"
                }
            };
        }


        public DeleteFolderResponseModel DeleteFolder(DeleteFolderRequestModel model) => DeleteFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<DeleteFolderResponseModel> DeleteFolderAsync(DeleteFolderRequestModel model)
        {
            return new DeleteFolderResponseModel
            {
                IsSuccessfull = true,
                deletedFolder = new DeleteFolderResponseModel.DeletedFolder
                {
                    name = model.Path.Split('/').Last(),
                    status = "deleted"
                }
            };
        }


        public FetchResponseModel Fetch(FetchRequestModel model) => FetchAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FetchResponseModel> FetchAsync(FetchRequestModel model)
        {
            return new FetchResponseModel
            {
                IsSuccessfull = true,
                fetchedfile = new FetchResponseModel.FetchedFile
                {
                    Name = model.Target_path + model.From.Split('/').Last(),
                    Status = "fetched"
                }
            };
        }
    }
}
