using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// Azure Maps supported built-in map styles
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapStyle>))]
    public enum MapStyle
    {
        /// <summary>
        /// Provides a blank canvas for visualizing data. 
        /// </summary>
        [Display(Name = "Blank")]
        blank,

        /// <summary>
        /// Provides a blank canvas for visualizing data. 
        /// This style continues to provide screen reader updates with map's location details, 
        /// even though the base map isn't displayed.
        /// </summary>
        [Display(Name = "Blank (Accessible)")]
        blank_accessible,

        /// <summary>
        /// A dark version of the road map style.
        /// </summary>
        [Display(Name = "Grayscale (dark)")]
        grayscale_dark,

        /// <summary>
        /// A light version of the road map style.
        /// </summary>
        [Display(Name = "Grayscale (light)")]
        grayscale_light,

        /// <summary>
        /// A dark map style with a higher contrast than the other styles.
        /// </summary>
        [Display(Name = "High contrast (dark)")]
        high_contrast_dark,

        /// <summary>
        /// A light map style with a higher contrast than the other styles.
        /// </summary>
        [Display(Name = "High contrast (light)")]
        high_contrast_light,

        /// <summary>
        /// A dark version of the road map style with colored roads and symbols.
        /// </summary>
        [Display(Name = "Night")]
        night,

        /// <summary>
        /// A standard map that displays roads. It also displays natural and artificial features, and the labels for those features.
        /// </summary>
        [Display(Name = "Road")]
        road,

        /// <summary>
        /// An Azure Maps main style completed with contours of the Earth.
        /// </summary>
        [Display(Name = "Terra")]
        road_shaded_relief,

        /// <summary>
        /// A combination of satellite and aerial imagery.
        /// </summary>
        [Display(Name = "Satellite")]
        satellite,

        /// <summary>
        /// A hybrid of roads and labels overlaid on top of satellite and aerial imagery.
        /// </summary>
        [Display(Name = "Hybrid")]
        satellite_road_labels
    }

    /// <summary>
    /// The options for the map's style.
    /// </summary>
    [Display(Name = "style")]
    public class StyleOptions : OptionsBase
    {
        /// <summary>
        /// If true, the gl context will be created with MSAA antialiasing, which can be useful for antialiasing WebGL layers.
        /// </summary>
        public bool? Antialias { get; set; }

        /// <summary>
        /// If true the map will automatically resize whenever the window's size changes.
        /// Otherwise map.resize() must be called.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "auto Resize")]
        public bool? AutoResize { get; set; }

        /// <summary>
        /// The language of the map labels.
        /// [Supported language](https://docs.microsoft.com/en-us/azure/azure-maps/supported-languages).
        /// Default 'atlas.getLanguage()'.
        /// If set to "auto", the browser's preferred language will be used.
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// <see cref="LightOptions"/>
        /// </summary>
        public LightOptions? Light { get; set; }

        /// <summary>
        /// If true, the map's canvas can be exported to a PNG using map.getCanvas().toDataURL().
        /// This option may only be set when initializing the map.
        /// Default 'false'.
        /// </summary>
        [Display(Name = "Preserve Drawing Buffer")]
        public bool? PreserveDrawingBuffer { get; set; }

        /// <summary>
        /// If true, the map will try to defer non-essential map layers and show essential layers as early as possible.
        /// This option may only be set when initializing the map.
        /// Default 'false'.
        /// </summary>
        [Display(Name = "Progressive Loading")]
        public bool? ProgressiveLoading { get; set; }

        /// <summary>
        /// The list of layer groups to be loaded at the initial stage. Passing an empty array will disable the progressive loading.
        /// This option may only be set when initializing the map.
        /// Default `['base']`
        /// </summary>
        [Display(Name = "layer Groups")]
        public StringOptions? ProgressiveLoadingInitialLayerGroups { get; set; }

        /// <summary>
        /// Specifies if multiple copies of the world should be rendered when zoomed out.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Render World Copies")]
        public bool? RenderWorldCopies { get; set; }

        /// <summary>
        /// Specifies if the feedback link should be displayed on the map or not.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Show Feedback Link")]
        public bool? ShowFeedbackLink { get; set; }

        /// <summary>
        /// Specifies if the Microsoft logo should be hidden or not.
        /// If set to true a Microsoft copyright string will be added to the map.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Show Logo")]
        public bool? ShowLogo { get; set; }

        /// <summary>
        /// Specifies if the map should display labels.
        /// Default true
        /// </summary>
        [Display(Name = "Show Labels")]
        public bool? ShowLabels { get; set; }

        /// <summary>
        /// Specifies if the map should render an outline around each tile and the tile ID.
        /// These tile boundaries are useful for debugging.
        /// The uncompressed file size of the first vector source is drawn in the top left corner of each tile,
        /// next to the tile ID.
        /// Default 'false'.
        /// </summary>
        [Display(Name = "Show Tile Boundaries")]
        public bool? ShowTileBoundaries { get; set; }

        /// <summary>
        /// The name of the style to use when rendering the map. Available styles can be found in the
        /// [supported styles](https://docs.microsoft.com/en-us/azure/azure-maps/supported-map-styles) article.
        /// Default 'road'.
        /// </summary>
        public MapStyle? Style { get; set; }

        /// <summary>
        /// Specifies which set of geopolitically disputed borders and labels are displayed on the map. 
        /// The View parameter (also referred to as “user region parameter”) is a 2-letter ISO-3166 Country Code that will 
        /// show the correct maps for that country/region. Country/Regions that are not on the View list or if unspecified 
        /// will default to the “Unified” View.
        /// Please see the supported [Views](https://aka.ms/AzureMapsLocalizationViews)
        /// It is your responsibility to determine the location of your users, and then set the View parameter correctly for that location. 
        /// The View parameter in Azure Maps must be used in compliance with applicable laws, including those regarding mapping, 
        /// of the country where maps, images and other data and third party content that You are authorized to access 
        /// via Azure Maps is made available.
        /// Default 'null'.
        /// </summary>
        public string? View { get; set; }

        /// <summary>
        /// Override the default styles for the map elements.​
        /// Default 'null'
        /// </summary>
        [Display(Name = "style Overrides")]
        public StyleOverrides? StyleOverrides { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (StyleOptions)MemberwiseClone();
            clone.Light = (LightOptions?)Light?.Clone();
            clone.ProgressiveLoadingInitialLayerGroups = (StringOptions?)ProgressiveLoadingInitialLayerGroups?.Clone();
            clone.StyleOverrides = (StyleOverrides?)StyleOverrides?.Clone();

            return clone;
        }
    }
}
