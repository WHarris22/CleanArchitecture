#nullable enable

using System.Collections.Generic;

namespace CleanArchitecture.Utilities.Results
{
    public class Result<T> : Result
    {
        #region constructors

        public Result(ResultStatus statusCode, T content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public Result(ResultStatus statusCode, string message)
        {
            StatusCode = statusCode;
            Messages = new List<string> { message };
        }

        public Result(ResultStatus statusCode, IList<string> messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }

        #endregion
        
        public T? Content { get; set; }
    }
}
