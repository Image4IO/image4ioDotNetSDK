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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK
{
    public class Image4ioAPI : IImage4ioAPI
    {
        private static HttpClient _client;
        private readonly string API_VERSION = "v2.0";
        private readonly string BASE_ADDRESS = "https://api.image4.io/";
        private readonly AuthenticationHeaderValue _auth;

        public Image4ioAPI(string APIKey, string APISecret)
        {
            if (_client == null || _client.BaseAddress == null)
            {
                _client = new HttpClient();

                var byteArray = Encoding.ASCII.GetBytes(APIKey + ":" + APISecret);
                _auth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }
        }

        public Image4ioAPI(string APIKey, string APISecret, HttpMessageHandler handler)
        {
            if (_client == null || _client.BaseAddress == null)
            {
                _client = new HttpClient(handler);

                var byteArray = Encoding.ASCII.GetBytes(APIKey + ":" + APISecret);
                _auth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }
        }

        public Image4ioAPI(string APIKey, string APISecret, HttpClient httpClient)
        {
            _client = httpClient;
            var byteArray = Encoding.ASCII.GetBytes(APIKey + ":" + APISecret);
            _auth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public async Task<SubscriptionResponse> Subscription()
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_ADDRESS + API_VERSION + "/subscription"),
                };
                request.Headers.Add("Authorization", _auth.ToString());
                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while getting subscription");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<SubscriptionResponse>(jsonResponse);
                
                return response;
            }
            catch(Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while getting subscription", e);
                throw ex;
            }
        }

        public async Task<UploadImageResponse> UploadImage(UploadImageRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(new SignUrlRequest
                {
                    FromSdk=true,
                    Path=model.Path,
                    Filename=model.Image.FileName,
                    Ext=model.Image.Extension,
                    Overwrite=model.Overwrite,
                    UseFilename=model.UseFilename
                });
                StringContent signUrlContent = new StringContent(json, Encoding.Default, "application/json");
                var signUrlRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/getSignUrl"),
                    Content= signUrlContent,
                };
                signUrlRequest.Headers.Add("Authorization", _auth.ToString());

                var signUrlResult = await _client.SendAsync(signUrlRequest);
                await CheckRequestError(signUrlResult, "There is an error while uploading image");
                var signUrlResponse = await signUrlResult.Content.ReadAsStringAsync();
                var signUrl = JsonConvert.DeserializeObject<SignUrlResponse>(signUrlResponse);

                var uploadContent = new StreamContent(model.Image.Data);
                var uploadRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(signUrl.Url),
                    Content = uploadContent,
                };
                var putRes=await _client.SendAsync(uploadRequest);
                await CheckRequestError(putRes, "There is an error while uploading image");

                string imgJson = JsonConvert.SerializeObject(new UploadImageReq
                {
                    FromSdk = true,
                    Path =signUrl.Path
                });
                StringContent imgContent = new StringContent(imgJson, Encoding.Default, "application/json");
                var imgRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/image"),
                    Content = imgContent,
                };
                imgRequest.Headers.Add("Authorization", _auth.ToString());

                var imgResult = await _client.SendAsync(imgRequest);
                await CheckRequestError(imgResult, "There is an error while uploading image");
                var imgResponse = await imgResult.Content.ReadAsStringAsync();
                var response= JsonConvert.DeserializeObject<UploadImageResponse>(imgResponse);
                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while uploading image", e);
                throw ex;
            }
        }

        public async Task<UploadStreamResponse> UploadStream(UploadStreamRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(new SignUrlRequest
                {
                    FromSdk = true,
                    Path = model.Path,
                    Filename = model.Stream.FileName,
                    Ext = model.Stream.Extension,
                    Overwrite = model.Overwrite,
                    UseFilename = model.UseFilename
                });
                StringContent signUrlContent = new StringContent(json, Encoding.Default, "application/json");
                var signUrlRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/getSignUrl"),
                    Content = signUrlContent,
                };
                signUrlRequest.Headers.Add("Authorization", _auth.ToString());

                var signUrlResult = await _client.SendAsync(signUrlRequest);
                await CheckRequestError(signUrlResult, "There is an error while uploading stream");
                var signUrlResponse = await signUrlResult.Content.ReadAsStringAsync();
                var signUrl = JsonConvert.DeserializeObject<SignUrlResponse>(signUrlResponse);

                var uploadContent = new StreamContent(model.Stream.Data);
                var uploadRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(signUrl.Url),
                    Content = uploadContent,
                };
                var putRes = await _client.SendAsync(uploadRequest);
                await CheckRequestError(putRes, "There is an error while uploading stream");

                string imgJson = JsonConvert.SerializeObject(new UploadImageReq
                {
                    FromSdk = true,
                    Path = signUrl.Path
                });
                StringContent imgContent = new StringContent(imgJson, Encoding.Default, "application/json");
                var imgRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/stream"),
                    Content = imgContent,
                };
                imgRequest.Headers.Add("Authorization", _auth.ToString());

                var imgResult = await _client.SendAsync(imgRequest);
                await CheckRequestError(imgResult, "There is an error while uploading stream");
                var imgResponse = await imgResult.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<UploadStreamResponse>(imgResponse);
                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while uploading image", e);
                throw ex;
            }
        }

        public async Task<GetImageResponse> GetImage(GetImageRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/image?name=" + model.Name),
                };

                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while getting image");
                var imgResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<GetImageResponse>(imgResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while getting image", e);
                throw ex;
            }
        }

        public async Task<GetStreamResponse> GetStream(GetStreamRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/stream?name=" + model.Name),
                };

                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while getting stream");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<GetStreamResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while getting stream", e);
                throw ex;
            }
        }

        public async Task<CreateFolderResponse> CreateFolder(CreateFolderRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.Default, "application/json");
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/folder"),
                    Content = content,
                };
                request.Headers.Add("Authorization", _auth.ToString());

                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while creating folder");
                var imgResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<CreateFolderResponse>(imgResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while creating folder", e);
                throw ex;
            }
        }

        public async Task<CopyImageResponse> CopyImage(CopyImageRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.Default, "application/json");
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/copyImage"),
                    Content = content,
                };
                request.Headers.Add("Authorization", _auth.ToString());
                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while copying image");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<CopyImageResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while copying image", e);
                throw ex;
            }
        }

        public async Task<MoveImageResponse> MoveImage(MoveImageRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.Default, "application/json");
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/moveImage"),
                    Content = content,
                };
                request.Headers.Add("Authorization", _auth.ToString());
                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while moving image");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<MoveImageResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while moving image", e);
                throw ex;
            }

        }

        public async Task<ListFolderResponse> ListFolder(ListFolderRequest model)
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
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/folder" + queryBuilder.ToQueryString()),
                };
                request.Headers.Add("Authorization", _auth.ToString());
                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while listing folder");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ListFolderResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while listing folder", e);
                throw ex;
            }
        }

        public async Task<DeleteImageResponse> DeleteImage(DeleteImageRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/image"),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.Default, "application/json")
                };
                request.Headers.Add("Authorization", _auth.ToString());
                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while deleting image");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<DeleteImageResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while deleting image", e);
                throw ex;
            }
        }

        public async Task<DeleteStreamResponse> DeleteStream(DeleteStreamRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/stream"),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.Default, "application/json")
                };

                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while deleting stream");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<DeleteStreamResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while deleting a stream", e);
                throw ex;
            }
        }

        public async Task<DeleteFolderResponse> DeleteFolder(DeleteFolderRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/folder"),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.Default, "application/json")
                };

                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while deleting folder");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<DeleteFolderResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while deleting folder", e);
                throw ex;
            }
        }

        public async Task<FetchImageResponse> FetchImage(FetchImageRequest model)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BASE_ADDRESS + "/" + API_VERSION + "/fetchImage"),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.Default, "application/json")
                };

                var result = await _client.SendAsync(request);
                await CheckRequestError(result, "There is an error while fetching image");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<FetchImageResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while fetching image", e);
                throw ex;
            }
        }

        public async Task<FetchStreamResponse> FetchStream(FetchStreamRequest model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await _client.PostAsync(API_VERSION + "/fetchStream", stringContent);
                await CheckRequestError(result, "There is an error while fetching stream");
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<FetchStreamResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while fetching an stream", e);
                throw ex;
            }
        }
        
        public async Task<PurgeResponse> Purge()
        {
            try
            {
                var result = await _client.DeleteAsync(API_VERSION + "/purge");
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new PurgeResponse
                    {
                        Success = false,
                        Errors = new List<string> { "Unauthorized. Please check your API Key and API Secret." }
                    };
                }
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<PurgeResponse>(jsonResponse);

                return response;
            }
            catch (Image4ioException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                var ex = new Image4ioException("There is an error while purging the files from CDN", e);
                throw ex;
            }
        }

        #region Private Functions

        private async Task CheckRequestError(HttpResponseMessage response,string errorMessage)
        {
            if (!response.IsSuccessStatusCode)
            {
                BaseResponse err;
                try
                {
                    var res = await response.Content.ReadAsStringAsync();
                    err = JsonConvert.DeserializeObject<BaseResponse>(res);

                }
                catch (Exception)
                {
                    throw new Image4ioException(errorMessage, new Exception());
                }
                if (err != null && err.Errors.Count > 0)
                {
                    throw new Image4ioException(err.Errors.FirstOrDefault(), new Exception());
                }
                else
                {
                    throw new Image4ioException(errorMessage, new Exception());
                }
            }
        }

        #endregion

        #region Private Models
        private class SignUrlRequest
        {
            [JsonProperty("fromSdk")]
            public bool FromSdk { get; set; }
            [JsonProperty("path")]
            public string Path { get; set; }
            [JsonProperty("filename")]
            public string Filename { get; set; }
            [JsonProperty("ext")]
            public string Ext { get; set; }
            [JsonProperty("useFilename")]
            public bool UseFilename { get; set; }
            [JsonProperty("overwrite")]
            public bool Overwrite { get; set; }
        }

        private class SignUrlResponse : BaseResponse
        {
            [JsonProperty("url")]
            public string Url { get; set; }
            [JsonProperty("path")]
            public string Path { get; set; }
        }

        private class UploadImageReq
        {
            [JsonProperty("fromSdk")]
            public bool FromSdk { get; set; }
            [JsonProperty("path")]
            public string Path { get; set; }
        }

        #endregion
    }
}
