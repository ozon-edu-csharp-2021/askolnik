using System;

namespace MerchApi.Domain.Exceptions
{
    public class DeclineMerchException : Exception
    {
        public DeclineMerchException(string message) : base(message)
        {

        }

        public DeclineMerchException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}