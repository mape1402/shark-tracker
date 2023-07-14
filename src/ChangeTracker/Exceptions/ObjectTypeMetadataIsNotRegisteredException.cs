using ChangeTracker.Metadata;

namespace ChangeTracker.Exceptions
{

	/// <summary>
	/// Class <see cref="ObjectTypeMetadataIsNotRegisteredException"/> represents an error when <see cref="IMetadataRegistry"/> instance cannot get a metadata of object type.
	/// </summary>
	[Serializable]
	public class ObjectTypeMetadataIsNotRegisteredException : Exception
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ObjectTypeMetadataIsNotRegisteredException"/> class.
		/// </summary>
		/// <param name="type">Object Type missing.</param>
		public ObjectTypeMetadataIsNotRegisteredException(Type type) : base($"{type.Name} not found into metadata registry.") { }
	}
}
