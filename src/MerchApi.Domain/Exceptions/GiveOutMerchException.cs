using System;

namespace MerchApi.Domain.Exceptions
{
    public class GiveOutMerchException : Exception
    {
        public GiveOutMerchException(string message) : base(message)
        {

        }

        public GiveOutMerchException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}