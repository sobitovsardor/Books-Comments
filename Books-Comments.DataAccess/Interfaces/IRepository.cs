using Books_Comments.Domain.Commons;
using System.Linq.Expressions;

namespace Books_Comments.DataAccess.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    public Task<T?> FindByIdAsync(long id);

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

    public Task<T> Add(T entity);

    public void Delete(long id);

    public void Update(long id, T entity);
}
