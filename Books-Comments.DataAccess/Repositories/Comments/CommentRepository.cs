using Books_Comments.DataAccess.DbContexts;
using Books_Comments.DataAccess.Interfaces.Comments;
using Books_Comments.Domain.Entities.Comments;

namespace Books_Comments.DataAccess.Repositories.Comments;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
}
