#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Sandbox.UI.Models
{
    public enum MapSettingsDisplay
    {
        All,
        Camera,
        Service,
        Style,
        Traffic,
        UserInteraction,
    }

    internal static class MapSettingsTabExtensions
    {
        extension(MapSettingsDisplay tab)
        {
            public string GetTabId() => tab switch
            {
                MapSettingsDisplay.Camera => "tabCamera",
                MapSettingsDisplay.Service => "tabService",
                MapSettingsDisplay.Style => "tabStyle",
                MapSettingsDisplay.Traffic => "tabTraffic",
                MapSettingsDisplay.UserInteraction => "tabUserInteraction",
                _ => "tabCamera",
            };
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member