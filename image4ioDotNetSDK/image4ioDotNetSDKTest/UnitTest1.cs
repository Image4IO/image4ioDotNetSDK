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
            string apiKey = File.ReadAllText("API.key");
            string apiSecret = File.ReadAllText("API.secret");
            api = new Image4ioAPI(apiKey, apiSecret);
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
        public void Copy()
        {
            var model = new image4ioDotNetSDK.Models.CopyRequestModel
            {
                Source = "e64622a7-35d2-4f0d-a794-21916c623710.jpg",
                Target_Path = "bitkilervehayvanlarbitkilervehayvanlar"
            };

            var response = api.Copy(model);


            Assert.True(response.IsSuccessfull);


        }


        [Fact]
        public void Move()
        {
            var model = new image4ioDotNetSDK.Models.MoveRequestModel
            {
                Source = "bitkilervehayvanlar/19dd4d7d-cce6-4e43-aeed-1c25e058951c.jpg",
                Target_Path = "bitkilervehayvanlarbitkilervehayvanlar"
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
                Path = "bitkilervehayvanlar"
            };

            var response = api.ListFolder(model);


            Assert.True(response.IsSuccessfull);

        }



        [Fact]
        public void Delete()
        {
            var model = new image4ioDotNetSDK.Models.DeleteRequestModel
            {
                name = "bitkilervehayvanlarbitkilervehayvanlar/9d32ada2-1a5e-472b-9d0c-c3ab62dd006a.jpg"
            };

            var response = api.Delete(model);

            Assert.True(response.IsSuccessfull);


        }



    }
}
