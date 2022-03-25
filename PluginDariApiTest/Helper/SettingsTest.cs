using System;
using PluginDariApi.Helper;
using Xunit;

namespace PluginDariApiTest.Helper
{
    public class SettingsTest
    {
        [Fact]
        public void ValidateValidTest()
        {
            // setup
            var settings = new Settings
            {
                ApiUrl = "Url",
                AuthToken = "Token",
                AuthTokenHeader = "Header"
            };

            // act
            settings.Validate();

            // assert
        }

        [Fact]
        public void ValidateApiUrlTest()
        {
            // setup
            var settings = new Settings
            {
                ApiUrl = null,
                AuthToken = "Token",
                AuthTokenHeader = "Header"
            };

            // act
            Exception e = Assert.Throws<Exception>(() => settings.Validate());

            // assert
            Assert.Contains("The ApiUrl property must be set", e.Message);
        }
        
        [Fact]
        public void ValidateAuthTokenTest()
        {
            // setup
            var settings = new Settings
            {
                ApiUrl = "Url",
                AuthToken = null,
                AuthTokenHeader = "Header"
            };

            // act
            Exception e = Assert.Throws<Exception>(() => settings.Validate());

            // assert
            Assert.Contains("The AuthToken property must be set", e.Message);
        }
        
        [Fact]
        public void ValidateAuthTokenHeaderTest()
        {
            // setup
            var settings = new Settings
            {
                ApiUrl = "Url",
                AuthToken = "Token",
                AuthTokenHeader = null
            };

            // act
            Exception e = Assert.Throws<Exception>(() => settings.Validate());

            // assert
            Assert.Contains("The AuthTokenHeader property must be set", e.Message);
        }
    }
}