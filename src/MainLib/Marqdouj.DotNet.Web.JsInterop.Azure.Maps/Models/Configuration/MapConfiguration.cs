using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// Represents the configuration settings for map integration, including authentication and map-specific options.
    /// </summary>
    /// <remarks>Use this class to specify authentication credentials and additional options required for
    /// connecting to and displaying maps within an application. The settings provided by this class are typically
    /// required for initializing map services or components.</remarks>
    public class MapConfiguration
    {
        /// <summary>
        /// The authentication settings used for accessing map services.
        /// </summary>
        /// <remarks>Use this property to configure credentials or tokens required for map service
        /// requests. The settings specified here determine how authentication is handled when connecting to external
        /// map providers.</remarks>
        public AuthenticationOptions AuthOptions { get; set; } = new();

        /// <summary>
        /// The default global options used to configure the map's behavior and appearance.
        /// These options can be ovverridden at runtime as needed be assigning new values to the map component.
        /// </summary>
        /// <remarks>Assigning a value to this property allows customization of map features such as
        /// controls, display settings, and interaction modes. If set to <see langword="null"/>, default map options
        /// will be used.</remarks>
        public MapOptions? MapOptions { get; set; }

        /// <summary>
        /// The minimum log level for messages to be written to the browser console in the js scripts.
        /// </summary>
        /// <remarks>Messages with a severity lower than the specified log level will be ignored. Adjust
        /// this property to control the verbosity of logging output to the browser console.</remarks>
        public LogLevel JsLogLevel { get; set; } = LogLevel.Information;

        internal bool IsValid => AuthOptions?.IsValid() ?? false;

        internal string ValidationMessage => GetValidateMessage();

        private string GetValidateMessage()
        {
            return AuthOptions == null
                ? "map Authentication configuration is missing."
                : AuthOptions.InValidMessage();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class MapConfigurationExtensions
    {
        /// <summary>
        /// Configures <see cref="MapConfiguration"/>, optionally enabling configuration validation.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="config">A delegate that configures the <see cref="MapConfiguration"/> instance used for Azure Maps integration.</param>
        /// <param name="validate">Specifies whether to enable validation of the <see cref="MapConfiguration"/> during configuration. 
        /// Set to <see langword="true"/> to validate the configuration; otherwise, <see langword="false"/> to validate in the Component.</param>
        /// <returns>An instance of the resolved <see cref="MapConfiguration"/></returns>
        public static MapConfiguration AddMarqdoujAzureMaps(this IServiceCollection services, Action<MapConfiguration> config, bool validate = false)
        {
            if (validate)
            {
                services
                    .AddOptions<MapConfiguration>()
                    .Configure(config)
                    .Validate(c => c.AuthOptions.IsValid(), config.InValidMessage());
            }
            else
            {
                services
                    .AddOptions<MapConfiguration>()
                    .Configure(config);
            }

            return config.GetConfiguration();
        }

        private static string InValidMessage(this Action<MapConfiguration> config)
        {
            var c = config.GetConfiguration();
            return c.AuthOptions.InValidMessage();
        }

        private static MapConfiguration GetConfiguration(this Action<MapConfiguration> config)
        {
            var c = new MapConfiguration();
            config.Invoke(c);
            return c;
        }
    }

}
