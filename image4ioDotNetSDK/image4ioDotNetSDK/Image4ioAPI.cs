using image4ioDotNetSDK.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK
{
    public class Image4ioAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public Image4ioAPI(string APIKey, string APISecret)
        {
            client.BaseAddress = new Uri("https://api.image4.io");

            var byteArray = Encoding.ASCII.GetBytes(APIKey + ":" + APISecret);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

        }



       public UploadResponseModel Upload(UploadRequestModel model) => UploadAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UploadResponseModel>UploadAsync(UploadRequestModel model)
        {
            
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                foreach (var i in model.Files)
                {
                    form.Add(new StreamContent(i));
                }

                var result = await client.PostAsync("v0.1/upload?path=" + (model.Path), form);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadResponseModel>(jsonResponse);
                response.IsSuccessfull = result.IsSuccessStatusCode;

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public CopyResponseModel Copy(CopyRequestModel model) => CopyAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CopyResponseModel> CopyAsync(CopyRequestModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Source))
                {
                    throw new MissingMemberException("source parameter is required");
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, System.Text.Encoding.Default, "application/json");


                var result = await client.PutAsync("v0.1/copy?source=" + (model.Source)+ "&target_path="+(model.Target_Path), stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = Newtonsoft.Json.JsonConvert.DeserializeObject<CopyResponseModel>(jsonResponse);
                response.IsSuccessfull = result.IsSuccessStatusCode;
               
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public MoveResponseModel Move(MoveRequestModel model) => MoveAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<MoveResponseModel> MoveAsync(MoveRequestModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Source))
                {
                    
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, System.Text.Encoding.Default, "application/json");

                var result = await client.PutAsync("v0.1/move?source=" + (model.Source) + "&target_path=" + (model.Target_Path), stringContent);

                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = Newtonsoft.Json.JsonConvert.DeserializeObject<MoveResponseModel>(jsonResponse);

                response.IsSuccessfull = result.IsSuccessStatusCode;

                return response;

                
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        public ListFolderResponseModel ListFolder(ListFolderRequestModel model) =>ListFolderAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListFolderResponseModel> ListFolderAsync(ListFolderRequestModel model)
        {
            try
            {
                var result = await client.GetAsync("v0.1/listfolder?path="+(model.Path));
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ListFolderResponseModel>(jsonResponse);

                response.IsSuccessfull = result.IsSuccessStatusCode;
        


                

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DeleteResponseModel Delete(DeleteRequestModel model) => DeleteAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<DeleteResponseModel> DeleteAsync(DeleteRequestModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.name))
                {
                    throw new MissingMemberException("you need to set 'file name'");
                }

                var result = await client.DeleteAsync("v0.1/deletefile?name=" + (model.name));
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = Newtonsoft.Json.JsonConvert.DeserializeObject<DeleteResponseModel>(jsonResponse);
                
                response.IsSuccessfull = result.IsSuccessStatusCode;
                
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public FetchResponseModel Fetch(FetchRequestModel model) => FetchAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FetchResponseModel> FetchAsync(FetchRequestModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.From))
                {

                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(json, System.Text.Encoding.Default, "application/json");

                var result = await client.PostAsync("v0.1/fetch?from=" + (model.From) + "&" + (model.Target_path), stringContent);

                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = Newtonsoft.Json.JsonConvert.DeserializeObject<FetchResponseModel>(jsonResponse);

                response.IsSuccessfull = result.IsSuccessStatusCode;

                return response;


            }
            catch (Exception e)
            {
                throw e;
            }



        }



    }
}
