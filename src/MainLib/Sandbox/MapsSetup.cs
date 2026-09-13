using Microsoft.JSInterop;
// For Azure Maps Anonymous authentication
using Microsoft.Identity.Client;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Sandbox
{
    public static class MapsSetup
    {
        private static MapConfiguration? mapConfiguration;
        private static string clientSecret = "";
        private static readonly string authorityFormat = "https://login.microsoftonline.com/{0}/oauth2/v2.0";
        private static readonly string graphScope = "https://atlas.microsoft.com/.default";

        public static IServiceCollection ConfigureMarqdoujAzureMaps(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            //User Secrets for local development; Azure Key Vault for Production?:
            //"AzureMaps": {
            //    "AuthenticationType": "SubscriptionKey",
            //    "AadAppId": "",
            //    "AadTenant": "",
            //    "ClientId": "",
            //    "ClientSecret": "",
            //    "SubscriptionKey": "[YOUR KEY]"
            //  }

            mapConfiguration = services.AddMarqdoujAzureMaps(config =>
            {
                ConfigureForSubscriptionKey(configuration, config, isDevelopment);
                //ConfigureForSasToken(configuration, config);
                //ConfigureForAad(configuration, config);
                //ConfigureForAnonymous(configuration, config);
            });

            return services;
        }

        private static void ConfigureForSubscriptionKey(IConfiguration configuration, MapConfiguration config, bool isDevelopment)
        {
            config.AuthOptions.AuthType = AuthenticationType.subscriptionKey;
            config.AuthOptions.SubscriptionKey = configuration["AzureMaps:SubscriptionKey"];
            
            if (isDevelopment)
                config.JsLogLevel = LogLevel.Trace; //Set log level to Trace for development.
        }

        private static void ConfigureForSasToken(IConfiguration configuration, MapConfiguration config)
        {
            config.AuthOptions.AuthType = AuthenticationType.sas;

            config.AuthOptions.SasTokenUrl = configuration["AzureMaps:SasTokenUrl"];
            if (!string.IsNullOrWhiteSpace(config.AuthOptions.SasTokenUrl))
                return;

            config.AuthOptions.SasToken = configuration["AzureMaps:SasToken"];
            if (!string.IsNullOrWhiteSpace(config.AuthOptions.SasToken))
                return;

            config.AuthOptions.TokenInfo = new(nameof(Sandbox), nameof(GetSasToken), AuthenticationType.sas);
        }

        /// <summary>
        /// Only used for SasToken AuthOptions.
        /// Requires AuthOptions.TokenInfo to be configured.
        /// </summary>
        /// <returns></returns>
        [JSInvokable("GetSasToken")]
        public static async Task<string?> GetSasToken()
        {
            //TODO: Implement logic to generate SasToken.
            //var sasToken = "[ADD LOGIC TO GET SAS TOKEN]";

            // For the purpose of testing, I manually generate a SasToken (via Azure Maps Account/Shared Access Signature)
            var sasToken = "[INSERT GENERATED TOKEN FOR TESTING]";
            return sasToken;
        }

        private static void ConfigureForAad(IConfiguration configuration, MapConfiguration config)
        {
            config.AuthOptions.AuthType = AuthenticationType.aad;
            config.AuthOptions.AadAppId = configuration["AzureMaps:AadAppId"];
            config.AuthOptions.AadTenant = configuration["AzureMaps:AadTenant"];
            config.AuthOptions.ClientId = configuration["AzureMaps:ClientId"];
        }

        private static void ConfigureForAnonymous(IConfiguration configuration, MapConfiguration config)
        {
            config.AuthOptions.AuthType = AuthenticationType.anonymous;
            config.AuthOptions.AadAppId = configuration["AzureMaps:AadAppId"];
            config.AuthOptions.AadTenant = configuration["AzureMaps:AadTenant"];
            config.AuthOptions.ClientId = configuration["AzureMaps:ClientId"];
            clientSecret = configuration["AzureMaps:ClientSecret"] ?? "";

            config.AuthOptions.TokenInfo = new(nameof(Sandbox), nameof(GetAccessToken), AuthenticationType.anonymous);
        }

        /// <summary>
        /// Only used for Anonymous AuthOptions.
        /// Requires AuthOptions.TokenInfo to be configured.
        /// </summary>
        /// <returns></returns>
        [JSInvokable("GetAccessToken")]
        public static async Task<string> GetAccessToken()
        {
            IConfidentialClientApplication daemonClient;
            daemonClient = ConfidentialClientApplicationBuilder.Create(mapConfiguration!.AuthOptions.AadAppId)
                .WithAuthority(string.Format(authorityFormat, mapConfiguration.AuthOptions.AadTenant))
                .WithClientSecret(clientSecret)
                .Build();
            AuthenticationResult authResult =
            await daemonClient.AcquireTokenForClient([graphScope]).ExecuteAsync();
            return authResult.AccessToken;
        }
    }
}
