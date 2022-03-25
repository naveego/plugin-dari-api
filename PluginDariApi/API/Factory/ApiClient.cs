using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Naveego.Sdk.Logging;
using PluginDariApi.Helper;

namespace PluginDariApi.API.Factory
{
    public class ApiClient: IApiClient
    {
        private IApiAuthenticator Authenticator { get; set; }
        private static HttpClient Client { get; set; }
        private Settings Settings { get; set; }

        public Settings GetSettings()
        {
            return Settings;
        }
        public ApiClient(HttpClient client, Settings settings)
        {
            Authenticator = new ApiAuthenticator(client, settings);
            Client = client;
            Settings = settings;
            
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task TestConnection()
        {
            try
            {
                var token = await Authenticator.GetToken();
                var uriBuilder = new UriBuilder(Settings.ApiUrl);
                var uri = new Uri(uriBuilder.ToString());
                
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                };

                request.Headers.Add(Settings.AuthTokenHeader, token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var response = await Client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            try
            {
                var token = await Authenticator.GetToken();
                var uriBuilder = new UriBuilder(path);
                var uri = new Uri(uriBuilder.ToString());
                
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                };

                request.Headers.Add(Settings.AuthTokenHeader, token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                return await Client.SendAsync(request);
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string path, StringContent json)
        {
            try
            {
                var token = await Authenticator.GetToken();
                var uriBuilder = new UriBuilder(path);
                var uri = new Uri(uriBuilder.ToString());
                
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = uri,
                    Content = json
                };

                request.Headers.Add(Settings.AuthTokenHeader, token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await Client.SendAsync(request);
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string path, StringContent json)
        {
            try
            {
                var token = await Authenticator.GetToken();
                var uriBuilder = new UriBuilder(path);
                var uri = new Uri(uriBuilder.ToString());
                
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = uri,
                    Content = json
                };

                request.Headers.Add(Settings.AuthTokenHeader, token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var response = await Client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }

                return await Client.SendAsync(request);
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> PatchAsync(string path, StringContent json)
        {
            try
            {
                var token = await Authenticator.GetToken();
                var uriBuilder = new UriBuilder(path);
                var uri = new Uri(uriBuilder.ToString());
                
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Patch,
                    RequestUri = uri,
                    Content = json
                };

                request.Headers.Add(Settings.AuthTokenHeader, token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                return await Client.SendAsync(request);
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            try
            {
                var token = await Authenticator.GetToken();
                var uriBuilder = new UriBuilder(path);
                var uri = new Uri(uriBuilder.ToString());
                
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = uri,
                };

                request.Headers.Add(Settings.AuthTokenHeader, token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                return await Client.SendAsync(request);
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw;
            }
        }
    }
}