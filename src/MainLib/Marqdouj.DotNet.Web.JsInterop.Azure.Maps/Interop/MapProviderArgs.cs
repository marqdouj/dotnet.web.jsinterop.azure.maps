namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop
{
    /// <summary>
    /// 
    /// </summary>
    public enum MapProviderError
    {
        /// <summary>
        /// Indicates that there is no error.
        /// </summary>
        None,

        /// <summary>
        /// Indicates that an authentication attempt has failed.
        /// </summary>
        AuthenticationFailed,

        /// <summary>
        /// Indicates that an attempt to create an instance has failed.
        /// </summary>
        CreateInstanceFailed,
    }

    /// <summary>
    /// Provides data for the event that signals the completion of the Azure Maps interop provider initialization
    /// process.
    /// </summary>
    /// <remarks>This class contains information about the result of initializing the Azure Maps interop
    /// provider, including success status, any error encountered, and exception details if initialization failed. Use
    /// the Success property to determine whether initialization was successful, and refer to the Error and Exception
    /// properties for additional error context when initialization fails.</remarks>
    public class MapProviderArgs
    {
        internal MapProviderArgs(IAzureMapsInterop? mapsInterop)
        {
            MapsInterop = mapsInterop;
        }

        internal MapProviderArgs(MapProviderError error, Exception? exception)
        {
            Error = error;
            Exception = exception;
        }

        /// <summary>
        /// Gets the Azure Maps interop instance associated with the initialization.
        /// </summary>
        public IAzureMapsInterop? MapsInterop { get; }

        /// <summary>
        /// Gets a value indicating whether the initialization was successful.
        /// </summary>
        public bool Success => MapsInterop is not null;

        /// <summary>
        /// Gets the error that occurred during initialization, if any.
        /// </summary>
        public MapProviderError Error { get; set; }

        /// <summary>
        /// Gets the exception that occurred during initialization, if any.
        /// </summary>
        public Exception? Exception { get; }

        /// <summary>
        /// Gets a message describing the exception that occurred during initialization, if any.
        /// </summary>
        public string ExceptionMessage
        {
            get
            {
                return Error switch
                {
                    MapProviderError.AuthenticationFailed => $"{nameof(MapProvider)} authentication failed. {Exception?.Message}",
                    _ => $"{nameof(MapProvider)} creation failed. {Exception?.Message}",
                };
            }
        }
    }
}
