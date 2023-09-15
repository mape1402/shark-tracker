using SharkTracker.Exceptions;
using SharkTracker.Infrastructure;
using System.Collections.Concurrent;

namespace SharkTracker.Metadata
{
    /// <summary>
    /// Class <see cref="MetadataRegistry"/> manages all metadata for tracking.
    /// </summary>
    public sealed class MetadataRegistry : IMetadataRegistry
    {
        private readonly ConcurrentDictionary<Type, ObjectTypeMetadata> _metadata;

        /// <summary>
        /// Initializes a new instance of <see cref="MetadataRegistry"/> class.
        /// </summary>
        public MetadataRegistry()
        {
            _metadata = new ConcurrentDictionary<Type, ObjectTypeMetadata>();
        }

        /// <inheritdoc/>
        public ObjectTypeMetadata AddType<T>() where T : class
            => AddType(typeof(T));

        /// <inheritdoc/>
        public ObjectTypeMetadata AddType(Type type)
        {
            if (!type.IsClass || type.IsAbstract)
                throw new ArgumentException($"'{type.Name}' type cannot be tracked.");

            if (IsRegistered(type))
                return Get(type);

            var objectMetadata = new ObjectTypeMetadata(type, this);
            _metadata.TryAdd(type, objectMetadata);

            return objectMetadata;
        }

        /// <inheritdoc/>
        public ObjectTypeMetadata Get<T>() where T : class
            => Get(typeof(T));

        /// <inheritdoc/>
        public ObjectTypeMetadata Get(Type type)
        {
            if(_metadata.TryGetValue(type, out var objectMetadata))
                return objectMetadata;

            throw new ObjectTypeMetadataIsNotRegisteredException(type);
        }

        /// <inheritdoc/>
        public bool IsRegistered<T>() where T : class
            => IsRegistered(typeof(T));

        /// <inheritdoc/>
        public bool IsRegistered(Type type)
            => _metadata.ContainsKey(type);
    }
}
