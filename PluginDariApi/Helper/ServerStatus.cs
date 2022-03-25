using Naveego.Sdk.Plugins;

namespace PluginDariApi.Helper
{
    public static class ServerStatus
    {
        public static ConfigureRequest Config { get; set; }
        public static Settings Settings { get; set; }
        public static bool Connected { get; set; }
        public static bool WriteConfigured { get; set; }
    }
}