
using SharkTracker.Metadata;

namespace SharkTracker.Infrastructure
{
    /// <summary>
    /// Class <see cref="ObjectTypeMetadata"/> represents the metadata of object type.
    /// </summary>
    public sealed class ObjectTypeMetadata
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ObjectTypeMetadata"/> class. 
        /// </summary>
        /// <param name="clrType">Clr Type of object.</param>
        /// <param name="metadataRegistry">Current <see cref="IMetadataRegistry"/> instance.</param>
        public ObjectTypeMetadata(Type clrType, IMetadataRegistry metadataRegistry)
        {
            ClrType = clrType ?? throw new ArgumentNullException(nameof(clrType));
            MetadataRegistry = metadataRegistry ?? throw new ArgumentNullException(nameof(metadataRegistry));
            Name = ClrType.Name;
            Properties = ClrType.ToProperties(metadataRegistry);
        }

        /// <summary>
        /// Gets the current <see cref="IMetadataRegistry"/> instance.
        /// </summary>
        public IMetadataRegistry MetadataRegistry { get; }

        /// <summary>
        /// Gets the Clr Type of object.
        /// </summary>
        public Type ClrType { get; }

        /// <summary>
        /// Gets the Clr Type name of object.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the properties of object.
        /// </summary>
        public IEnumerable<PropertyTypeMetadata> Properties { get; }
    }
}
