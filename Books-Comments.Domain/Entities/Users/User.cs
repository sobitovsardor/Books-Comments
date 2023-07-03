using Books_Comments.Domain.Commons;
using Books_Comments.Domain.Entities.Comments;

namespace Books_Comments.Domain.Entities.Users;

public class User : Audiotable
{
    public string UserName { get; set; } = String.Empty;
    public string ImagePath { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string PasswrodHash { get; set; } = String.Empty;
    public string Salt { get; set; } = String.Empty;
}
