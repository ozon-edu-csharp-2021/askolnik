using System;

namespace MerchApi.Domain.SharedKernel.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}
