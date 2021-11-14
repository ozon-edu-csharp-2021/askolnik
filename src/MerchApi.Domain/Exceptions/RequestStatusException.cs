using System;

namespace MerchApi.Domain.Exceptions
{
    public class RequestStatusException : Exception
    {
        public RequestStatusException(string message) : base(message)
        {

        }

        public RequestStatusException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}