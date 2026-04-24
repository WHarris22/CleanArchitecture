using System.Collections.Generic;

namespace CleanArchitecture.Utilities.Results
{
    /// <summary>
    /// Represents a result operation with a content payload.
    /// </summary>
    /// <typeparam name="T">The payload type.</typeparam>
    public class Result<T> : Result
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of <see cref="Result{T}"/> with content.
        /// </summary>
        /// <param name="statusCode">The result status.</param>
        /// <param name="content">The content payload.</param>
        public Result(ResultStatus statusCode, T content) : base(statusCode)
        {
            Content = content;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Result{T}"/> with a single message.
        /// </summary>
        /// <param name="statusCode">The result status.</param>
        /// <param name="message">The associated message.</param>
        public Result(ResultStatus statusCode, string message) : base(statusCode, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Result{T}"/> with multiple messages.
        /// </summary>
        /// <param name="statusCode">The result status.</param>
        /// <param name="messages">The associated messages.</param>
        public Result(ResultStatus statusCode, IList<string> messages) : base(statusCode, messages)
        {
        }

        #endregion
        
        /// <summary>
        /// Gets or sets the content payload.
        /// </summary>
        public T Content { get; set; }
    }
}
