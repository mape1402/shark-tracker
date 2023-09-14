using System.Reflection;

namespace SharkTracker.Infrastructure
{
    /// <summary>
    /// Class <see cref="PropertyTypeMetadata"/> represents the metadata of a property of object.
    /// </summary>
    public sealed class PropertyTypeMetadata
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PropertyTypeMetadata"/> class.
        /// </summary>
        /// <param name="accessor">Property accessor.</param>
        public PropertyTypeMetadata(PropertyInfo accessor)
        {
            Accessor = accessor;
            PropertyType = accessor.PropertyType;
            Name = accessor.Name;
            InternalType = accessor.GetInternalPropertyType();
        }

        /// <summary>
        /// Gets a type of property.
        /// </summary>
        public Type PropertyType { get; }

        /// <summary>
        /// Gets the property accessor.
        /// </summary>
        public PropertyInfo Accessor { get; }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the <see cref="InternalPropertyType"/> value.
        /// </summary>
        public InternalPropertyType InternalType { get; }
    }
}
