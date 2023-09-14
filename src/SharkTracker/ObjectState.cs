namespace SharkTracker
{
    /// <summary>
    /// Represents the object state into change tracker.
    /// </summary>
    public enum ObjectState
    {
        /// <summary>
        /// Indicates that the object isn't into change tracker.
        /// </summary>
        Detached,

        /// <summary>
        /// Indicates that the object doesn't have any change.
        /// </summary>
        Unchanged,

        /// <summary>
        /// Indicates that the object has been deleted from change tracker.
        /// </summary>
        Deleted,

        /// <summary>
        /// Indicates that the object has been modified.
        /// </summary>
        Modified,

        /// <summary>
        /// Indicates that the object has been added to change tracker.
        /// </summary>
        Added
    }
}
