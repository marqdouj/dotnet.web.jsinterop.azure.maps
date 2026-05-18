//using Microsoft.JSInterop;
// For Azure Maps Anonymous authentication
//using Microsoft.Identity.Client;

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Sandbox
{
    internal static class MapsSetup
    {
        private static MapConfiguration? mapConfiguration;
        //private static string clientSecret = "";
        //private static readonly string authorityFormat = "https://login.microsoftonline.com/{0}/oauth2/v2.0";
        //private static readonly string graphScope = "https://atlas.microsoft.com/.default";
        //private static string? sasToken; //Used only for demo purposes; do not do this in production.

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

        //private static void ConfigureForSasToken(IConfiguration configuration, AzMapsConfiguration config)
        //{
        //    config.AuthOptions.AuthType = AuthenticationType.sas;

        //    //If provided, do do not need to configure GetSasToken callback in App.Razor
        //    //config.SasTokenUrl = "[YOUR SAS TOKEN URL]";

        //    //For demo only, do not do this in production.
        //    sasToken = configuration["AzureMaps:SasToken"];
        //}

        /// <summary>
        /// Only used for SasToken AuthOptions.
        /// Requires token callback be configured in App.razor.
        /// </summary>
        /// <returns></returns>
        //[JSInvokable]
        //public static async Task<string?> GetSasToken()
        //{
        //    //TODO: Implement logic to generate SasToken.
        //    // For the purpose of testing, I manually generate SasToken (via Azure Maps Account/Shared Access Signature)
        //    // and add it to my User Secrets.
        //    return sasToken;
        //}

        //private static void ConfigureForAad(IConfiguration configuration, AzMapsConfiguration config)
        //{
        //    config.AuthOptions.AuthType = AuthenticationType.aad;
        //    config.AuthOptions.AadAppId = configuration["AzureMaps:AadAppId"];
        //    config.AuthOptions.AadTenant = configuration["AzureMaps:AadTenant"];
        //    config.AuthOptions.ClientId = configuration["AzureMaps:ClientId"];
        //}

        //private static void ConfigureForAnonymous(IConfiguration configuration, AzMapsConfiguration config)
        //{
        //    //NOTE: See GetAccessToken().
        //    config.AuthOptions.AuthType = AuthenticationType.anonymous;
        //    config.AuthOptions.AadAppId = configuration["AzureMaps:AadAppId"];
        //    config.AuthOptions.AadTenant = configuration["AzureMaps:AadTenant"];
        //    config.AuthOptions.ClientId = configuration["AzureMaps:ClientId"];
        //    clientSecret = configuration["AzureMaps:ClientSecret"] ?? "";
        //}

        /// <summary>
        /// Only used for Anonymous AuthOptions.
        /// Requires token callback be configured in App.razor.
        /// </summary>
        /// <returns></returns>
        //[JSInvokable]
        //public static async Task<string> GetAccessToken()
        //{
        //    IConfidentialClientApplication daemonClient;
        //    daemonClient = ConfidentialClientApplicationBuilder.Create(mapConfiguration!.AuthOptions.AadAppId)
        //        .WithAuthority(string.Format(authorityFormat, mapConfiguration.AuthOptions.AadTenant))
        //        .WithClientSecret(clientSecret)
        //        .Build();
        //    AuthenticationResult authResult =
        //    await daemonClient.AcquireTokenForClient([graphScope]).ExecuteAsync();
        //    return authResult.AccessToken;
        //}
    }
}
