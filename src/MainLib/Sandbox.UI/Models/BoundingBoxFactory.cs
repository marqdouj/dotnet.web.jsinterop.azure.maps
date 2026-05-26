using Marqdouj.DotNet.General;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using System.Reflection;

namespace Sandbox.UI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBoundingBoxFactory : IModelFactory, IStateModel
    {
        /// <summary>
        /// <inheritdoc cref="BoundingBox"/>
        /// </summary>
        BoundingBox? Model { get; set; }

        /// <summary>
        /// If true, a new model is created with elevation(3d).
        /// </summary>
        bool UseElevation { get; set; }
    }

    internal class BoundingBoxFactory<TSource> : StateModel, IBoundingBoxFactory where TSource : class
    {
        public BoundingBoxFactory(TSource source, string propertyName)
        {
            Source = source;
            Property = source.GetType().GetProperty(propertyName) ?? throw new ArgumentNullException(propertyName);

            if (Property.PropertyType != typeof(BoundingBox))
                throw new ArgumentException($"Property must be a '{typeof(BoundingBox).Name}'");

            Model = (BoundingBox?)Property.GetValue(Source);
            UseElevation = Model?.Is3D ?? false;
        }

        /// <summary>
        /// The class that contains the model.
        /// </summary>
        public TSource Source { get; }

        /// <summary>
        /// The property for the type model.
        /// </summary>
        public PropertyInfo Property { get; }

        /// <summary>
        /// <inheritdoc cref="BoundingBox"/>
        /// </summary>
        public BoundingBox? Model { get; set => SetValue(ref field, value); }

        public bool CanAdd => Model == null;

        public bool CanDelete => Model != null;

        public bool HasModel => Model != null;

        public bool UseElevation { get; set; }

        public void AddModel()
        {
            Model = UseElevation ? new BoundingBox(0, 0, 0, 0, 0, 0) : new BoundingBox(0, 0, 0, 0);
            Property.SetValue(Source, Model);
        }

        public void DeleteModel()
        {
            Model = null;
            Property.SetValue(Source, null);
        }
    }
}
