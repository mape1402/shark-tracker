
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
        public ObjectTypeMetadata(Type clrType)
        {
            ClrType = clrType ?? throw new ArgumentNullException(nameof(clrType));
            Name = ClrType.Name;
            Properties = ClrType.ToProperties();
        }

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
