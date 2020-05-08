using System.IO;
using Xunit;
using image4ioDotNetSDK;
using System;

namespace image4ioDotNetSDKTest
{
    public class APISandboxUnitTestFixture : IDisposable
    {
        public Image4ioAPISandbox Api { get; set; }

        public APISandboxUnitTestFixture()
        {
            Api = new Image4ioAPISandbox("", "");
        }

        public void Dispose()
        {

        }
    }

    public class APISandboxUnitTest : IClassFixture<APISandboxUnitTestFixture>
    {
        /*
        readonly APISandboxUnitTestFixture fixture;

        public APISandboxUnitTest(APISandboxUnitTestFixture _fixture)
        {
            this.fixture = _fixture;
        }

        [Fact]
        public void OrderedTest()
        {
            CreateFolder();
            Upload();
            Get();
            Copy();
            Move();
            Fetch();
            Delete();
            ListFolder();
            DeleteFolder();
        }

        public string uploadedFileName;
        public string movedFileName;


        [Fact]
        public void Upload()
        {
            var model = new image4ioDotNetSDK.Models.UploadImageRequest()
            {
                Path = "playlistfolder",
                Overwrite = true,
                UseFilename = false
            };

            FileStream stream = File.Open(@"Assets\a.png", FileMode.Open);
            model.Files.Add(new image4ioDotNetSDK.Models.UploadImageRequest.File
            {
                Data = stream,
                FileName = "a.png"
            });

            stream = File.Open(@"Assets\b.png", FileMode.Open);
            model.Files.Add(new image4ioDotNetSDK.Models.UploadImageRequest.File
            {
                Data = stream,
                FileName = "b.png"
            });
            var response = fixture.Api.Upload(model);
            uploadedFileName = response.uploadedFiles[0].name;

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void Get()
        {
            var model = new image4ioDotNetSDK.Models.ImagesRequest
            {
                Name = uploadedFileName
            };

            var response = fixture.Api.GetImages(model);

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void Copy()
        {
            var model = new image4ioDotNetSDK.Models.CopyImageRequest
            {
                Source = uploadedFileName,
                Target_Path = "playlistfolder"
            };

            var response = fixture.Api.CopyImage(model);

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void CreateFolder()
        {
            var model = new image4ioDotNetSDK.Models.CreateFolderRequest
            {
                Path = "playlistfolder"
            };

            var response = fixture.Api.CreateFolder(model);

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void Move()
        {
            var model = new image4ioDotNetSDK.Models.MoveImageRequest
            {
                Source = uploadedFileName,
                Target_Path = "playlistfolder"
            };

            var response = fixture.Api.MoveImage(model);
            movedFileName = response.movedfile.Name;

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void Fetch()
        {
            var model = new image4ioDotNetSDK.Models.FetchImageRequest
            {
                From = "https://images.pexels.com/photos/853168/pexels-photo-853168.jpeg",
                Target_path = "playlistfolder"
            };

            var response = fixture.Api.FetchImage(model);

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void ListFolder()
        {
            var model = new image4ioDotNetSDK.Models.ListFolderRequest
            {
                Path = "playlistfolder"
            };

            var response = fixture.Api.ListFolder(model);

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void Delete()
        {
            var model = new image4ioDotNetSDK.Models.DeleteImageRequest
            {
                Name = movedFileName
            };

            var response = fixture.Api.DeleteImage(model);

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void DeleteFolder()
        {
            var model = new image4ioDotNetSDK.Models.DeleteFolderRequest
            {
                Path = "playlistfolder"
            };

            var response = fixture.Api.DeleteFolder(model);

            Assert.True(response.IsSuccessful);
        }
        */
    }
}
