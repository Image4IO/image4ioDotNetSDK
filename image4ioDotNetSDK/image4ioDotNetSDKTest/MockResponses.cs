using image4ioDotNetSDK.Models;
using image4ioDotNetSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDKTest
{
    public class MockResponses
    {

        public static SubscriptionResponse ReturnNormalSubscriptionResponse()
        {
            return new SubscriptionResponse()
            {
                Cloudname = "cloudname",
                Status = "Active",
                Subscription = "Startup",
                SubscriptionRenewalPeriod = "Monthly",
                SubscriptionStartDate = DateTime.UtcNow,
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>(),
                CDNUsage = new SubscriptionResponse.CDNUsageData
                {
                    LimitInGB = 10,
                    UsageInGB = 1.23
                },
                CreditUsageIn30Days = new SubscriptionResponse.CreditUsage
                {
                    Limit = 15,
                    Usage = 3.2
                },
                StorageUsage = new SubscriptionResponse.StorageUsageData
                {
                    AssetCount = 200,
                    UsageInGB = 1.4,
                    LimitInGB = 10
                },
                TransformationUsage = new SubscriptionResponse.TransformationData
                {
                    Count = 1250
                }
            };
        }

        public static ImageResponse ReturnImageResponse()
        {
            return new ImageResponse
            {
                Name = "/name-of-the-image.png",
                Size = "388",
                Format = "png",
                Url = "https=//cdn.image4.io/cloudname/name-of-the-image.png",
                ImagePath = "/cloudname/name-of-the-image.png",
                Width = 72,
                Height = 72,
                LastModified = DateTime.Now
            };
        }

        public static StreamResponse ReturnStreamResponse()
        {
            return new StreamResponse
            {
                Name = "/streamId",
                Size = "4489511",
                Format = "mp4",
                Width = 1920,
                Height = 1080,
                DirectUrl = "",
                ThumbnailUrl = "https=//watch.image4.io/cloudname/streamId/thumbnails/thumbnail.jpg",
                PreviewUrl = "https=//watch.image4.io/cloudname/streamId",
                HlsPlayback = "https=//cdn.image4.io/cloudname/streamId/manifest/video.m3u8",
                Duration = 2.0,
                ReadyToStream = true,
                LastModified = DateTime.UtcNow
            };
        }

        public static FolderResponse ReturnFolderResponse()
        {
            return new FolderResponse
            {
                Name = "test",
                Path = "/test/",
                Parent = "/"
            };
        }

        public static object ReturnImageSignUrlResponse()
        {
            return new
            {
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>(),
                Url = "https://mockresponse.com/image",
                Path = ""
            };
        }
        
        public static UploadImageResponse ReturnNormalUploadImageResponse()
        {
            return new UploadImageResponse()
            {
                UploadedImage = ReturnImageResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static object ReturnStreamSignUrlResponse()
        {
            return new
            {
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>(),
                Url = "https://mockresponse.com/stream",
                Path = ""
            };
        }

        public static UploadStreamResponse ReturnNormalUploadStreamResponse()
        {
            return new UploadStreamResponse()
            {
                UploadedStream = ReturnStreamResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static GetImageResponse ReturnGetImageResponse()
        {
            return new GetImageResponse()
            {
                Image = ReturnImageResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static GetStreamResponse ReturnGetStreamResponse()
        {
            return new GetStreamResponse()
            {
                Stream = ReturnStreamResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static CreateFolderResponse ReturnCreateFolderResponse()
        {
            return new CreateFolderResponse()
            {
                Folder = ReturnFolderResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static CopyImageResponse ReturnCopyImageResponse()
        {
            return new CopyImageResponse()
            {
                Image= ReturnImageResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static MoveImageResponse ReturnMoveImageResponse()
        {
            return new MoveImageResponse()
            {
                Image= ReturnImageResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static ListFolderResponse ReturnListFolderResponse()
        {
            return new ListFolderResponse()
            {
                Folders = new List<FolderResponse>
                {
                    ReturnFolderResponse()
                },
                Files=new List<FileResponse>
                {
                    new FileResponse
                    {
                        Name = "/name-of-the-image.png",
                        Size = "388",
                        Format = "png",
                        Url = "https=//cdn.image4.io/cloudname/name-of-the-image.png",
                        ImagePath = "/cloudname/name-of-the-image.png",
                        Width = 72,
                        Height = 72,
                        LastModified = DateTime.Now
                    },
                    new FileResponse
                    {
                        Name = "/streamId",
                        Size = "4489511",
                        Format = "mp4",
                        Width = 1920,
                        Height = 1080,
                        DirectUrl = "",
                        ThumbnailUrl = "https=//watch.image4.io/cloudname/streamId/thumbnails/thumbnail.jpg",
                        PreviewUrl = "https=//watch.image4.io/cloudname/streamId",
                        HlsPlayback = "https=//cdn.image4.io/cloudname/streamId/manifest/video.m3u8",
                        Duration = 2.0,
                        ReadyToStream = true,
                        LastModified = DateTime.UtcNow
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
                DeletedImage=new DeleteImageResponse.DeleteImage
                {
                    Source="/test.png",
                    Url= "https=//cdn.image4.io/cloudname/test.png"
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
                DeletedFolder=new DeleteFolderResponse.Folder
                {
                    Path="/test/"
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
                FetchedImage=ReturnImageResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static DeleteStreamResponse ReturnDeleteStreamResponse()
        {
            return new DeleteStreamResponse
            {
                DeleteStream=new DeleteStreamResponse.DeletedStream
                {
                    Source = "/test.mp4",
                    Url = "https=//cdn.image4.io/cloudname/test.mp4"
                },
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }

        public static FetchStreamResponse ReturnFetchStreamResponse()
        {
            return new FetchStreamResponse
            {
                FetchedStream= ReturnStreamResponse(),
                Success = true,
                Errors = new List<string>(),
                Messages = new List<string>()
            };
        }
    }
}
