using System;

namespace PluginDariApi.Helper
{
    public class Settings
    {
        public string ApiUrl { get; set; }
        public string AuthTokenHeader { get; set; }
        public string AuthToken { get; set; }
        
        /// <summary>
        /// Validates the settings input object
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Validate()
        {
            if (String.IsNullOrEmpty(ApiUrl))
            {
                throw new Exception("The ApiUrl property must be set");
            }

            if (String.IsNullOrEmpty(AuthTokenHeader))
            {
                throw new Exception("The AuthTokenHeader property must be set");
            }

            if (String.IsNullOrEmpty(AuthToken))
            {
                throw new Exception("The AuthToken property must be set");
            }
        }
    }
}