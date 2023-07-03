using Books_Comments.DataAccess.Interfaces.Books;
using Books_Comments.DataAccess.Interfaces.Comments;
using Books_Comments.DataAccess.Interfaces.Users;

namespace Books_Comments.DataAccess.Interfaces;

public interface IUnitOfWork
{
    public IUserRepository Users { get; }

    public IBookRepository Books { get; }

    public ICommentRepository Comments { get; }

    public Task<int> SaveChangeAsync();
}
