using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Represents all types of events that can be subscribed to.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventType>))]
    public enum MapEventType
    {
        //General
        BoxZoomEnd,
        BoxZoomStart,
        Drag,
        DragEnd,
        DragStart,
        /// <summary>
        /// Always subscribed.
        /// </summary>
        Error,
        Idle,
        KeyDown,
        KeyPress,
        KeyUp, 
        Load,
        Move,
        MoveEnd,
        MoveStart,
        Pitch,
        PitchEnd,
        PitchStart,
        /// <summary>
        /// Always subscribed.
        /// </summary>
        Ready,
        Render,
        Resize,
        Rotate,
        RotateEnd,
        RotateStart,
        TokenAcquired,
        Zoom,
        ZoomEnd,
        ZoomStart,

        //Animations
        OnComplete,
        OnFrame,
        OnProgress,

        //Config
        MapConfigurationChanged,

        //Data
        Data,
        SourceData,
        StyleData,

        //datasource
        /// <summary>
        /// Applies to target Data only.
        /// </summary>
        DataSourceUpdated,
        /// <summary>
        /// Applies to target datasource only.
        /// </summary>
        DataAdded,
        /// <summary>
        /// Applies to target datasource only.
        /// </summary>
        DataRemoved,

        //layer
        /// <summary>
        /// This event must be subscribed to when creating the layer.
        /// Once the layer has been added to the map, this event will not fire.
        /// </summary>
        LayerAdded,
        LayerRemoved,

        //Mouse
        Click,
        ContextMenu,
        DblClick,
        MouseDown,
        /// <summary>
        /// Applies to target layer only.
        /// </summary>
        MouseEnter,
        /// <summary>
        /// Applies to target layer only.
        /// </summary>
        MouseLeave,
        MouseMove,
        MouseOut,
        MouseOver,
        MouseUp,
        Wheel,

        //popup
        /// <summary>
        /// Applies to target Popup only.
        /// </summary>
        Open,
        /// <summary>
        /// Applies to target popup only.
        /// </summary>
        Close,

        //source
        SourceAdded,
        SourceRemoved,

        //shape
        /// <summary>
        /// Applies to target Shape only.
        /// </summary>
        ShapeChanged,

        //style
        StyleChanged,
        StyleImageMissing,
        /// <summary>
        /// Applies to target stylecontrol only.
        /// </summary>
        StyleSelected,

        //Touch
        TouchCancel,
        TouchEnd,
        TouchMove,
        TouchStart
    }

    /// <summary>
    /// Enum that represents all MapEventType's that apply to MapEventTarget.map. Castable to MapEventType.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTypeMap>))]
    public enum MapEventTypeMap
    {
        //Config
        MapConfigurationChanged = MapEventType.MapConfigurationChanged,

        //Data
        Data = MapEventType.Data,
        SourceData = MapEventType.SourceData,
        StyleData = MapEventType.StyleData,

        //General
        BoxZoomEnd = MapEventType.BoxZoomEnd,
        BoxZoomStart = MapEventType.BoxZoomStart,
        Drag = MapEventType.Drag,
        DragEnd = MapEventType.DragEnd,
        DragStart = MapEventType.DragStart,
        Idle = MapEventType.Idle,
        Load = MapEventType.Load,
        Move = MapEventType.Move,
        MoveEnd = MapEventType.MoveEnd,
        MoveStart = MapEventType.MoveStart,
        Pitch = MapEventType.Pitch,
        PitchEnd = MapEventType.PitchEnd,
        PitchStart = MapEventType.PitchStart,
        Render = MapEventType.Render,
        Resize = MapEventType.Resize,
        Rotate = MapEventType.Rotate,
        RotateEnd = MapEventType.RotateEnd,
        RotateStart = MapEventType.RotateStart,
        TokenAcquired = MapEventType.TokenAcquired,
        Zoom = MapEventType.Zoom,
        ZoomEnd = MapEventType.ZoomEnd,
        ZoomStart = MapEventType.ZoomStart,

        //layer
        LayerAdded = MapEventType.LayerAdded,
        LayerRemoved = MapEventType.LayerRemoved,

        //Mouse
        Click = MapEventType.Click,
        ContextMenu = MapEventType.ContextMenu,
        DblClick = MapEventType.DblClick,
        MouseDown = MapEventType.MouseDown,
        MouseMove = MapEventType.MouseMove,
        MouseOut = MapEventType.MouseOut,
        MouseOver = MapEventType.MouseOver,
        MouseUp = MapEventType.MouseUp,
        Wheel = MapEventType.Wheel,

        //source
        SourceAdded = MapEventType.SourceAdded,
        SourceRemoved = MapEventType.SourceRemoved,

        //style
        StyleChanged = MapEventType.StyleChanged,
        StyleImageMissing = MapEventType.StyleImageMissing,

        //Touch
        TouchCancel = MapEventType.TouchCancel,
        TouchEnd = MapEventType.TouchEnd,
        TouchMove = MapEventType.TouchMove,
        TouchStart = MapEventType.TouchStart,
    }

    /// <summary>
    /// Subset of MapEventType that applies to animations. Castable to MapEventType.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTypeAnimation>))]
    public enum MapEventTypeAnimation
    {
        OnComplete = MapEventType.OnComplete,
        OnFrame = MapEventType.OnFrame,
        OnProgress = MapEventType.OnProgress,
    }

    /// <summary>
    /// Subset of MapEventType that applies to MapEventTarget.datasource. Castable to MapEventType.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTypeDataSource>))]
    public enum MapEventTypeDataSource
    {
        DataSourceUpdated = MapEventType.DataSourceUpdated,
        DataAdded = MapEventType.DataAdded,
        DataRemoved = MapEventType.DataRemoved,
    }

    /// <summary>
    /// Subset of MapEventType that applies to MapEventTarget.layer. Castable to MapEventType.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTypeLayer>))]
    public enum MapEventTypeLayer
    {
        LayerAdded = MapEventType.LayerAdded,
        LayerRemoved = MapEventType.LayerRemoved,

        Click = MapEventType.Click,
        ContextMenu = MapEventType.ContextMenu,
        DblClick = MapEventType.DblClick,
        MouseDown = MapEventType.MouseDown,
        MouseEnter = MapEventType.MouseEnter,
        MouseLeave = MapEventType.MouseLeave,
        MouseMove = MapEventType.MouseMove,
        MouseOut = MapEventType.MouseOut,
        MouseOver = MapEventType.MouseOver,
        MouseUp = MapEventType.MouseUp,

        TouchCancel = MapEventType.TouchCancel,
        TouchEnd = MapEventType.TouchEnd,
        TouchMove = MapEventType.TouchMove,
        TouchStart = MapEventType.TouchStart,

        Wheel = MapEventType.Wheel,
    }

    /// <summary>
    /// Subset of MapEventType that applies to MapEventTarget.htmlmarker. Castable to MapEventType.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTypeHtmlMarker>))]
    public enum MapEventTypeHtmlMarker
    {
        Click = MapEventType.Click,
        ContextMenu = MapEventType.ContextMenu,
        DblClick = MapEventType.DblClick,
        MouseDown = MapEventType.MouseDown,
        MouseEnter = MapEventType.MouseEnter,
        MouseLeave = MapEventType.MouseLeave,
        MouseMove = MapEventType.MouseMove,
        MouseOut = MapEventType.MouseOut,
        MouseOver = MapEventType.MouseOver,
        MouseUp = MapEventType.MouseUp,

        Drag = MapEventType.Drag,
        DragEnd = MapEventType.DragEnd,
        DragStart = MapEventType.DragStart,

        KeyDown = MapEventType.KeyDown,
        KeyPress = MapEventType.KeyPress,
        KeyUp = MapEventType.KeyUp,
    }

    /// <summary>
    /// Subset of MapEventType that applies to MapEventTarget.popup. Castable to MapEventType.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTypePopup>))]
    public enum MapEventTypePopup
    {
        Drag = MapEventType.Drag,
        DragEnd = MapEventType.DragEnd,
        DragStart = MapEventType.DragStart,
        Open = MapEventType.Open,
        Close = MapEventType.Close,
    }

    /// <summary>
    /// Subset of MapEventType that applies to MapEventTarget.shape. Castable to MapEventType.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTypeShape>))]
    public enum MapEventTypeShape
    {
        ShapeChanged = MapEventType.ShapeChanged,
    }

    /// <summary>
    /// Subset of MapEventType that applies to MapEventTarget.stylecontrol. Castable to MapEventType.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTypeStyleControl>))]
    public enum MapEventTypeStyleControl
    {
        StyleSelected = MapEventType.StyleSelected,
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
