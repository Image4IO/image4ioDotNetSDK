using System.IO;
using Xunit;
using image4ioDotNetSDK;
using System;

namespace image4ioDotNetSDKTest
{
    public class TestsFixture : IDisposable
    {
        public Image4ioAPI Api { get; set; }

        public TestsFixture()
        {
            string apiKey = File.ReadAllText("APIKey.key");
            string apiSecret = File.ReadAllText("APISecret.key");
            Api = new Image4ioAPI(apiKey, apiSecret);
        }

        public void Dispose()
        {

        }
    }

    public class UnitTests : IClassFixture<TestsFixture>
    {
        readonly TestsFixture fixture;

        public UnitTests(TestsFixture _fixture)
        {
            this.fixture = _fixture;
        }

        [Fact]
        public void Upload()
        {
            var model = new image4ioDotNetSDK.Models.UploadRequestModel()
            {
                Path = "bitkilervehayvanlarbitkilervehayvanlar",
                Overwrite=true,
                UseFilename=true
            };

            FileStream stream = File.Open(@"Assets\a.png", FileMode.Open);
            model.Files.Add(new image4ioDotNetSDK.Models.UploadRequestModel.File
            {
                Data = stream,
                FileName = "a.png",
                Name = "a.png"
            });

            stream = File.Open(@"Assets\b.png", FileMode.Open);
            model.Files.Add(new image4ioDotNetSDK.Models.UploadRequestModel.File
            {
                Data = stream,
                FileName = "b.png",
                Name = "b.png"
            });

            var response = fixture.Api.Upload(model);

            Assert.True(response.IsSuccessfull);
        }

        [Fact]
        public void Get()
        {
            var model = new image4ioDotNetSDK.Models.GetRequestModel
            {
                Name = "/41856f35-e242-4031-aded-4b57f8c9ccb8.jpg"
            };

            var response = fixture.Api.Get(model);

            Assert.True(response.IsSuccessfull);
        }

        [Fact]
        public void Copy()
        {
            var model = new image4ioDotNetSDK.Models.CopyRequestModel
            {
                Source = "/ed8fa250-8f61-4ba4-9dc8-9a8b6ca4f2a1.jpg",
                Target_Path = "nisakjkkjk"
            };

            var response = fixture.Api.Copy(model);

            Assert.True(response.IsSuccessfull);
        }

        [Fact]
        public void CreateFolder()
        {
            var model = new image4ioDotNetSDK.Models.CreateFolderRequestModel
            {
                Path = "itucreggghnnthek"

            };

            var response = fixture.Api.CreateFolder(model);

            Assert.True(response.IsSuccessfull);
        }

        [Fact]
        public void Move()
        {
            var model = new image4ioDotNetSDK.Models.MoveRequestModel
            {
                Source = "/fa6e1cad-3998-44ce-b385-3495c096f7be.jpg",
                Target_Path = "nisakjkkjk"
            };

            var response = fixture.Api.Move(model);

            Assert.True(response.IsSuccessfull);
        }


        [Fact]
        public void Fetch()
        {
            var model = new image4ioDotNetSDK.Models.FetchRequestModel
            {
                From = "https://images.pexels.com/photos/853168/pexels-photo-853168.jpeg",
                // Target_path = ""

            };

            var response = fixture.Api.Fetch(model);

            Assert.True(response.IsSuccessfull);
        }

        [Fact]
        public void ListFolder()
        {
            var model = new image4ioDotNetSDK.Models.ListFolderRequestModel
            {
                Path = "/"
            };

            var response = fixture.Api.ListFolder(model);

            Assert.True(response.IsSuccessfull);
        }

        [Fact]
        public void Delete()
        {
            var model = new image4ioDotNetSDK.Models.DeleteRequestModel
            {
                name = "/ed8fa250-8f61-4ba4-9dc8-9a8b6ca4f2a1.jpg"
            };

            var response = fixture.Api.Delete(model);

            Assert.True(response.IsSuccessfull);
        }

        [Fact]
        public void DeleteFolder()
        {
            var model = new image4ioDotNetSDK.Models.DeleteFolderRequestModel
            {
                Path = "nisakjkkjk"
            };

            var response = fixture.Api.DeleteFolder(model);

            Assert.True(response.IsSuccessfull);
        }
    }
}
