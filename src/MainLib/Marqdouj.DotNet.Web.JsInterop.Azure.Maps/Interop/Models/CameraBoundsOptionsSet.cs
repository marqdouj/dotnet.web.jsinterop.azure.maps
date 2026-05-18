using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models
{
    /// <summary>
    /// Includes additional options for the CameraBounds that are only used when setting/updating the map bounds after the map has been created.
    /// </summary>
    public class CameraBoundsOptionsSet : CameraBoundsOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public CameraBoundsOptionsSet()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapOptions"></param>
        public CameraBoundsOptionsSet(MapOptions? mapOptions) : this(mapOptions?.Camera, mapOptions?.CameraBounds) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="cameraBounds"></param>
        public CameraBoundsOptionsSet(CameraOptions? camera, CameraBoundsOptions? cameraBounds)
        {
            if (cameraBounds is not null)
            {
                foreach (var property in typeof(CameraBoundsOptions).GetProperties())
                {
                    if (property.CanWrite)
                        property.SetValue(this, property.GetValue(cameraBounds));
                }
            }

            Bearing = camera?.Bearing;
            Pitch = camera?.Pitch;
        }

        #region Setting Only

        /// <summary>
        /// <inheritdoc cref="CameraOptions.Bearing"/>.
        /// </summary>
        /// <remarks>This value is used when setting/updating the map bounds after the map has been created.</remarks>
        public double? Bearing { get; set; }

        /// <summary>
        /// <inheritdoc cref="CameraOptions.Pitch"/>
        /// </summary>
        /// <remarks>This value is used when setting/updating the map bounds after the map has been created.</remarks>
        public double? Pitch { get; set; }

        #endregion
    }
}
