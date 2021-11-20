using System;

namespace MerchApi.Domain.Exceptions
{
    public class EmailException : Exception
    {
        public EmailException(string message) : base(message)
        {

        }

        public EmailException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}