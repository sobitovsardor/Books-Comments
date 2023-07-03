using Books_Comments.Domain.Commons;
using Books_Comments.Domain.Entities.Comments;

namespace Books_Comments.Domain.Entities.Books;

public class Book : Audiotable
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string ImagePath { get; set; } = String.Empty;
    public string AuthorName { get; set; } = String.Empty;
    public string Category { get; set; } = String.Empty;
}
