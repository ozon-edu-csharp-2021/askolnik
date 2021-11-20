﻿using System;

namespace MerchApi.Domain.Exceptions
{
    public class ItemException : Exception
    {
        public ItemException(string message) : base(message)
        {

        }

        public ItemException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}