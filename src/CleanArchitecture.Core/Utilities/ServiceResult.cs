using System.Collections.Generic;

namespace CleanArchitecture.Core.Utilities
{
    public class ServiceResult
    {
        #region constructors

        public ServiceResult() { }

        public ServiceResult(StatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ServiceResult(StatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Messages = new List<string> { message };
        }

        public ServiceResult(StatusCode statusCode, IList<string> messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }

        #endregion

        #region properties

        /// <summary>
        /// 
        /// </summary>
        public StatusCode StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<string> Messages { get; set; }

        #endregion
    }
}
