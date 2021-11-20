using System.Collections.Generic;

using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchRequestAggregate
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : ValueObject
    {
        public int Id { get; }
        public Email Email { get; }

        public Employee(int id, Email email)
        {
            Id = id;
            Email = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Email;
        }
    }
}