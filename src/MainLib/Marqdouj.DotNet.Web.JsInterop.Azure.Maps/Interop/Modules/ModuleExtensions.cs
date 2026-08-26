using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    internal enum JsModule
    {
        Animations,
        Atlas,
        Common,
        Configuration,
        Controls,
        Events,
        Factory,
        Features,
        Geolocations,
        Sprites,
        Layers,
        Markers,
        Mercators,
        Popups,
        Sources,
        SpatialLayers,
        SpatialSources,
    }

    internal static class ModuleExtensions
    {
        internal static string GetJsModuleMethod(this JsModule module, [CallerMemberName] string name = "")
            => $"{module}.{name.ToJsonName()}";

        /// <summary>
        /// first char must be lowercase
        /// </summary>
        internal static string ToJsonName(this string name)
        {
            var firstChar = name[0].ToString().ToLower();
            var remainder = name.Substring(1);
            return $"{firstChar}{remainder}";
        }
    }
}
