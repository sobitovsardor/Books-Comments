using Books_Comments.DataAccess.DbContexts;
using Books_Comments.DataAccess.Interfaces;
using Books_Comments.Domain.Commons;
using System.Linq.Expressions;

namespace Books_Comments.DataAccess.Repositories;

public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T> where T : BaseEntity
{
    public GenericRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<T> GetAll() => _dbSet;

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        => _dbSet.Where(expression);
}
