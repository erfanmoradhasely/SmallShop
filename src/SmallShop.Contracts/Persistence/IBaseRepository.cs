using SmallShop.Domain.Common;
using System.Linq.Expressions;

namespace SmallShop.Contracts.Persistence;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetAsync(Guid id);

    Task<T?> GetTracking(Guid id);

    void Add(T entity);

    Task AddRange(ICollection<T> entities);

    void Update(T entity);

    void Delete(T entity);

    Task<int> Save();

    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

    bool Exists(Expression<Func<T, bool>> expression);

    T? Get(Guid id);
}