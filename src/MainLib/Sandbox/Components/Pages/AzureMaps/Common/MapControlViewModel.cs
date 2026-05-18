using Marqdouj.DotNet.General.CsDoc;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls;
using System.Collections.ObjectModel;

namespace Sandbox.Components.Pages.AzureMaps.Common
{
    /// <summary>
    /// Collection of MapControlEventsViewModel.
    /// </summary>
    public class MapControlViewModels : ICloneable
    {
        private readonly List<MapControlViewModel> viewModels = [];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapControls"></param>
        /// <param name="selected"></param>
        public MapControlViewModels(IEnumerable<ControlBase> mapControls, bool selected = default)
            : this(mapControls.Select(e => new MapControlViewModel(e, selected)).OrderBy(e => e.Control.SortOrder).ThenBy(e => e.Name))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModels"></param>
        public MapControlViewModels(IEnumerable<MapControlViewModel> viewModels)
        {
            this.viewModels.AddRange(viewModels);
            Items = new ReadOnlyCollection<MapControlViewModel>(this.viewModels);
        }

        /// <summary>
        /// The MapControlViewModels in the collection.
        /// </summary>
        public IReadOnlyList<MapControlViewModel> Items { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new MapControlViewModels(Items.Select(e => (MapControlViewModel)e.Clone()));
        }

        /// <summary>
        /// Gets the selected view models, ordered by SortOrder then Name.
        /// </summary>
        /// <returns></returns>
        public List<MapControlViewModel> GetSelected() => [.. viewModels.Where(e => e.IsSelected).OrderBy(e => e.Control.SortOrder).ThenBy(e => e.Name)];

        /// <summary>
        /// Gets the MapControls for the selected view models.
        /// </summary>
        /// <returns></returns>
        public List<ControlBase> GetSelectedControls() => [.. GetSelected().Select(e => e.Control)];

        /// <summary>
        /// Gets the view models that are not selected, ordered by SortOrder then Name.
        /// </summary>
        /// <returns></returns>
        public List<MapControlViewModel> GetUnselected() => [.. viewModels.Where(e => !e.IsSelected).OrderBy(e => e.Control.SortOrder).ThenBy(e => e.Name)];

        /// <summary>
        /// Gets the MapControls for the view models that are not selected.
        /// </summary>
        /// <returns></returns>
        public List<ControlBase> GetUnselectedControls() => [.. GetUnselected().Select(e => e.Control)];

        /// <summary>
        /// Selected/Unselects all models based on the 'selected' parameter.
        /// </summary>
        /// <param name="selected"></param>
        public void SelectAll(bool selected)
        {
            foreach (var model in viewModels)
                model.IsSelected = selected;
        }

        /// <summary>
        /// Update the controls with changes from the view model.
        /// </summary>
        public void UpdateControls()
        {
            foreach (var model in viewModels)
                model.UpdateControl();
        }
    }

    /// <summary>
    /// ViewModel for working with a MapControl.
    /// </summary>
    /// <param name="control"></param>
    /// <param name="selected"></param>
    public class MapControlViewModel(ControlBase control, bool selected = default) : ICloneable
    {

        /// <summary>
        /// The associated MapControl.
        /// </summary>
        public ControlBase Control { get; } = control;

        /// <summary>
        /// Name to display for the control.
        /// </summary>
        public string Name => string.IsNullOrEmpty(NameAlias) ? Control.Type.GetDisplayName()! : NameAlias;

        /// <summary>
        /// Alias to override Name display.
        /// </summary>
        public string? NameAlias { get; set; } = control.GetType().GetDisplayName(false);

        /// <summary>
        /// Flag to indicate the view model was selected.
        /// </summary>
        public bool IsSelected { get; set; } = selected;

        internal OptionsBase? Options { get; set; } = (OptionsBase?)(control.GetOptions()?.Clone()) ?? control.CreateOptions();
        internal int SortOrder { get; set; } = control.SortOrder;
        internal MapControlPosition? Position { get; set; } = control.ControlOptions?.Position;
        internal bool IsActiveRow { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = (MapControlViewModel)MemberwiseClone();
            clone.Options = (OptionsBase?)Options?.Clone();

            return clone;
        }

        /// <summary>
        /// Update the control with changes from the view model.
        /// </summary>
        public void UpdateControl()
        {
            Control.SortOrder = SortOrder;
            Control.SetOptions(Options);

            if (Position != null)
                Control.ControlOptions ??= new();

            Control.ControlOptions?.Position = Position;
        }
    }
}
