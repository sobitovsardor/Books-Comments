using Books_Comments.Domain.Commons;
using Books_Comments.Domain.Entities.Books;

namespace Books_Comments.Domain.Entities.Comments;

public class Comment : Audiotable
{
    public string Description { get; set; } = String.Empty;

    public int UserId { get; set; }
    public virtual Users.User User { get; set; } = default!;
    
    public int BookId { get; set; }
    public virtual Book Book { get; set; } = default!;
}
