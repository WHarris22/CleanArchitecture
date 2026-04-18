#nullable enable

using System.Collections.Generic;

namespace CleanArchitecture.Utilities.Results
{
    public class Result<T> : Result
    {
        #region constructors

        public Result(ResultStatus statusCode, T content) : base(statusCode)
        {
            Content = content;
        }

        public Result(ResultStatus statusCode, string message) : base(statusCode, message)
        {
        }

        public Result(ResultStatus statusCode, IList<string> messages) : base(statusCode, messages)
        {
        }

        #endregion
        
        public T? Content { get; set; }
    }
}
