using SharkTracker.Exceptions;
using SharkTracker.Infrastructure;

namespace SharkTracker.Metadata
{
    /// <summary>
    /// <see cref="IMetadataRegistry"/> manages all metadata for tracking.
    /// </summary>
    public interface IMetadataRegistry
    {
        /// <summary>
        /// Adds a new type to metadata container.
        /// </summary>
        /// <typeparam name="T">Object Type. This type shoulds be a class.</typeparam>
        /// <exception cref="ArgumentNullException">Throws when the Object Type is not valid.</exception>
        /// <returns>Returns a new instace of <see cref="ObjectTypeMetadata"/> class.</returns>
        ObjectTypeMetadata AddType<T>() where T : class;

        /// <summary>
        /// Adds a new type to metadata container.
        /// </summary>
        /// <param name="type">Object Type. This type shoulds be a class.</param>
        /// <exception cref="ArgumentNullException">Throws when the Object Type is not valid.</exception>
        /// <returns>Returns a new instace of <see cref="ObjectTypeMetadata"/> class.</returns>
        ObjectTypeMetadata AddType(Type type);

        /// <summary>
        /// Gets the object type metadata.
        /// </summary>
        /// <typeparam name="T">Object Type.</typeparam>
        /// <returns>Returns an instance of <see cref="ObjectTypeMetadata"/>.</returns>
        ObjectTypeMetadata Get<T>() where T : class;

        /// <summary>
        /// Gets the object type metadata.
        /// </summary>
        /// <param name="type">Object Type.</param>
        /// <returns>Returns an instance of <see cref="ObjectTypeMetadata"/>.</returns>
        /// <exception cref="ObjectTypeMetadataIsNotRegisteredException">Throws when object type is missing into metadata container.</exception>
        ObjectTypeMetadata Get(Type type);

        /// <summary>
        /// Gets a value that indicates if the type has been registered in the current <see cref="IMetadataRegistry"/> instance.
        /// </summary>
        /// <typeparam name="T">Object Type.</typeparam>
        /// <returns>Returns a <see langword="true"/> value if type has been registered, otherwise, returns <see langword="false"/>.</returns>
        bool IsRegistered<T>() where T : class;

        /// <summary>
        /// Gets a value that indicates if the type has been registered in the current <see cref="IMetadataRegistry"/> instance.
        /// </summary>
        /// <param name="type">Object Type.</param>
        /// <returns>Returns a <see langword="true"/> value if type has been registered, otherwise, returns <see langword="false"/>.</returns>
        bool IsRegistered(Type type);
    }
}
