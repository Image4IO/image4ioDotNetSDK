using System;
using System.IO;
using Xunit;
using image4ioDotNetSDK;

namespace image4ioDotNetSDKTest
{
    public class UnitTest1
    {
        readonly Image4ioAPI api;
        string Name;

        string original_name;



        public UnitTest1()
        {
          //  string apiKey = File.ReadAllText("API.key");
         //   string apiSecret = File.ReadAllText("API.secret");
            api = new Image4ioAPI("CflQP+9CzjxNBCUgaQizAw==", "v4WQKFyOof4EuQWI9bG5RdgQk+bv7xt7s+7t0burdeo=");
        }

        [Fact]
        public void Upload()
        {

            FileStream stream = File.Open(@"Assets\a.png", FileMode.Open);

            var model = new image4ioDotNetSDK.Models.UploadRequestModel()
            {
                Path = "bitkilervehayvanlarbitkilervehayvanlar"

            };
            model.Files.Add(stream);
            stream = File.Open(@"Assets\b.png", FileMode.Open);
            model.Files.Add(stream);



            var response = api.Upload(model);


            Assert.True(response.IsSuccessfull);


        }

        [Fact]
        public void Get()
        {
            var model = new image4ioDotNetSDK.Models.GetRequestModel
            {
                Name = "/41856f35-e242-4031-aded-4b57f8c9ccb8.jpg"
            };

            var response = api.Get(model);


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

            var response = api.Copy(model);


            Assert.True(response.IsSuccessfull);


        }

        [Fact]
        public void CreateFolder()
        {
            var model = new image4ioDotNetSDK.Models.CreateFolderRequestModel
            {
                Path = "itucreggghnnthek"
               
            };

            var response = api.CreateFolder(model);

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

            var response = api.Move(model);

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
            var response = api.Fetch(model);
            Assert.True(response.IsSuccessfull);
        }


        [Fact]
        public void ListFolder()
        {
            var model = new image4ioDotNetSDK.Models.ListFolderRequestModel
            {
                Path = "/"
            };

            var response = api.ListFolder(model);


            Assert.True(response.IsSuccessfull);

        }



        [Fact]
        public void Delete()
        {
            var model = new image4ioDotNetSDK.Models.DeleteRequestModel
            {
                name = "/ed8fa250-8f61-4ba4-9dc8-9a8b6ca4f2a1.jpg"
            };

            var response = api.Delete(model);

            Assert.True(response.IsSuccessfull);


        }




        [Fact]
        public void DeleteFolder()
        {
            var model = new image4ioDotNetSDK.Models.DeleteFolderRequestModel
            {
                Path = "nisakjkkjk"
            };

            var response = api.DeleteFolder(model);

            Assert.True(response.IsSuccessfull);


        }




    }
}
