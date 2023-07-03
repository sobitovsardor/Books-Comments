using Books_Comments.DataAccess.DbContexts;
using Books_Comments.DataAccess.Interfaces.Books;
using Books_Comments.Domain.Entities.Books;

namespace Books_Comments.DataAccess.Repositories.Books;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }
}
