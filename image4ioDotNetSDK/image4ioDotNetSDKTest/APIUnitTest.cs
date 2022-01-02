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

        private static Image4ioAPI SUT;

        private static Mock<HttpMessageHandler> messageHandlerMock;

        private readonly string API_VERSION = "v2.0";
        private readonly string BASE_ADDRESS = "https://api.image4.io/";

        public APIUnitTest()
        {
            if (messageHandlerMock == null)
            {
                messageHandlerMock = new Mock<HttpMessageHandler>();
            }
            if (SUT == null)
            {
                SUT = new Image4ioAPI("apiKey", "apiSecret", messageHandlerMock.Object);
            }
        }

        public void Dispose()
        {
        }
        
        [Fact]
        public async Task Subscription_NoErrorOccured_ReturnsResponse()
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
           var result = await SUT.Subscription();
           //Assert
           Assert.IsType<SubscriptionResponse>(result);
        }

        [Fact]
        public async Task UploadImage_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/getSignUrl"), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnImageSignUrlResponse()), Encoding.Default, "application/json")
                });

            messageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri.ToString() == "https://mockresponse.com/image"), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StreamContent(new MemoryStream())
                });

            messageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/image"), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnNormalUploadImageResponse()), Encoding.Default, "application/json")
                });
            //Act
            var result = await SUT.UploadImage(MockRequests.ReturnUploadImageRequest());
            //Assert
            Assert.IsType<UploadImageResponse>(result);
        }

        [Fact]
        public async Task UploadStream_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/getSignUrl"), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnStreamSignUrlResponse()), Encoding.Default, "application/json")
                });

            messageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri.ToString() == "https://mockresponse.com/stream"), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });

            messageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/stream"), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnNormalUploadStreamResponse()), Encoding.Default, "application/json")
                });
            //Act
            var result = await SUT.UploadStream(MockRequests.ReturnUploadStreamRequest());
            //Assert
            Assert.IsType<UploadStreamResponse>(result);
        }

        [Fact]
        public async Task GetImage_NoErrorOccured_ReturnsResponse()
        {
           //Arrange
           messageHandlerMock.Protected()
              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                  x.RequestUri.ToString().StartsWith( BASE_ADDRESS + API_VERSION + "/image")), ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(new HttpResponseMessage
              {
                  StatusCode = HttpStatusCode.OK,
                  Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnGetImageResponse()), Encoding.Default, "application/json")
              });
           //Act
           var result = await SUT.GetImage(new GetImageRequest());
           //Assert
           Assert.IsType<GetImageResponse>(result);
        }

        [Fact]
        public async Task GetStream_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString().StartsWith(BASE_ADDRESS + API_VERSION + "/stream")), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnGetImageResponse()), Encoding.Default, "application/json")
               });
            //Act
            var result = await SUT.GetStream(new GetStreamRequest());
            //Assert
            Assert.IsType<GetStreamResponse>(result);
        }

        [Fact]
        public async Task CreateFolder_NoErrorOccured_ReturnsResponse()
        {
           //Arrange
           messageHandlerMock.Protected()
              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                  x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/folder"), ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(new HttpResponseMessage
              {
                  StatusCode = HttpStatusCode.OK,
                  Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnCreateFolderResponse()), Encoding.Default, "application/json")
              });
           //Act
           var result = await SUT.CreateFolder(new CreateFolderRequest() { Path = "/test" });
           //Assert
           Assert.IsType<CreateFolderResponse>(result);
        }

        [Fact]
        public async Task CopyImage_NoErrorOccured_ReturnsResponse()
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
           var result = await SUT.CopyImage(MockRequests.ReturnCopyImageRequest());
           //Assert
           Assert.IsType<CopyImageResponse>(result);
        }

        [Fact]
        public async Task MoveImage_NoErrorOccured_ReturnsResponse()
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
           var result = await SUT.MoveImage(MockRequests.ReturnMoveImageRequest());
           //Assert
           Assert.IsType<MoveImageResponse>(result);
        }

        [Fact]
        public async Task ListFolder_NoErrorOccured_ReturnsResponse()
        {
           //Arrange
           messageHandlerMock.Protected()
              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                  x.RequestUri.ToString().StartsWith(BASE_ADDRESS + API_VERSION + "/folder")), ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(new HttpResponseMessage
              {
                  StatusCode = HttpStatusCode.OK,
                  Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnListFolderResponse()), Encoding.Default, "application/json")
              });
           //Act
           var result = await SUT.ListFolder(MockRequests.ReturnListFolderRequest());
           //Assert
           Assert.IsType<ListFolderResponse>(result);
        }

        [Fact]
        public async Task DeleteFolder_NoErrorOccured_ReturnsResponse()
        {
           //Arrange
           messageHandlerMock.Protected()
              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                  x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/folder"), ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(new HttpResponseMessage
              {
                  StatusCode = HttpStatusCode.OK,
                  Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnDeleteFolderResponse()), Encoding.Default, "application/json")
              });
           //Act
           var result = await SUT.DeleteFolder(new DeleteFolderRequest() { Path = "/folderName/" });
           //Assert
           Assert.IsType<DeleteFolderResponse>(result);
        }

        [Fact]
        public async Task DeleteImage_NoErrorOccured_ReturnsResponse()
        {
           //Arrange
           messageHandlerMock.Protected()
              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                  x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/image"), ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(new HttpResponseMessage
              {
                  StatusCode = HttpStatusCode.OK,
                  Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnDeleteImageResponse()), Encoding.Default, "application/json")
              });
           //Act
           var result = await SUT.DeleteImage(new DeleteImageRequest() { Name = "/folderName/img.png" });
           //Assert
           Assert.IsType<DeleteImageResponse>(result);
        }

        [Fact]
        public async Task FetchImage_NoErrorOccured_ReturnsResponse()
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
           var result = await SUT.FetchImage(new FetchImageRequest() { From = "http://example.com/img.png", TargetPath = "/", UseFilename = true });
           //Assert
           Assert.IsType<FetchImageResponse>(result);
        }

        [Fact]
        public async Task DeleteStream_NoErrorOccured_ReturnsResponse()
        {
           //Arrange
           messageHandlerMock.Protected()
              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                  x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/stream"), ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(new HttpResponseMessage
              {
                  StatusCode = HttpStatusCode.OK,
                  Content = new StringContent(JsonConvert.SerializeObject(MockResponses.ReturnDeleteStreamResponse()), Encoding.Default, "application/json")
              });
           //Act
           var result = await SUT.DeleteStream(new DeleteStreamRequest() { Name = "/4afdcb21ef149f06309573734e6d9515" });
           //Assert
           Assert.IsType<DeleteStreamResponse>(result);
        }

        [Fact]
        public async Task FetchStream_NoErrorOccured_ReturnsResponse()
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
           var result = await SUT.FetchStream(new FetchStreamRequest() { From = "http://example.com/img.png", TargetPath = "/", Filename = "name-of-stream.mp4" });
           //Assert
           Assert.IsType<FetchStreamResponse>(result);
        }
        
        [Fact]
        public async Task Purge_NoErrorOccured_ReturnsResponse()
        {
            //Arrange
            messageHandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x =>
                   x.RequestUri.ToString() == BASE_ADDRESS + API_VERSION + "/fetchStream"), ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.Accepted,
               });
            //Act
            var result = await SUT.Purge(new PurgeRequest { Path="/" });
            //Assert
            Assert.IsType<PurgeResponse>(result);
        }
    }
}
