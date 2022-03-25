using PluginDariApi.Helper;

namespace PluginDariApi.API.Factory
{
    public interface IApiClientFactory
    {
        IApiClient CreateApiClient(Settings settings);
    }
}