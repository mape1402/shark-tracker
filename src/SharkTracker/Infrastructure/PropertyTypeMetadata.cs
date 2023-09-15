using SharkTracker.Metadata;
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
        /// <param name="metadataRegistry">Current <see cref="IMetadataRegistry"/> instance.</param>
        public PropertyTypeMetadata(PropertyInfo accessor, IMetadataRegistry metadataRegistry)
        {
            Accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
            MetadataRegistry = metadataRegistry ?? throw new ArgumentNullException(nameof(metadataRegistry));
            ClrType = accessor.PropertyType;
            Name = accessor.Name;
            InternalType = accessor.GetInternalPropertyType();

            if (InternalType.ShouldDestructureProperty())
                this.Destructure(MetadataRegistry);
        }

        /// <summary>
        /// Gets the current <see cref="IMetadataRegistry"/> instance.
        /// </summary>
        public IMetadataRegistry MetadataRegistry { get; }

        /// <summary>
        /// Gets a type of property.
        /// </summary>
        public Type ClrType { get; }

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
