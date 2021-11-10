using System.Threading;
using System.Threading.Tasks;

namespace MerchApi.Domain.SharedKernel.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозитория
    /// </summary>
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Создать новую сущность
        /// </summary>
        /// <param name="itemToCreate">Объект для создания</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Созданная сущность</returns>
        Task<T> CreateAsync(T itemToCreate, CancellationToken cancellationToken = default);
    }
}