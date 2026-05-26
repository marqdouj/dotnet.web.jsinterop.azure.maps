using Marqdouj.DotNet.General;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using System.Reflection;

namespace Sandbox.UI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPositionFactory : IModelFactory, IStateModel
    {
        /// <summary>
        /// <inheritdoc cref="Position"/>
        /// </summary>
        Position? Model { get; set; }

        /// <summary>
        /// If true, a new model is created with elevation(3d).
        /// </summary>
        bool UseElevation { get; set; }
    }

    internal class PositionFactory<TSource> : StateModel, IPositionFactory where TSource : class
    {
        public PositionFactory(TSource source, string propertyName)
        {
            Source = source;
            Property = source.GetType().GetProperty(propertyName) ?? throw new ArgumentNullException(propertyName);

            if (Property.PropertyType != typeof(Position))
                throw new ArgumentException($"Property must be a '{typeof(Position).Name}'");

            Model = (Position?)Property.GetValue(Source);
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
        /// <inheritdoc cref="Position"/>
        /// </summary>
        public Position? Model { get; set => SetValue(ref field, value); }

        public bool CanAdd => Model is null;

        public bool CanDelete => Model is not null;

        public bool HasModel => Model is not null;

        public bool UseElevation { get; set; }

        public void AddModel()
        {
            Model = UseElevation ? new Position(0, 0, 0) : new Position(0, 0);
            Property.SetValue(Source, Model);
        }

        public void DeleteModel()
        {
            Model = null;
            Property.SetValue(Source, null);
        }
    }
}
