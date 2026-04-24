namespace CleanArchitecture.Utilities.Results
{
    /// <summary>
    /// Specifies the operation outcome status codes.
    /// </summary>
    public enum ResultStatus
    {
        /// <summary>
        /// The operation completed successfully.
        /// </summary>
        Success,

        /// <summary>
        /// The operation created a new resource.
        /// </summary>
        Created,

        /// <summary>
        /// The operation failed due to invalid input.
        /// </summary>
        Invalid,

        /// <summary>
        /// The operation failed due to an internal error.
        /// </summary>
        InternalError,

        /// <summary>
        /// The requested resource was not found.
        /// </summary>
        NotFound
    }
}
