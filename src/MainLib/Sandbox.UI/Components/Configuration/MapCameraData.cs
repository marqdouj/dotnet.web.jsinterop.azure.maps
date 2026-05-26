using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.UI.Components.Configuration
{
    /// <summary>
    /// Indicates which type of camera options are being updated in the map. 
    /// The Camera and Camera Bounds are mutually exclusive; it's not possible to edit both at the same time in the map.
    /// </summary>
    public enum CameraDataType
    {
        /// <summary>
        /// Camera options are being configured. <inheritdoc cref="MapCameraData.Camera"/>
        /// </summary>
        Camera,

        /// <summary>
        /// Camera Bounds options are being configured. <inheritdoc cref="MapCameraData.CameraBounds"/>
        /// </summary>
        [Display(Name = "Camera Bounds")]
        CameraBounds
    }

    /// <summary>
    /// The MapCameraData class represents the data used to configure the camera settings in a map. 
    /// </summary>
    public class MapCameraData(MapOptions? options)
    {
        /// <summary>
        /// <inheritdoc cref="CameraDataType"/>
        /// </summary>
        internal CameraDataType DataType { get; set; }

        /// <summary>
        /// <inheritdoc cref="Animation"/>
        /// </summary>
        public AnimationOptions? Animation { get; set; }

        /// <summary>
        /// <inheritdoc cref="CameraOptions"/>
        /// </summary>
        public CameraOptions Camera { get; set; } = options?.Camera?.Clone() as CameraOptions ?? new CameraOptions();

        /// <summary>
        /// <inheritdoc cref="CameraBoundsOptionsSet"/>
        /// </summary>
        public CameraBoundsOptionsSet CameraBounds { get; set; } = new CameraBoundsOptionsSet(options);

        internal void Reset()
        {
            Animation = null;
            Camera = new();
            CameraBounds = new();
        }

        /// <summary>
        /// Updates the given MapOptionsEdit instance to represent the current edit settings.
        /// </summary>
        internal void UpdateMapOptionsEdit(MapOptionsEdit options)
        {
            options.Animation = Animation;
            options.Camera = DataType == CameraDataType.Camera ? Camera : null;
            options.CameraBounds = DataType == CameraDataType.CameraBounds ? CameraBounds : null;
        }

        /// <inheritdoc/>
        override public string ToString()
        {
            return DataType switch
            {
                CameraDataType.Camera => $"DataType: Camera",
                CameraDataType.CameraBounds => $"DataType: Camera Bounds",
                _ => "Unknown Camera Data Type"
            };
        }
    }
}
