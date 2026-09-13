using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// Authentication method to be used when creating the map.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<AuthenticationType>))]
    public enum AuthenticationType
    {
        /// <summary>
        /// The subscription key authentication mechanism.
        /// </summary>
        subscriptionKey,

        /// <summary>
        /// The AAD implicit grant mechanism. Recommended for pages protected by a sign-in.
        /// By default the page will be redirected to the AAD login when the map control initializes.
        /// </summary>
        aad,

        /// <summary>
        /// The anonymous authentication mechanism. Recommended for public pages.
        /// Allows a callback responsible for acquiring an authentication token to be provided.
        /// </summary>
        anonymous,

        /// <summary>
        /// The shared access signature authentication mechanism. 
        /// Allows a callback responsible for acquiring a token to be provided on requests.
        /// </summary>
        sas,
    }

    /// <summary>
    /// Contains information used to invoke the 'getToken' method for authentication.
    /// </summary>
    public class AuthenticationTokenInfo
    {
        /// <param name="id"><see cref="Id"/></param>
        /// <param name="identifier"><see cref="Identifier"/></param>
        /// <param name="authType"><see cref="AuthType"/></param>
        public AuthenticationTokenInfo(string id, string identifier, AuthenticationType authType)
        {
            Id = id;
            Identifier = identifier;
            AuthType = authType;

            switch (authType)
            {
                case AuthenticationType.anonymous:
                case AuthenticationType.sas:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(authType));
            }
        }

        /// <summary>
        /// {PACKAGE ID/ASSEMBLY NAME}
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// JSInvokable method name.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Must be <see cref="AuthenticationType.anonymous"/> or <see cref="AuthenticationType.sas"/>.
        /// </summary>
        public AuthenticationType AuthType { get; }
    }

    /// <summary>
    /// Authentication configuration for the Azure map.
    /// </summary>
    public class AuthenticationOptions : OptionsBase
    {
        /// <summary>
        /// The authentication method to be used.
        /// </summary>
        public AuthenticationType AuthType { get; set; }

        /// <summary>
        /// Subscription key from your Azure Maps account.
        /// Must be specified for subscription key authentication type.
        /// </summary>
        public string? SubscriptionKey { get; set; }

        /// <summary>
        /// Optionally provide an initial token for sas authentication.
        /// </summary>
        public string? SasToken { get; set; }

        /// <summary>
        /// Optionally provide a SAS token URL for your Azure Maps Account.
        /// If <see cref="AuthType"/> = <see cref="AuthenticationType.sas"/> and this value is set, it will be handled internally
        /// and any other sas options will be ignored.
        /// </summary>
        public string? SasTokenUrl { get; set; }

        /// <summary>
        /// When a TokenInfo is assigned, a callback will be created based on <inheritdoc cref="AuthenticationTokenInfo"/>.
        /// </summary>
        public AuthenticationTokenInfo? TokenInfo { get; set; }

        /// <summary>
        /// The Azure AD registered app ID. This is the app ID of an app registered in your Azure AD tenant.
        /// Must be specified for AAD authentication type.
        /// </summary>
        public string? AadAppId { get; set; }

        /// <summary>
        /// The AAD tenant that owns the registered app specified by 'aadAppId'.
        /// Must be specified for AAD authentication type.</summary>
        public string? AadTenant { get; set; }

        /// <summary>
        /// The Azure Maps client ID, This is an unique identifier used to identify the maps account.
        /// Preferred to always be specified, but must be specified for AAD and anonymous authentication types.
        /// </summary>
        public string? ClientId { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Indicates whether the authentication options are valid for the specified authentication type.
        /// </summary>
        /// <returns></returns>
        internal bool IsValid()
        {
            return AuthType switch
            {
                AuthenticationType.subscriptionKey => !string.IsNullOrWhiteSpace(SubscriptionKey),
                AuthenticationType.sas => true, //Requires configuring JSInvokable GetSasToken method in App.Razor or configuring a SAS Token url.
                AuthenticationType.aad => !string.IsNullOrWhiteSpace(AadAppId) && !string.IsNullOrWhiteSpace(AadTenant),
                AuthenticationType.anonymous => !string.IsNullOrWhiteSpace(ClientId),
                _ => false
            };
        }

        internal bool IsNotValid() => !IsValid();

        internal string InValidMessage()
        {
            return AuthType switch
            {
                AuthenticationType.subscriptionKey => string.IsNullOrWhiteSpace(SubscriptionKey)
                    ? "SubscriptionKey is required when authentication Mode is SubscriptionKey."
                    : "",
                AuthenticationType.sas => "", //Requires configuring JSInvokable GetSasToken method in App.Razor or configuring a SAS Token url.
                AuthenticationType.aad => string.IsNullOrWhiteSpace(AadAppId) || string.IsNullOrWhiteSpace(AadTenant)
                    ? "AadAppId and AadTenant are required when authentication Mode is Aad."
                    : "",
                AuthenticationType.anonymous => string.IsNullOrWhiteSpace(ClientId)
                    ? "ClientId is required when authentication Mode is Anonymous."
                    : "",
                _ => ""
            };
        }
    }
}

