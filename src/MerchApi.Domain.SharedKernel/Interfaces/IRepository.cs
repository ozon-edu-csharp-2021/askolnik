using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.SharedKernel.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
    }
}