using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmallShop.Contracts.Persistence;
using SmallShop.Domain.Common;
using SmallShop.Infrastructure.Persistence.DatabaseContext;

namespace SmallShop.Infrastructure.Persistence.Common;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly SmallShopContext _context;
    public BaseRepository(SmallShopContext context)
    {
        this._context = context;
    }

    public virtual async Task<TEntity?> GetAsync(Guid id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
    }
    public async Task<TEntity?> GetTracking(Guid id)
    {
        return await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

    }
    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    void IBaseRepository<TEntity>.Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }
  
    public async Task AddRange(ICollection<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }
    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
    public void Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
    }
    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().AnyAsync(expression);
    }
    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _context.Set<TEntity>().Any(expression);
    }

    public TEntity? Get(Guid id)
    {
        return _context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id)); ;
    }


}