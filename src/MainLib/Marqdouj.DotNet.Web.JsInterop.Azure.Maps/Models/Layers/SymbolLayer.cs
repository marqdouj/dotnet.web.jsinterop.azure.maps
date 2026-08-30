using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Converters;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers.Images;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// <inheritdoc cref="LayerType.Symbol"/>
    /// </summary>
    public class SymbolLayer : LayerBase<SymbolLayerOptions>
    {
        /// <summary>
        /// <inheritdoc cref="LayerType"/>
        /// </summary>
        public override LayerType Type => LayerType.Symbol;

        /// <summary>
        /// <inheritdoc cref="SymbolLayerOptions"/>
        /// </summary>
        public override SymbolLayerOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (SymbolLayer)MemberwiseClone();
            clone.Options = (SymbolLayerOptions?)Options?.Clone();
            return clone;
        }
    }

    /// <summary>
    /// Options used when rendering geometries in a SymbolLayer.
    /// </summary>
    public class SymbolLayerOptions : SourceLayerOptions
    {
        /// <summary>
        /// <see cref="SymbolIconOptions"/>
        /// </summary>
        public SymbolIconOptions? IconOptions { get; set; } = new();

        /// <summary>
        /// <see cref="SymbolTextOptions"/>
        /// </summary>
        public SymbolTextOptions? TextOptions { get; set; } = new();

        /// <summary>
        /// <see cref="SymbolLayerPlacement"/>
        /// Default 'point'.
        /// </summary>
        public SymbolLayerPlacement? Placement { get; set; }

        /// <summary>
        /// Sorts features in ascending order based on this value. Features with
        /// lower sort keys are drawn and placed first.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default 'null'.
        /// </summary>
        public object? SortKey { get; set; }

        /// <summary>
        /// <see cref="SymbolLayerZOrder"/>
        /// Default 'auto'.
        /// </summary>
        public SymbolLayerZOrder? ZOrder { get; set; }

        /// <summary>
        /// Distance in pixels between two symbol anchors along a line. Must be greater or equal to 1.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '250'.
        /// </summary>
        public object? LineSpacing { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (SymbolLayerOptions)MemberwiseClone();
            clone.IconOptions = (SymbolIconOptions?)IconOptions?.Clone();
            clone.TextOptions = (SymbolTextOptions?)TextOptions?.Clone();

            return clone;
        }
    }

    #region Enums
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Specifies the label placement relative to its geometry.
    /// "point": The label is placed at the point where the geometry is located.
    /// "line": The label is placed along the line of the geometry.
    /// Can only be used on LineString and Polygon geometries.
    /// "line-center": The label is placed at the center of the line of the geometry.
    /// Can only be used on 'LineString' and 'Polygon' geometries 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<SymbolLayerPlacement>))]
    public enum SymbolLayerPlacement
    {
        [Display(Name = "Point")] point,
        [Display(Name = "Line")] line,
        [Display(Name = "Line Center")] linecenter,
    }

    /// <summary>
    /// Determines whether overlapping symbols in the same layer are rendered in the order
    /// that they appear in the data source, or by their y position relative to the viewport.
    /// To control the order and prioritization of symbols otherwise, use sortKey.
    /// "auto": Sorts symbols by sortKey if set. Otherwise behaves like "viewport-y".
    /// "viewport-y": Sorts symbols by their y position if allowOverlap is true or
    /// if ignorePlacement is false.
    /// "source": Sorts symbols by sortKey if set. Otherwise, symbols are rendered in the
    /// same order as the source data.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<SymbolLayerZOrder>))]
    public enum SymbolLayerZOrder
    {
        [Display(Name = "Auto")] auto,
        [Display(Name = "Viewport Y")] viewport_y,
        [Display(Name = "Source")] source,
    }

    [JsonConverter(typeof(JsonStringEnumConverter<SymbolItemAlignment>))]
    public enum SymbolItemAlignment
    {
        [Display(Name = "Auto")] auto,
        [Display(Name = "Map")] map,
        [Display(Name = "Viewport")] viewport,
    }

    [JsonConverter(typeof(MapEnumJsonConverter<SymbolPositionAnchor>))]
    public enum SymbolPositionAnchor
    {
        Center,
        Top,
        Bottom,
        Left,
        Right,
        [Display(Name = "Top Left")] Top_Left,
        [Display(Name = "Top Right")] Top_Right,
        [Display(Name = "Bottom Left")] Bottom_Left,
        [Display(Name = "Bottom Right")] Bottom_Right,
    }

    [JsonConverter(typeof(MapEnumJsonConverter<SymbolIconImage>))]
    public enum SymbolIconImage
    {
        [Display(Name = "Marker Black")] Marker_Black,
        [Display(Name = "Marker Blue")] Marker_Blue,
        [Display(Name = "Marker Dark Blue")] Marker_DarkBlue,
        [Display(Name = "Marker Red")] Marker_Red,
        [Display(Name = "Marker Yellow")] Marker_Yellow,
        [Display(Name = "Pin Blue")] Pin_Blue,
        [Display(Name = "Pin Dark Blue")] Pin_DarkBlue,
        [Display(Name = "Pin Red")] Pin_Red,
        [Display(Name = "Pin Round Blue")] Pin_Round_Blue,
        [Display(Name = "Pin Round Dark Blue")] Pin_Round_DarkBlue,
        [Display(Name = "Pin Round Red")] Pin_Round_Red
    }

    [JsonConverter(typeof(JsonStringEnumConverter<SymbolTextJustify>))]
    public enum SymbolTextJustify
    {
        /// <summary>
        /// The text is aligned towards the anchor position.
        /// </summary>
        Auto,

        /// <summary>
        /// The text is aligned to the left.
        /// </summary>
        Left,

        /// <summary>
        /// The text is centered.
        /// </summary>
        Center,

        /// <summary>
        /// The text is aligned to the right.
        /// </summary>
        Right
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    #endregion

    /// <summary>
    /// Options used to customize the icons in a SymbolLayer
    /// </summary>
    public class SymbolIconOptions : ICloneable
    {
        /// <summary>
        /// Specifies if the symbol icon can overlay other symbols on the map.
        /// If true, the icon will be visible even if it collides with other previously drawn symbols.
        /// Tip: Set this to true if animating an symbol to ensure smooth rendering.
        /// Default 'false'.
        /// </summary>
        public bool? AllowOverlap { get; set; }

        /// <summary>
        /// Specifies which part of the icon is placed closest to the icons anchor position on the map.
        /// "center": The center of the icon is placed closest to the anchor.
        /// "left": The left side of the icon is placed closest to the anchor.
        /// "right": The right side of the icon is placed closest to the anchor.
        /// "top": The top of the icon is placed closest to the anchor.
        /// "bottom": The bottom of the icon is placed closest to the anchor.
        /// "top-left": The top left corner of the icon is placed closest to the anchor.
        /// "top-right": The top right corner of the icon is placed closest to the anchor.
        /// "bottom-left": The bottom left corner of the icon is placed closest to the anchor.
        /// "bottom-right": The bottom right corner of the icon is placed closest to the anchor.
        /// SymbolPositionAnchor or DataDrivenPropertyValueSpecification.
        /// Default 'bottom'.
        /// </summary>
        public object? Anchor { get; set; }

        /// <summary>
        /// Specifies if other symbols can overlap this symbol.
        /// If true, other symbols can be visible even if they collide with the icon.
        /// Default 'false'.
        /// </summary>
        public bool? IgnorePlacement { get; set; }

        /// <summary>
        /// The name of the image in the map's image sprite to use for drawing the icon.
        /// SymbolIconImage/String or DataDrivenPropertyValueSpecification.
        /// Default 'marker-blue'.
        /// </summary>
        public object? Image { get; set; }

        /// <summary>
        /// Override <see cref="Image"/> and use an id associated with a custom image template <see cref="ImageTemplate"/>.
        /// </summary>
        public string? ImageId { get; set; }

        /// <summary>
        /// Specifies an offset distance of the icon from its anchor in pixels.
        /// Positive values indicate right and down, while negative values indicate left and up.
        /// Each component is multiplied by the value of size to obtain the final offset in pixels.
        /// When combined with rotation the offset will be as if the rotated direction was up.
        /// Pixel or DataDrivenPropertyValueSpecification.
        /// Default '[0, 0]'.
        /// </summary>
        public object? Offset { get; set; }

        /// <summary>
        /// Specifies if a symbols icon can be hidden but its text displayed if it is overlapped with another symbol.
        /// If true, text will display without their corresponding icons
        /// when the icon collides with other symbols and the text does not.
        /// Default 'false'.
        /// </summary>
        public bool? Optional { get; set; }

        /// <summary>
        /// Size of the additional area around the icon bounding box used for detecting symbol collisions.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '2'.
        /// </summary>
        public object? Padding { get; set; }

        /// <summary>
        /// Specifies the orientation of the icon when the map is pitched.
        /// "auto": Automatically matches the value of 'rotationAlignment'.
        /// "map": The icon is aligned to the plane of the map.
        /// "viewport": The icon is aligned to the plane of the viewport
        /// Default 'auto'.
        /// </summary>
        public SymbolItemAlignment? PitchAlignment { get; set; }

        /// <summary>
        /// The amount to rotate the icon clockwise in degrees.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '0'.
        /// </summary>
        public object? Rotation { get; set; }

        /// <summary>
        /// Rotation specification applied to the object.
        /// Represents DataDrivenPropertyValueSpecification[number].
        /// Overrides <see cref="Rotation"/>
        /// </summary>
        public object? RotationSpecification { get; set; }

        /// <summary>
        /// In combination with the placement property of a SymbolLayerOptions
        /// this determines the rotation behavior of icons.
        /// "auto": When placement is "point" this is equivalent to "viewport".
        /// When placement is "line" this is equivalent to "map".
        /// "map": When placement is "point" aligns icons east-west.
        /// When placement is "line" aligns the icons' x-axes with the line.
        /// "viewport": icons' x-axes will align with the x-axis of the viewport.
        /// Default 'auto'.
        /// </summary>
        public SymbolItemAlignment? RotationAlignment { get; set; }

        /// <summary>
        /// Scales the original size of the icon by the provided factor.
        /// Must be greater or equal to 0.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '1'.
        /// </summary>
        public object? Size { get; set; }

        /// <summary>
        /// A number between 0 and 1 that indicates the opacity at which the icon will be drawn.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '1'.
        /// </summary>
        public object? Opacity { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = (SymbolIconOptions)MemberwiseClone();
            if (clone.Offset is Pixel offset)
                clone.Offset = offset?.Clone();

            return clone;
        }
    }

    /// <summary>
    /// Options used to customize the text in a SymbolLayer
    /// </summary>
    public class SymbolTextOptions : ICloneable
    {
        /// <summary>
        /// Specifies if the text will be visible if it collides with other symbols.
        /// If true, the text will be visible even if it collides with other previously drawn symbols.
        /// Default 'false'.
        /// </summary>
        public bool? AllowOverlap { get; set; }

        /// <summary>
        /// Specifies which part of the icon is placed closest to the icons anchor position on the map.
        /// SymbolPositionAnchor or DataDrivenPropertyValueSpecification.
        /// Default 'center'.
        /// </summary>
        public object? Anchor { get; set; }

        /// <summary>
        /// Specifies the name of a property on the features to use for a text label.
        /// String or DataDrivenPropertyValueSpecification.
        /// </summary>
        public object? TextField { get; set; }

        /// <summary>
        /// List[string] or DataDrivenPropertyValueSpecification.
        /// Possible values: "SegoeFrutigerHelveticaMYingHei-Bold", "SegoeFrutigerHelveticaMYingHei-Medium",
        /// "SegoeFrutigerHelveticaMYingHei-Regular", "SegoeUi-Bold", "SegoeUi-light", "SegoeUi-Regular",
        /// "SegoeUi-SemiBold", "SegoeUi-SemiLight", "SegoeUi-SymbolRegular", "StandardCondensedSegoeUi-Black",
        /// "StandardCondensedSegoeUi-Bold", "StandardCondensedSegoeUi-light", "StandardCondensedSegoeUi-Regular",
        /// "StandardFont-Black", "StandardFont-Bold", "StandardFont-light", "StandardFont-Regular",
        /// "StandardFontCondensed-Black", "StandardFontCondensed-Bold", "StandardFontCondensed-light",
        /// "StandardFontCondensed-Regular".
        /// Default 'StandardFont-Regular'.
        /// </summary>
        public object? Font { get; set; }

        /// <summary>
        /// Specifies if the other symbols are allowed to collide with the text.
        /// If true, other symbols can be visible even if they collide with the text.
        /// Default 'false'.
        /// </summary>
        public bool? IgnorePlacement { get; set; }

        /// <summary>
        /// Text justification options.
        /// Default 'center'.
        /// </summary>
        public SymbolTextJustify? Justify { get; set; }

        /// <summary>
        /// Specifies an offset distance of the icon from its anchor in ems.
        /// Positive values indicate right and down, while negative values indicate left and up.
        /// Pixel or DataDrivenPropertyValueSpecification.
        /// Default '[0, 0]'. 
        /// </summary>
        public object? Offset { get; set; }

        /// <summary>
        /// Specifies if the text can be hidden if it is overlapped by another symbol.
        /// If true, icons will display without their corresponding text
        /// when the text collides wit other symbols and the icon does not.
        /// Default 'false'.
        /// </summary>
        public bool? Optional { get; set; }

        /// <summary>
        /// Size of the additional area around the text bounding box used for detecting symbol collisions.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '2'.
        /// </summary>
        public object? Padding { get; set; }

        /// <summary>
        /// Specifies the orientation of the text when the map is pitched.
        /// "auto": Automatically matches the value of 'rotationAlignment'.
        /// "map": The text is aligned to the plane of the map.
        /// "viewport": The text is aligned to the plane of the viewport.
        /// Default: 'auto'.
        /// </summary>
        public SymbolItemAlignment? PitchAlignment { get; set; }

        /// <summary>
        /// Radial offset of text, in the direction of the symbol's anchor. Useful in combination
        /// with 'variableAnchor', which defaults to using the two-dimensional 'offset' if present.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default: '0'.
        /// </summary>
        public object? RadialOffset { get; set; }

        /// <summary>
        /// The amount to rotate the text clockwise in degrees.
        /// Number or DataDrivenPropertyValueSpecification.
        ///  Default '0'.
        /// </summary>
        public object? Rotation { get; set; }

        /// <summary>
        /// In combination with the 'placement' property of the 'SymbolLayerOptions',
        /// specifies the rotation behavior of the individual glyphs forming the text.
        /// "auto": When the 'placement' is set to "point", this is equivalent to "map".
        /// When the 'placement' is set to "line" this is equivalent to "map".
        /// "map": When the 'placement' is set to "point", aligns text east-west.
        /// When the 'placement' is set to "line", aligns text x-axes with the line.
        /// "viewport": Produces glyphs whose x-axes are aligned with the x-axis of the viewport,
        /// regardless of the value of 'placement'.
        /// Default: 'auto'
        /// </summary>
        public SymbolItemAlignment? RotationAlignment { get; set; }

        /// <summary>
        /// list of potential anchor locations, to increase the chance of placing high-priority
        /// labels on the map. The renderer will attempt to place the label at each location,
        /// in order, before moving onto the next label. Use 'justify: "auto" to choose text
        /// justification based on anchor position. To apply an offset use the 'radialOffset' or
        /// two-dimensional 'offset' options.
        /// "center": The center of the icon is placed closest to the anchor.
        /// "left": The left side of the icon is placed closest to the anchor.
        /// "right": The right side of the icon is placed closest to the anchor.
        /// "top": The top of the icon is placed closest to the anchor.
        /// "bottom": The bottom of the icon is placed closest to the anchor.
        /// "top-left": The top left corner of the icon is placed closest to the anchor.
        /// "top-right": The top right corner of the icon is placed closest to the anchor.
        /// "bottom-left": The bottom left corner of the icon is placed closest to the anchor.
        /// "bottom-right": The bottom right corner of the icon is placed closest to the anchor.
        /// Default: 'null'.
        /// </summary>
        public List<SymbolPositionAnchor>? VariableAnchor { get; set; }

        /// <summary>
        /// The size of the font in pixels.
        /// Must be a number greater or equal to 0.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '16'.
        /// </summary>
        public object? Size { get; set; }

        /// <summary>
        /// The color of the text.
        /// String or DataDrivenPropertyValueSpecification.
        /// Default '#000000'.
        /// </summary>
        public object? Color { get; set; }

        /// <summary>
        /// The halo's fadeout distance towards the outside in pixels.
        /// Must be a number greater or equal to 0.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '0'.
        /// </summary>
        public object? HaloBlur { get; set; }

        /// <summary>
        /// The color of the text's halo, which helps it stand out from backgrounds.
        /// String or DataDrivenPropertyValueSpecification.
        /// Default 'rgba(0,0,0,0)'.
        /// </summary>
        public object? HaloColor { get; set; }

        /// <summary>
        /// The distance of the halo to the font outline in pixels.
        /// Must be a number greater or equal to 0.
        /// The maximum text halo width is 1/4 of the font size.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '0'.
        /// </summary>
        public object? HaloWidth { get; set; }

        /// <summary>
        /// A number between 0 and 1 that indicates the opacity at which the text will be drawn.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '1'.
        /// </summary>
        public object? Opacity { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = (SymbolTextOptions)MemberwiseClone();
            if (clone.Font is ICloneable icFont)
                clone.Font = icFont.Clone();
            if (clone.Offset is Pixel offset)
                clone.Offset = offset?.Clone();
            clone.VariableAnchor = VariableAnchor?.ToList();
            return clone;
        }
    }
}
