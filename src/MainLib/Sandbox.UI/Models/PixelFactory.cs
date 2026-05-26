using Marqdouj.DotNet.General;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using System.Reflection;

namespace Sandbox.UI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPixelFactory : IModelFactory, IStateModel
    {
        /// <summary>
        /// <inheritdoc cref="Pixel"/>
        /// </summary>
        Pixel? Model { get; set; }
    }

    internal class PixelFactory<TSource> : StateModel, IPixelFactory where TSource : class
    {
        public PixelFactory(TSource source, string propertyName)
        {
            Source = source;
            Property = source.GetType().GetProperty(propertyName) ?? throw new ArgumentNullException(propertyName);

            if (Property.PropertyType != typeof(Pixel))
                throw new ArgumentException($"Property must be a '{typeof(Pixel).Name}'");

            Model = (Pixel?)Property.GetValue(Source);
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
        /// <inheritdoc cref="Pixel"/>
        /// </summary>
        public Pixel? Model { get; set => SetValue(ref field, value); }

        public bool CanAdd => Model == null;

        public bool CanDelete => Model != null;

        public bool HasModel => Model != null;

        public void AddModel()
        {
            Model = new Pixel(0, 0);
            Property.SetValue(Source, Model);
        }

        public void DeleteModel()
        {
            Model = null;
            Property.SetValue(Source, null);
        }
    }
}
