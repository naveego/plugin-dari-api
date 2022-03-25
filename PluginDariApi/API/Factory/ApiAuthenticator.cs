using System.Net.Http;
using System.Threading.Tasks;
using PluginDariApi.Helper;

namespace PluginDariApi.API.Factory
{
    public class ApiAuthenticator: IApiAuthenticator
    {
        private HttpClient Client { get; set; }
        private Settings Settings { get; set; }
        private string Token { get; set; }

        public ApiAuthenticator(HttpClient client, Settings settings)
        {
            Client = client;
            Settings = settings;
            Token = "";
        }

        public async Task<string> GetToken()
        {
            return await GetNewToken();
        }

        private Task<string> GetNewToken()
        {
            return Task.FromResult(Settings.AuthToken);
        }
    }
}