namespace ChangeTracker
{
    /// <summary>
    /// Indicates the category of property type.
    /// </summary>
    public enum InternalPropertyType
    {
        /// <summary>
        /// Indicates that the property type is a primitive value.
        /// </summary>
        Primitive,

        /// <summary>
        /// Indicates that the property type is a complex object.
        /// </summary>
        Complex,

        /// <summary>
        /// Indicates that the property type is a collection.
        /// </summary>
        Collection
    }
}
