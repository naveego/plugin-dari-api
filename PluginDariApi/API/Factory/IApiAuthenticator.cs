using System.Threading.Tasks;

namespace PluginDariApi.API.Factory
{
    public interface IApiAuthenticator
    {
        Task<string> GetToken();
    }
}