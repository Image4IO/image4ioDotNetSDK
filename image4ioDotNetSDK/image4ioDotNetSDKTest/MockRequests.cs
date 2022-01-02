using image4ioDotNetSDK.Models;
using image4ioDotNetSDK.Models.Request;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace image4ioDotNetSDKTest
{
    public class MockRequests
    {
        
        public static UploadImageRequest ReturnUploadImageRequest()
        {
            return new UploadImageRequest()
            {
                Image= new UploadImageRequest.File
                {
                    Data=new MemoryStream()
                },
                Overwrite = true,
                UseFilename = true,
                Path = "/"
            };
        }
        public static UploadStreamRequest ReturnUploadStreamRequest()
        {
            return new UploadStreamRequest()
            {
                Stream = new UploadStreamRequest.File
                {
                    Data = new MemoryStream()
                },
                Overwrite = true,
                UseFilename = true,
                Path = "/"
            };
        }
        public static CopyImageRequest ReturnCopyImageRequest()
        {
            return new CopyImageRequest()
            {
                Name = "newName",
                Source = "/folderName/sourcename.png",
                TargetPath = "/targetFolder",
                UseFilename = true
            };
        }

        public static MoveImageRequest ReturnMoveImageRequest()
        {
            return new MoveImageRequest()
            {
                Source = "/folderName/sourcename.png",
                TargetPath = "/targetFolder",
            };
        }

        public static ListFolderRequest ReturnListFolderRequest()
        {
            return new ListFolderRequest()
            {
                ContinuationToken = "cont_token",
                Path = "/folderName"
            };
        }

    }
}
