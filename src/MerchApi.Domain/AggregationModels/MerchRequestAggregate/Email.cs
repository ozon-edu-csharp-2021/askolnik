using System;
using System.Collections.Generic;
using System.Net.Mail;

using MerchApi.Domain.Exceptions;
using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchRequestAggregate
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value) =>
            Value = value;

        public static Email Create(string emailString)
        {
            if (!IsValid(emailString))
            {
                throw new EmailException("Email is invalid");
            }

            return new Email(emailString);
        }

        private static bool IsValid(string emailString)
        {
            try
            {
                var m = new MailAddress(emailString);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}