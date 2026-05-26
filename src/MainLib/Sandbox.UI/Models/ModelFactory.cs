using Marqdouj.DotNet.General;
using System.Reflection;

namespace Sandbox.UI.Models
{
    /// <summary>
    /// This interface is for view models that can add or delete a model.
    /// </summary>
    public interface IModelFactory : IStateModel
    {
        /// <summary>
        /// Gets a value indicating whether a model can be added.
        /// </summary>
        bool CanAdd { get; }

        /// <summary>
        /// Gets a value indicating whether a model can be deleted.
        /// </summary>
        bool CanDelete { get; }

        /// <summary>
        /// Adds a model. The implementation should set the <see cref="CanAdd"/> and <see cref="CanDelete"/> properties accordingly.
        /// </summary>
        void AddModel();

        /// <summary>
        /// Deletes a model. The implementation should set the <see cref="CanAdd"/> and <see cref="CanDelete"/> properties accordingly.
        /// </summary>
        void DeleteModel();

        /// <summary>
        /// Indicates if a Model exists.
        /// </summary>
        bool HasModel { get; }
    }

    /// <summary>
    /// Typed version of <inheritdoc cref="IModelFactory"/>
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IModelFactory<TModel> : IModelFactory where TModel : class
    {
        /// <summary>
        /// <typeparamref name="TModel"/>
        /// </summary>
        TModel? Model { get; set; }
    }

    internal class ModelFactory<TSource, TModel> : StateModel, IModelFactory, IModelFactory<TModel> where TSource : class where TModel : class, new()
    {
        public ModelFactory(TSource source, string propertyName)
        {
            Source = source;
            Property = source.GetType().GetProperty(propertyName) ?? throw new ArgumentNullException(propertyName);

            if (Property.PropertyType != typeof(TModel))
                throw new ArgumentException($"Property must be a '{typeof(TModel).Name}'");

            Model = (TModel?)Property.GetValue(Source);
        }

        /// <summary>
        /// The class that contains the model.
        /// </summary>
        public TSource Source { get; }

        /// <summary>
        /// The property for the type <typeparamref name="TModel"/>.
        /// </summary>
        public PropertyInfo Property { get; }

        /// <summary>
        /// The model of type <typeparamref name="TModel"/>.
        /// </summary>
        public TModel? Model { get; set => SetValue(ref field, value); }

        public bool CanAdd => Model == null;

        public bool CanDelete => Model != null;

        public bool HasModel => Model != null;

        public virtual void AddModel()
        {
            Model = new TModel();
            Property.SetValue(Source, Model);
        }

        public virtual void DeleteModel()
        {
            Model = null;
            Property.SetValue(Source, null);
        }
    }
}
