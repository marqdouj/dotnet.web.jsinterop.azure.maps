using Marqdouj.DotNet.Web.JsInterop.GeoJson;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models
{
    internal static class ModelExtensions
    {
        internal static void EnsureCount(this List<double> items, int min, int? max = null, double addDefault = 0)
        {
            while (items.Count < min)
            {
                items.Add(addDefault);
            }

            //Remove excess values
            if (max != null)
            {
                while (items.Count > max)
                {
                    items.RemoveAt(items.Count - 1);
                }
            }
        }

        internal static void EnsureCount(this List<Position> items, int min, int? max = null)
        {
            while (items.Count < min)
            {
                items.Add(new Position(0, 0));
            }

            //Remove excess values
            if (max != null)
            {
                while (items.Count > max)
                {
                    items.RemoveAt(items.Count - 1);
                }
            }
        }
    }
}
