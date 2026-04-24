using System.Collections.Generic;

namespace CleanArchitecture.Utilities.Results
{
    /// <summary>
    /// Represents a result operation without a payload.
    /// </summary>
    public class Result
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of <see cref="Result"/>.
        /// </summary>
        public Result() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Result"/> with a status code.
        /// </summary>
        /// <param name="statusCode">The result status.</param>
        public Result(ResultStatus statusCode)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Result"/> with a status code and a single message.
        /// </summary>
        /// <param name="statusCode">The result status.</param>
        /// <param name="message">The associated message.</param>
        public Result(ResultStatus statusCode, string message) : this(statusCode, new List<string> { message }) { }

        /// <summary>
        /// Initializes a new instance of <see cref="Result"/> with a status code and multiple messages.
        /// </summary>
        /// <param name="statusCode">The result status.</param>
        /// <param name="messages">The associated messages.</param>
        public Result(ResultStatus statusCode, IList<string> messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the result status code.
        /// </summary>
        public ResultStatus StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the optional result messages.
        /// </summary>
        public IList<string> Messages { get; set; }

        #endregion

        #region static factory methods

        /// <summary>
        /// Creates a success result.
        /// </summary>
        /// <returns>A <see cref="Result"/> with <see cref="ResultStatus.Success"/>.</returns>
        public static Result Success() => new(ResultStatus.Success);

        /// <summary>
        /// Creates an invalid result with a single message.
        /// </summary>
        /// <param name="message">The validation or failure message.</param>
        /// <returns>A <see cref="Result"/> with <see cref="ResultStatus.Invalid"/>.</returns>
        public static Result Invalid(string message) => new(ResultStatus.Invalid, message);

        /// <summary>
        /// Creates an internal error result with a single message.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A <see cref="Result"/> with <see cref="ResultStatus.InternalError"/>.</returns>
        public static Result InternalError(string message) => new(ResultStatus.InternalError, message);

        #endregion
    }
}
