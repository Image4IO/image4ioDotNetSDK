using image4ioDotNetSDK.Models;
using image4ioDotNetSDK.Models.Exception;
using image4ioDotNetSDK.Models.Request;
using image4ioDotNetSDK.Models.Response;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK
{
    public class Image4ioAPI : IImage4ioAPI
    {
        private static HttpClient client;
        private readonly string API_VERSION = "v1.0";
        private readonly string BASE_ADDRESS = "https://api.image4.io";

        public Image4ioAPI(string APIKey, string APISecret)
        {
            if (client == null || client.BaseAddress == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(BASE_ADDRESS);

                var byteArray = Encoding.ASCII.GetBytes(APIKey + ":" + APISecret);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }
        }

        public Image4ioAPI(string APIKey, string APISecret, HttpMessageHandler handler)
        {
            if (client == null || client.BaseAddress == null)
            {
                client = new HttpClient(handler);
                client.BaseAddress = new Uri(BASE_ADDRESS);

                var byteArray = Encoding.ASCII.GetBytes(APIKey + ":" + APISecret);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }
        }

        public SubscriptionResponse Subscription() => SubscriptionAsync().ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SubscriptionResponse> SubscriptionAsync()
        {
            try
            {
                var result = await client.GetAsync(API_VERSION + "/subscription");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<SubscriptionResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while getting subscription", e);
                throw ex;
            }
        }


        public UploadImageResponse UploadImage(UploadImageRequest model) => UploadImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UploadImageResponse> UploadImageAsync(UploadImageRequest model)
        {
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent
                {
                    { new StringContent(model.UseFilename.ToString()), "useFilename" },
                    { new StringContent(model.Overwrite.ToString()), "overwrite" },
                    { new StringContent(model.Path.ToString()), "path" }
                };
                foreach (var i in model.Files)
                {
                    form.Add(new StreamContent(i.Data), "file", i.FileName);
                }

                var result = await client.PostAsync(API_VERSION + "/uploadImage", form);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<UploadImageResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while uploading image(s)", e);
                throw ex;
            }
        }


        public ImageResponse GetImage(ImageRequest model) => GetImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ImageResponse> GetImageAsync(ImageRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/image?name=" + model.Name),
                };

                var result = await client.SendAsync(request);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ImageResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while getting image", e);
                throw ex;
            }
        }

        public CreateFolderResponse CreateFolder(CreateFolderRequest model) => CreateFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PostAsync(API_VERSION + "/createFolder", stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<CreateFolderResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while creating folder", e);
                throw ex;
            }
        }

        public CopyImageResponse CopyImage(CopyImageRequest model) => CopyImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CopyImageResponse> CopyImageAsync(CopyImageRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PutAsync(API_VERSION + "/copyImage", stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<CopyImageResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while copying image", e);
                throw ex;
            }
        }

        public MoveImageResponse MoveImage(MoveImageRequest model) => MoveImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<MoveImageResponse> MoveImageAsync(MoveImageRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PutAsync(API_VERSION + "/moveImage", stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<MoveImageResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while moving image", e);
                throw ex;
            }

        }

        public ListFolderResponse ListFolder(ListFolderRequest model) => ListFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListFolderResponse> ListFolderAsync(ListFolderRequest model)
        {
            try
            {
                var queryBuilder = new QueryBuilder();
                if (!String.IsNullOrEmpty(model.Path))
                {
                    queryBuilder.Add("path", model.Path);
                }
                if (!String.IsNullOrEmpty(model.ContinuationToken))
                {
                    queryBuilder.Add("continuationToken", model.ContinuationToken);
                }

                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/listFolder" + queryBuilder.ToQueryString()),
                };
                var result = await client.SendAsync(request);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ListFolderResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while listing folder", e);
                throw ex;
            }
        }

        public DeleteImageResponse DeleteImage(DeleteImageRequest model) => DeleteImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<DeleteImageResponse> DeleteImageAsync(DeleteImageRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/deleteImage"),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.Default, "application/json")
                };

                var result = await client.SendAsync(request);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<DeleteImageResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while deleting an image", e);
                throw ex;
            }
        }

        public DeleteFolderResponse DeleteFolder(DeleteFolderRequest model) => DeleteFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<DeleteFolderResponse> DeleteFolderAsync(DeleteFolderRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/deleteFolder"),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.Default, "application/json")
                };

                var result = await client.SendAsync(request);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<DeleteFolderResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while deleting an image", e);
                throw ex;
            }
        }

        public FetchImageResponse FetchImage(FetchImageRequest model) => FetchImageAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FetchImageResponse> FetchImageAsync(FetchImageRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PostAsync(API_VERSION + "/fetchImage", stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<FetchImageResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while deleting an image", e);
                throw ex;
            }
        }

        #region Streams
        public StartUploadStreamResponse StartUploadStream(StartUploadStreamRequest model) => StartUploadStreamAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<StartUploadStreamResponse> StartUploadStreamAsync(StartUploadStreamRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PostAsync(API_VERSION + "/uploadStream", stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<StartUploadStreamResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while starting to upload a stream", e);
                throw ex;
            }
        }

        public BaseResponse UploadStreamPart(UploadStreamPartRequest model) => UploadStreamPartAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<BaseResponse> UploadStreamPartAsync(UploadStreamPartRequest model)
        {
            try
            {

                MultipartFormDataContent form = new MultipartFormDataContent
                {
                    { new StreamContent(model.StreamPart), "Part",model.FileName },
                    { new StringContent(model.PartId.ToString()), "PartId" },
                    { new StringContent(model.Token), "Token" },
                    { new StringContent(model.FileName), "FileName" }
                };

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), new Uri(client.BaseAddress + API_VERSION + "/uploadStream"))
                {
                    Content = form
                };

                var result = await client.SendAsync(request);
                if (!result.IsSuccessStatusCode)
                {
                    var jsonResponse = await result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<BaseResponse>(jsonResponse);
                    return response;
                }
                else
                {
                    return new BaseResponse
                    {
                        Errors = new List<string>(),
                        Messages = new List<string>(),
                        Success = true
                    };
                }

            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while uploading stream part", e);
                throw ex;
            }
        }

        public FinalizeStreamResponse FinalizeStream(FinalizeStreamRequest model) => FinalizeStreamAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FinalizeStreamResponse> FinalizeStreamAsync(FinalizeStreamRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PostAsync(API_VERSION + "/finalizeStream", stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<FinalizeStreamResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while finalizing the stream", e);
                throw ex;
            }
        }

        public StreamResponse GetStream(StreamRequest model) => GetStreamAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<StreamResponse> GetStreamAsync(StreamRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/stream?name=" + model.Name),
                };

                var result = await client.SendAsync(request);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<StreamResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while getting stream", e);
                throw ex;
            }
        }

        public DeleteStreamResponse DeleteStream(DeleteStreamRequest model) => DeleteStreamAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<DeleteStreamResponse> DeleteStreamAsync(DeleteStreamRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/deleteStream"),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.Default, "application/json")
                };

                var result = await client.SendAsync(request);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<DeleteStreamResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while deleting a stream", e);
                throw ex;
            }
        }

        public FetchStreamResponse FetchStream(FetchStreamRequest model) => FetchStreamAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FetchStreamResponse> FetchStreamAsync(FetchStreamRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PostAsync(API_VERSION + "/fetchStream", stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<FetchStreamResponse>(jsonResponse);

                return response;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while fetching an stream", e);
                throw ex;
            }
        }

        #endregion
    }
}
