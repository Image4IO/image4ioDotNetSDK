using image4ioDotNetSDK.Models;
using image4ioDotNetSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDKTest
{
    public class MockResponses
    {
        /*
        public static SubscriptionResponse ReturnNormalSubscriptionResponse()
        {
            return new SubscriptionResponse(){
                Cloudname= "cloudname",
                Status= "Active",
                Subscription= "Startup",
                SubscriptionRenewalPeriod= "Monthly",
                SubscriptionStartDate= DateTime.UtcNow,
                SubscriptionEndDate= DateTime.UtcNow,
                Success= true,
                Errors= new List<string>(),
                Messages= new List<string>()
            };
        }

        public static UploadImageResponse ReturnNormalUploadImageResponse()
        {
            return new UploadImageResponse()
            {
                UploadedFiles = new List<UploadImageResponse.File>
                {
                   new UploadImageResponse.File
                   {
                        Name= "/name-of-the-image.png",
                        UserGivenName= "name-of-the-image.png",
                        Size= 388,
                        Format= "png",
                        Url= "https=//cdn.image4.io/cloudname/name-of-the-image.png",
                        ImagePath= "/cloudname/name-of-the-image.png",
                        Width= 72,
                        Height= 72,
                        CreatedAtUTC= DateTime.UtcNow,
                        UpdatedAtUTC= DateTime.UtcNow,
                        Status= "Uploaded"
                    }
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static ImageResponse ReturnGetImageResponse()
        {
            return new ImageResponse()
            {
                Image = new ImageResponse.ImageFile
                {
                    Name = "/name-of-the-image.png",
                    UserGivenName = "name-of-the-image.png",
                    Size = 388,
                    Format = "png",
                    Url = "https=//cdn.image4.io/cloudname/name-of-the-image.png",
                    ImagePath = "/cloudname/name-of-the-image.png",
                    Width = 72,
                    Height = 72,
                    CreatedAtUTC = DateTime.UtcNow,
                    UpdatedAtUTC = DateTime.UtcNow
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static CreateFolderResponse ReturnCreateFolderResponse()
        {
            return new CreateFolderResponse()
            {
                CreatedFolder = new CreateFolderResponse.Folder
                {
                    Name = "test",
                    Path = "/test/",
                    Status = "Created"
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static CopyImageResponse ReturnCopyImageResponse()
        {
            return new CopyImageResponse()
            {
                CopiedImage = new CopyImageResponse.File
                {
                    Name = "/name-of-the-image.png",
                    UserGivenName = "name-of-the-image.png",
                    Size = 388,
                    Format = "png",
                    Url = "https=//cdn.image4.io/cloudname/name-of-the-image.png",
                    ImagePath = "/cloudname/name-of-the-image.png",
                    Width = 72,
                    Height = 72,
                    CreatedAtUTC = DateTime.UtcNow,
                    UpdatedAtUTC = DateTime.UtcNow,
                    Status = "Copied"
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static MoveImageResponse ReturnMoveImageResponse()
        {
            return new MoveImageResponse()
            {
                MovedImage = new MoveImageResponse.File
                {
                    Name = "/name-of-the-image.png",
                    UserGivenName = "name-of-the-image.png",
                    Size = 388,
                    Format = "png",
                    Url = "https=//cdn.image4.io/cloudname/name-of-the-image.png",
                    ImagePath = "/cloudname/name-of-the-image.png",
                    Width = 72,
                    Height = 72,
                    CreatedAtUTC = DateTime.UtcNow,
                    UpdatedAtUTC = DateTime.UtcNow,
                    Status = "Moved"
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static ListFolderResponse ReturnListFolderResponse()
        {
            return new ListFolderResponse()
            {
                Folders = new List<ListFolderResponse.Folder>
                {
                    new ListFolderResponse.Folder()
                    {
                        Name = "folderName",
                        Path = "/folderName/",
                        Parent = "/"
                    }
                },
                Images = new List<ListFolderResponse.Image>()
                {
                    new ListFolderResponse.Image()
                    {
                        Folder = "/",
                        OrginalName = "name-of-the-file.jpg",
                        Name = "/name-of-the-file.jpg",
                        Size = 397612,
                        Format = "jpg",
                        Width = 1180,
                        Height = 874,
                        CreatedAtUTC = DateTime.UtcNow,
                        UpdatedAtUTC = DateTime.UtcNow,
                        ImagePath = "/cloudname/name-of-the-file.jpg",
                        Url = "https=//cdn.image4.io/cloudname/name-of-the-file.jpg"
                    }
                },
                Streams = new List<ListFolderResponse.Stream>()
                {
                    new ListFolderResponse.Stream()
                    {
                        Folder= "/",
                        OrginalName= "name-of-the-file.mp4",
                        Name= "/streamId",
                        Size= 4489511,
                        Format= "mp4",
                        Width= 1920,
                        Height= 1080,
                        CreatedAtUTC= DateTime.UtcNow,
                        UpdatedAtUTC= DateTime.UtcNow,
                        ThumbnailUrl= "https=//watch.image4.io/cloudname/streamId/thumbnails/thumbnail.jpg",
                        PreviewUrl= "https=//watch.image4.io/cloudname/streamId",
                        HlsPlayback= "https=//cdn.image4.io/cloudname/streamId/manifest/video.m3u8",
                        Duration= 2.0,
                        ReadyToStream= true
                    }
                },
                ContinuationToken = "token_string",
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static DeleteImageResponse ReturnDeleteImageResponse()
        {
            return new DeleteImageResponse()
            {
                DeletedImage = new DeleteImageResponse.File
                {
                    ImagePath = "/cloudname/name-of-the-file.jpg",
                    Url = "https=//cdn.image4.io/cloudname/name-of-the-file.jpg",
                    Name = "/name-of-the-file.jpg",
                    Status = "Deleted",
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static DeleteFolderResponse ReturnDeleteFolderResponse()
        {
            return new DeleteFolderResponse()
            {
                DeletedFolder = new DeleteFolderResponse.Folder()
                {
                    Name = "/folderName",
                    Status = "Deleted",
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }
        public static FetchImageResponse ReturnFetchImageResponse()
        {
            return new FetchImageResponse()
            {
                FetchedImage = new FetchImageResponse.File
                {
                    Name = "/name-of-the-image.png",
                    UserGivenName = "name-of-the-image.png",
                    Size = 388,
                    Format = "png",
                    Url = "https=//cdn.image4.io/cloudname/name-of-the-image.png",
                    ImagePath = "/cloudname/name-of-the-image.png",
                    Width = 72,
                    Height = 72,
                    CreatedAtUTC = DateTime.UtcNow,
                    UpdatedAtUTC = DateTime.UtcNow,
                    Status = "Fetched"
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static StartUploadStreamResponse ReturnStartUploadStreamResponse()
        {
            return new StartUploadStreamResponse()
            {
                FileName = "/folderPath/name.mp4",
                Path = "/folderPath",
                Token = "Upload_token",
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static UploadStreamResponse ReturnFinalizeStreamResponse()
        {
            return new UploadStreamResponse
            {
                UploadedStream = new UploadStreamResponse.File
                {
                    UserGivenName = "name-of-the-stream.mp4",
                    Name = "/4afdcb21ef149f06309573734e6d9515",
                    Format = "mp4",
                    Width = 1280,
                    Height = 720,
                    CreatedAtUTC = DateTime.UtcNow,
                    UpdatedAtUTC = DateTime.UtcNow,
                    ThumbnailUrl = "https=//watch.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515/thumbnails/thumbnail.jpg",
                    PreviewUrl = "https=//watch.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515",
                    HlsPlayback = "https=//cdn.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515/manifest/video.m3u8",
                    Duration = 10.0,
                    ReadyToStream = false
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static StreamResponse ReturnGetStreamResponse()
        {
            return new StreamResponse
            {
                Stream = new StreamResponse.StreamFile
                {
                    OrginalName = "name-of-the-stream.mp4",
                    Name = "/4afdcb21ef149f06309573734e6d9515",
                    Format = "mp4",
                    Width = 1280,
                    Height = 720,
                    CreatedAtUTC = DateTime.UtcNow,
                    UpdatedAtUTC = DateTime.UtcNow,
                    ThumbnailUrl = "https=//watch.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515/thumbnails/thumbnail.jpg",
                    PreviewUrl = "https=//watch.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515",
                    HlsPlayback = "https=//cdn.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515/manifest/video.m3u8",
                    Duration = 10.0,
                    ReadyToStream = false,
                    Folder = "/",
                    Size = 123456
                }
            };
        }

        public static DeleteStreamResponse ReturnDeleteStreamResponse()
        {
            return new DeleteStreamResponse
            {
                DeletedStream = new DeleteStreamResponse.File
                {
                    Name = "/4afdcb21ef149f06309573734e6d9515",
                    Status = "Deleted"
                }
            };
        }

        public static FetchStreamResponse ReturnFetchStreamResponse()
        {
            return new FetchStreamResponse
            {
                FetchedStream = new FetchStreamResponse.File
                {
                    UserGivenName = "name-of-the-stream.mp4",
                    Name = "/4afdcb21ef149f06309573734e6d9515",
                    Format = "mp4",
                    Width = 1280,
                    Height = 720,
                    CreatedAtUTC = DateTime.UtcNow,
                    UpdatedAtUTC = DateTime.UtcNow,
                    ThumbnailUrl = "https=//watch.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515/thumbnails/thumbnail.jpg",
                    PreviewUrl = "https=//watch.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515",
                    HlsPlayback = "https=//cdn.image4.io/cloudname/4afdcb21ef149f06309573734e6d9515/manifest/video.m3u8",
                    Duration = 10.0,
                    ReadyToStream = false,
                }
            };
        }*/
    }
}
