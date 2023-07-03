using Books_Comments.DataAccess.DbContexts;
using Books_Comments.DataAccess.Interfaces;
using Books_Comments.DataAccess.Interfaces.Books;
using Books_Comments.DataAccess.Interfaces.Comments;
using Books_Comments.DataAccess.Interfaces.Users;
using Books_Comments.DataAccess.Repositories.Books;
using Books_Comments.DataAccess.Repositories.Comments;
using Books_Comments.DataAccess.Repositories.Users;

namespace Books_Comments.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;

    public IUserRepository Users { get; }
    public IBookRepository Books { get; }
    public ICommentRepository Comments { get; }

    public UnitOfWork(AppDbContext appDbContext)
    {
        this.dbContext = appDbContext;
        Users = new UserRepository(appDbContext);
        Books = new BookRepository(appDbContext);
        Comments = new CommentRepository(appDbContext);
    }

    public async Task<int> SaveChangeAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}
