using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using System.Text.Json;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Utilities
{
    /// <summary>
    /// Helper class for converting JsInterop.GeoJson objects to/from JsInterop.AzureMaps objects,
    /// and deserialization of these objects.
    /// </summary>
    public static class GeoJsonConvert
    {
        private static JsonSerializerOptions GetSerializerOptions(JsonNamingPolicy? namingPolicy = default, bool writeIndented = true)
        {
            return new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                PropertyNamingPolicy = namingPolicy,
                WriteIndented = writeIndented
            };
        }

        #region ToFeature

        /// <summary>
        /// Deserialize json string to a <see cref="Feature{G, P}"/>
        /// </summary>
        /// <typeparam name="G"><see cref="Geometry"/></typeparam>
        /// <param name="json"></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <returns></returns>
        public static Feature<G, Properties>? ToFeature<G>(this string? json, JsonNamingPolicy? namingPolicy = default) where G : Geometry
        {
            return string.IsNullOrWhiteSpace(json) ? null : Feature<G, Properties>.FromJson(json, GetSerializerOptions(namingPolicy));
        }

        /// <summary>
        /// Convert strongly typed Feature to generic type <see cref="Feature{G, P}"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="Geometry"/></typeparam>
        /// <param name="feature">strongly typed <see cref="Feature{G, P}"/></param>
        /// <returns></returns>
        public static Feature<Geometry, Properties>? ToFeature<T>(this Feature<T, Properties>? feature) where T : Geometry
        {
            return feature is null ? null : new Feature<Geometry, Properties>(feature.Geometry, feature.Properties, feature.Id, feature.Bbox);
        }

        /// <summary>
        /// Converts <see cref="MapFeature"/> to <see cref="Feature{G, P}"/>.
        /// </summary>
        /// <returns></returns>
        public static Feature<Geometry, Properties>? ToFeature(this MapFeature? feature)
        {
            return feature is null ? null : new Feature<Geometry, Properties>((Geometry)feature.Geometry, feature.Properties, feature.Id, feature.Bbox);
        }

        /// <summary>
        /// Converts <see cref="MapFeature"/> to a strongly typed <see cref="Feature{G, P}"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="Geometry"/></typeparam>
        /// <param name="feature"><see cref="MapFeature"/></param>
        /// <returns></returns>
        public static Feature<T, Properties>? ToFeature<T>(this MapFeature? feature) where T : Geometry
        {
            return feature is null ? null : new Feature<T, Properties>((T)feature.Geometry, feature.Properties, feature.Id, feature.Bbox);
        }

        #endregion

        #region ToFeatureCollection

        /// <summary>
        /// Deserializes json to a strongly typed <see cref="FeatureCollection{G, P}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="namingPolicy"></param>
        /// <returns></returns>
        public static FeatureCollection<T, Properties>? ToFeatureCollection<T>(this string? json, JsonNamingPolicy? namingPolicy = default) where T : Geometry
        {
            return string.IsNullOrWhiteSpace(json) ? null : FeatureCollection<T, Properties>.FromJson<T>(json, GetSerializerOptions(namingPolicy));
        }

        /// <summary>
        /// Converts a strongly typed <see cref="IEnumerable{MapFeature}"/> to a strongly typed <see cref="FeatureCollection{G, P}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="featureDefs"></param>
        /// <returns></returns>
        public static FeatureCollection<T, Properties>? ToFeatureCollection<T>(this IEnumerable<MapFeature<T>>? featureDefs) where T : Geometry
        {

            return featureDefs is null ? null : new FeatureCollection<T, Properties>(featureDefs.Select(e => new Feature<T, Properties>(e.Geometry, e.Properties, e.Id, e.Bbox)));
        }

        /// <summary>
        /// Converts <see cref="IEnumerable{MapFeature}"/> to a <see cref="FeatureCollection{G, P}"/>.
        /// </summary>
        /// <param name="featureDefs"><see cref="MapFeature"/></param>
        /// <param name="bbox"><see cref="BoundingBox"/></param>
        /// <returns></returns>
        public static FeatureCollection<Geometry, Properties>? ToFeatureCollection(this IEnumerable<MapFeature>? featureDefs, BoundingBox? bbox = null)
        {
            var features = featureDefs?.Select(e => e.ToFeature());
            return features is null ? null : new FeatureCollection<Geometry, Properties>(features!, bbox);
        }

        /// <summary>
        /// Converts a strongly typed <see cref="IEnumerable{MapFeature}"/> to a strongly typed <see cref="FeatureCollection{G, P}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="featureDefs"><see cref="MapFeature"/></param>
        /// <param name="bbox"><see cref="BoundingBox"/></param>
        /// <returns></returns>
        public static FeatureCollection<T, Properties>? ToFeatureCollection<T>(this IEnumerable<MapFeature<T>>? featureDefs, BoundingBox? bbox = null) where T : Geometry
        {
            var features = featureDefs?.Select(e => e.ToFeature<T>());
            return features is null ? null : new FeatureCollection<T, Properties>(features!, bbox);
        }

        #endregion

        #region ToMapFeature

        /// <summary>
        /// Deserialize json string to a strongly typed <see cref="MapFeature{T}"/>
        /// </summary>
        /// <typeparam name="T"><see cref="Geometry"/></typeparam>
        /// <param name="json"></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <returns></returns>
        public static MapFeature<T>? ToMapFeature<T>(this string? json, JsonNamingPolicy? namingPolicy = default) where T : Geometry
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.Deserialize<MapFeature<T>>(json, GetSerializerOptions(namingPolicy));
        }

        /// <summary>
        /// Converts <see cref="Feature{G, P}"/> to <see cref="MapFeature"/>
        /// </summary>
        /// <param name="feature"><see cref="Feature{G, P}"/></param>
        /// <param name="asShape"><see cref="MapFeature.AsShape"/></param>
        /// <returns></returns>
        public static MapFeature? ToMapFeature(this Feature<Geometry, Properties> feature, bool asShape)
        {
            if (feature is null) return null;
            if (feature.Geometry is null) return null;
            return new MapFeature(feature.Geometry) { Id = $"{feature.Id}", Bbox = feature.Bbox, Properties = feature.Properties, AsShape = asShape };
        }

        /// <summary>
        /// Converts <see cref="Feature{G, P}"/> to <see cref="MapFeature"/>
        /// </summary>
        /// <typeparam name="T"><see cref="Geometry"/></typeparam>
        /// <param name="feature"><see cref="Feature{G, P}"/></param>
        /// <param name="asShape"><see cref="MapFeature.AsShape"/></param>
        /// <returns></returns>
        public static MapFeature? ToMapFeature<T>(this Feature<T, Properties> feature, bool asShape) where T : Geometry
        {
            if (feature is null) return null;
            if (feature.Geometry is null) return null;
            return new MapFeature(feature.Geometry) { Id = $"{feature.Id}", Bbox = feature.Bbox, Properties = feature.Properties, AsShape = asShape };
        }

        #endregion

        #region ToMapFeatures

        /// <summary>
        /// Converts a strongly typed <see cref="FeatureCollection{G, P}"/> to <see cref="List{MapFeature}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"><see cref="FeatureCollection{G, P}"/></param>
        /// <param name="asShape"><see cref="MapFeature.AsShape"/></param>
        /// <returns></returns>
        public static List<MapFeature>? ToMapFeatures<T>(this FeatureCollection<T, Properties>? collection, bool asShape) where T : Geometry
        {
            if (collection is null) return null;
            if (collection.Features is null) return null;

            return [.. collection.Features.Where(e => e.Geometry is not null).Select(e => e.ToMapFeature<T>(asShape)!)];
        }

        /// <summary>
        /// Deserialize json string to a strongly typed list of <see cref="MapFeature{T}"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="Geometry"/></typeparam>
        /// <param name="json"></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <returns></returns>
        public static List<MapFeature<T>>? ToMapFeatures<T>(this string? json, JsonNamingPolicy? namingPolicy = default) where T : Geometry
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.Deserialize<List<MapFeature<T>>>(json, GetSerializerOptions(namingPolicy));
        }

        #endregion

        #region ToJson Feature

        /// <summary>
        /// Serializes a <see cref="Feature{G, P}"/>
        /// </summary>
        /// <param name="feature"><see cref="Feature{G, P}"/></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <param name="writeIndented"><see cref="JsonSerializerOptions.WriteIndented"/></param>
        /// <returns></returns>
        public static string? ToJson(this Feature<Geometry, Properties>? feature, JsonNamingPolicy? namingPolicy = default, bool writeIndented = true)
        {
            return feature?.ToJson(GetSerializerOptions(namingPolicy, writeIndented));
        }

        /// <summary>
        /// Serializes a strongly typed <see cref="Feature{G, P}"/>
        /// </summary>
        /// <typeparam name="T"><see cref="Geometry"/></typeparam>
        /// <param name="feature"><see cref="Feature{G, P}"/></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <param name="writeIndented"><see cref="JsonSerializerOptions.WriteIndented"/></param>
        /// <returns></returns>
        public static string? ToJson<T>(this Feature<T, Properties>? feature, JsonNamingPolicy? namingPolicy = default, bool writeIndented = true) where T : Geometry
        {
            return feature?.ToJson(GetSerializerOptions(namingPolicy, writeIndented));
        }

        #endregion

        #region ToJson Features

        /// <summary>
        /// Serializes a <see cref="FeatureCollection{G, P}"/>.
        /// </summary>
        /// <param name="collection"><see cref="FeatureCollection{G, P}"/></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <param name="writeIndented"><see cref="JsonSerializerOptions.WriteIndented"/></param>
        /// <returns></returns>
        public static string? ToJson(this FeatureCollection<Geometry, Properties>? collection, JsonNamingPolicy? namingPolicy = default, bool writeIndented = true)
        {
            return collection?.ToJson(GetSerializerOptions(namingPolicy, writeIndented));
        }

        /// <summary>
        /// Serializes a strongly typed <see cref="FeatureCollection{G, P}"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="Geometry"/></typeparam>
        /// <param name="collection"><see cref="FeatureCollection{G, P}"/></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <param name="writeIndented"><see cref="JsonSerializerOptions.WriteIndented"/></param>
        /// <returns></returns>
        public static string? ToJson<T>(this FeatureCollection<T, Properties>? collection, JsonNamingPolicy? namingPolicy = default, bool writeIndented = true) where T : Geometry
        {
            return collection?.ToJson(GetSerializerOptions(namingPolicy, writeIndented));
        }

        #endregion

        #region ToJson MapFeature

        /// <summary>
        /// Serializes a <see cref="MapFeature"/>.
        /// </summary>
        /// <param name="MapFeature"><see cref="MapFeature"/></param>
        /// <param name="options"><see cref="JsonSerializerOptions"/></param>
        /// <returns></returns>
        public static string? ToJson(this MapFeature? MapFeature, JsonSerializerOptions? options = null)
        {
            return MapFeature is null ? null : JsonSerializer.Serialize(MapFeature, options ?? GetSerializerOptions());
        }

        /// <summary>
        /// Serializes a <see cref="MapFeature"/>.
        /// </summary>
        /// <param name="MapFeature"><see cref="MapFeature"/></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <param name="writeIndented"><see cref="JsonSerializerOptions.WriteIndented"/></param>
        /// <returns></returns>
        public static string? ToJson(this MapFeature? MapFeature, JsonNamingPolicy? namingPolicy = default, bool writeIndented = true)
        {
            return MapFeature is null ? null : JsonSerializer.Serialize(MapFeature, GetSerializerOptions(namingPolicy, writeIndented));
        }

        #endregion

        #region ToJson MapFeatures

        /// <summary>
        /// Serializes an <see cref="IEnumerable{MapFeature}"/>.
        /// </summary>
        /// <param name="features"><see cref="MapFeature"/></param>
        /// <param name="namingPolicy"><see cref="JsonNamingPolicy"/></param>
        /// <param name="writeIndented"><see cref="JsonSerializerOptions.WriteIndented"/></param>
        /// <returns></returns>
        public static string? ToJson(this IEnumerable<MapFeature>? features, JsonNamingPolicy? namingPolicy = default, bool writeIndented = true)
        {
            return features is null ? null : JsonSerializer.Serialize(features, GetSerializerOptions(namingPolicy, writeIndented));
        }

        /// <summary>
        /// Serializes an <see cref="IEnumerable{MapFeature}"/>.
        /// </summary>
        /// <param name="features"><see cref="IEnumerable{MapFeature}"/></param>
        /// <param name="options"><see cref="JsonSerializerOptions"/></param>
        /// <returns></returns>
        public static string? ToJson(this IEnumerable<MapFeature>? features, JsonSerializerOptions? options)
        {
            return features is null ? null : JsonSerializer.Serialize(features, options ?? GetSerializerOptions());
        }

        #endregion
    }
}
