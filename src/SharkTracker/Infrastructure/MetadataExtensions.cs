using SharkTracker.Metadata;
using System.Collections;
using System.Reflection;

namespace SharkTracker.Infrastructure
{
    internal static class MetadataExtensions
    {
        public static InternalPropertyType GetInternalPropertyType(this PropertyInfo propertyInfo)
        {
            var type = propertyInfo.PropertyType;

            if(type.IsPrimitive())
                return InternalPropertyType.Primitive;

            if (type.IsCollection())
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

        public static bool IsCollection(this Type type)
            => type.IsArray || typeof(IEnumerable).IsAssignableFrom(type);

        public static IEnumerable<PropertyTypeMetadata> ToProperties(this Type type, IMetadataRegistry metadataRegistry)
        {
            var props = new List<PropertyTypeMetadata>();

            foreach (var p in type.GetProperties())
                props.Add(new PropertyTypeMetadata(p, metadataRegistry));

            return props;
        }

        public static bool ShouldDestructureProperty(this InternalPropertyType type)
            => type == InternalPropertyType.Complex || type == InternalPropertyType.Collection;

        public static void Destructure(this PropertyTypeMetadata propertyMetadata, IMetadataRegistry metadataRegistry)
        {
            if(propertyMetadata.InternalType == InternalPropertyType.Complex)
            {
                metadataRegistry.AddType(propertyMetadata.ClrType);
                return;
            }

            propertyMetadata.ClrType.InmersiveRegister(metadataRegistry);
        }

        private static Type InternalGetElementType(this Type type)
        {
            var elementType = type.GetElementType();

            if(elementType != null)
                return elementType;

            return type.GenericTypeArguments.FirstOrDefault();
        }

        private static void InmersiveRegister(this Type type, IMetadataRegistry metadataRegistry)
        {
            var elementType = type.InternalGetElementType();

            if (elementType == null)
                return;

            if (elementType.IsPrimitive())
                return;

            if (elementType.IsCollection())
                elementType.InmersiveRegister(metadataRegistry);

            metadataRegistry.AddType(elementType);
        }
    }
}
