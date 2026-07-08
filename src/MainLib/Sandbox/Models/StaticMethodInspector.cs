using System.Reflection;

namespace Sandbox.Models
{
    internal static class StaticMethodInspector
    {
        // Returns only the static methods declared in the specified class
        public static MethodInfo[] GetCustomStaticMethods(this Type type)
        {
            ArgumentNullException.ThrowIfNull(type);

            // Ensure the type is actually a static class
            if (!(type.IsClass && type.IsAbstract && type.IsSealed))
                throw new ArgumentException("Type must be a static class.", nameof(type));

            // Retrieve ONLY methods declared in this class (not inherited)
            return type.GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly
            );
        }
    }
}
