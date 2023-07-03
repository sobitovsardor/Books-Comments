using Books_Comments.DataAccess.DbContexts;
using Books_Comments.DataAccess.Interfaces;
using Books_Comments.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books_Comments.DataAccess.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected AppDbContext _dbcontext;
    protected DbSet<T> _dbSet;
    public BaseRepository(AppDbContext context)
    {
        _dbcontext = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T> Add(T entity) => (await _dbSet.AddAsync(entity)).Entity;

    public virtual void Delete(long id)
    {
        var entity = _dbSet.Find(id);
        if (entity is not null)
            _dbSet.Remove(entity);
    }

    public virtual async Task<T?> FindByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public virtual void Update(long id, T entity)
    {
        entity.Id = (int)id;
        _dbSet.Update(entity);
    }
}
