using System.Collections;
using System.Reflection;

namespace ChangeTracker.Infrastructure
{
    internal static class MetadataExtensions
    {
        public static InternalPropertyType GetInternalPropertyType(this PropertyInfo propertyInfo)
        {
            var type = propertyInfo.PropertyType;

            if(type.IsPrimitive())
                return InternalPropertyType.Primitive;

            if (type.IsArray || typeof(IEnumerable).IsAssignableFrom(type))
                return InternalPropertyType.Collection;

            return InternalPropertyType.Complex;
        }

        public static bool IsPrimitive(this Type type)
        {
            var types = new List<Type>
            {
                typeof(int?),
                typeof(bool?),
                typeof(char?),
                typeof(byte?),
                typeof(sbyte?),
                typeof(string),
                typeof(TimeSpan),
                typeof(TimeSpan?),
                typeof(DateTime),
                typeof(DateTime?),
                typeof(decimal),
                typeof(decimal?),
                typeof(float),
                typeof(float?),
                typeof(double),
                typeof(double?)
            };

            return types.Contains(type) || type.IsPrimitive;
        }

        public static IEnumerable<PropertyTypeMetadata> ToProperties(this Type type)
            => type.GetProperties().Select(p => new PropertyTypeMetadata(p));
    }
}
