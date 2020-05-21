using System.IO;
using Xunit;
using image4ioDotNetSDK;
using System;
using System.Net.Http;
using Moq;
using System.Threading.Tasks;
using Moq.Protected;
using System.Net;
using System.Text;
using image4ioDotNetSDK.Models;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using image4ioDotNetSDK.Models.Request;
using image4ioDotNetSDK.Models.Response;

namespace image4ioDotNetSDKTest
{

    public class APIUnitTest : IDisposable
    {

        private Image4ioAPI SUT;

        private Mock<HttpMessageHandler> messageHandlerMock;

        private readonly string API_VERSION = "v1.0";
        private readonly string BASE_ADDRESS = "https://api.image4.io/";

        public APIUnitTest()
        {
            messageHandlerMock = new Mock<HttpMessageHandler>();
            SUT = new Image4ioAPI("apiKey", "apiSecret", messageHandlerMock.Object);
        }

        [Fact]
        public async Task SubscriptionAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x => 
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/subscription"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnNormalSubscriptionResponse()), Encoding.Default, "application/json")
               });

            //Act
            var result = await SUT.SubscriptionAsync();
            //Assert
            Assert.IsType<SubscriptionResponse>(result);
        }

        [Fact]
        public async Task UploadImageAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/uploadImage"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnNormalUploadImageResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.UploadImageAsync(MockRequests.ReturnUploadImageRequest());
            //Assert
            Assert.IsType<UploadImageResponse>(result);
        }

        [Fact]
        public async Task GetImagesAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/images"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnGetImageResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.GetImagesAsync(new ImagesRequest() { Names=new List<string>() });
            //Assert
            Assert.IsType<ImagesResponse>(result);
        }

        [Fact]
        public async Task CreateFolderAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/createFolder"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnCreateFolderResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.CreateFolderAsync(new CreateFolderRequest() {Path="/test" });
            //Assert
            Assert.IsType<CreateFolderResponse>(result);
        }

        [Fact]
        public async Task CopyImageAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/copyImage"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnCopyImageResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.CopyImageAsync(MockRequests.ReturnCopyImageRequest());
            //Assert
            Assert.IsType<CopyImageResponse>(result);
        }

        [Fact]
        public async Task MoveImageAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/moveImage"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnMoveImageResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.MoveImageAsync(MockRequests.ReturnMoveImageRequest());
            //Assert
            Assert.IsType<MoveImageResponse>(result);
        }

        [Fact]
        public async Task ListFolderAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/listFolder"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnListFolderResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.ListFolderAsync(MockRequests.ReturnListFolderRequest());
            //Assert
            Assert.IsType<ListFolderResponse>(result);
        }

        [Fact]
        public async Task DeleteFolderAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/deleteFolder"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnDeleteFolderResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.DeleteFolderAsync(new DeleteFolderRequest() { Path="/folderName/"});
            //Assert
            Assert.IsType<DeleteFolderResponse>(result);
        }

        [Fact]
        public async Task DeleteImageAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/deleteImage"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnDeleteImageResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.DeleteImageAsync(new DeleteImageRequest() { Name = "/folderName/img.png" });
            //Assert
            Assert.IsType<DeleteImageResponse>(result);
        }

        [Fact]
        public async Task FetchImageAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/fetchImage"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnFetchImageResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.FetchImageAsync(new FetchImageRequest() {From="http://example.com/img.png",TargetPath="/",UseFilename=true});
            //Assert
            Assert.IsType<FetchImageResponse>(result);
        }

        [Fact]
        public async Task StartUploadStreamAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/uploadStream"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnStartUploadStreamResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.StartUploadStreamAsync(new StartUploadStreamRequest() { Path = "/", FileName="filename.mp4" });
            //Assert
            Assert.IsType<StartUploadStreamResponse>(result);
        }

        [Fact]
        public async Task UploadStreamPartAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/uploadStream"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.Accepted,
               });
            //Act
            var result = await SUT.UploadStreamPartAsync(MockRequests.ReturnUploadStreamPartRequest());
            //Assert
            Assert.IsType<BaseResponse>(result);
        }

        [Fact]
        public async Task FinalizeStreamAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/finalizeStream"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnFinalizeStreamResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.FinalizeStreamAsync(new FinalizeStreamRequest() { FileName="/filename.mp4",Token="uploadToken"});
            //Assert
            Assert.IsType<FinalizeStreamResponse>(result);
        }

        [Fact]
        public async Task GetStreamAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/streams"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnGetStreamResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.GetStreamsAsync(new StreamsRequest() { Names = new List<string> { "/name-of-stream.mp4" } });
            //Assert
            Assert.IsType<StreamsResponse>(result);
        }

        [Fact]
        public async Task DeleteStreamAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/deleteStream"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnDeleteStreamResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.DeleteStreamAsync(new DeleteStreamRequest() { Name = "/4afdcb21ef149f06309573734e6d9515" } );
            //Assert
            Assert.IsType<DeleteStreamResponse>(result);
        }

        [Fact]
        public async Task FetchStreamAsync_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/fetchStream"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnFetchStreamResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.FetchStreamAsync(new FetchStreamRequest() { From = "http://example.com/img.png", TargetPath = "/", Filename = "name-of-stream.mp4"});
            //Assert
            Assert.IsType<FetchStreamResponse>(result);
        }

        public void Dispose()
        {
            messageHandlerMock = null;
            SUT = null;
        }
    }
}
