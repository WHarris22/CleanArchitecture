using System.Collections.Generic;

namespace CleanArchitecture.Core.Utilities
{
    public class ServiceResult<T> : ServiceResult
    {
        #region constructors

        public ServiceResult(StatusCode statusCode, T content)
        {
            StatusCode = statusCode;
            Content = content;
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
        
        public T Content { get; set; }
    }
}
