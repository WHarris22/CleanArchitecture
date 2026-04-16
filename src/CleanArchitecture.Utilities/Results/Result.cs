#nullable enable

using System.Collections.Generic;

namespace CleanArchitecture.Utilities.Results
{
    public class Result
    {
        #region constructors

        public Result() { }

        public Result(ResultStatus statusCode)
        {
            StatusCode = statusCode;
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

        #region properties

        /// <summary>
        /// 
        /// </summary>
        public ResultStatus StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<string>? Messages { get; set; }

        #endregion
    }
}
