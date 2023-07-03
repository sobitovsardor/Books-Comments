using Books_Comments.Domain.Entities.Books;
using Books_Comments.Domain.Entities.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.ViewModels.Products;

public class AddCommentViewModel
{
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public int BookId { get; set; }
    public int UserId { get; set; }

    public static implicit operator Comment(AddCommentViewModel model)
    {
        return new Comment
        {
            Id = model.Id,
            Description = model.Description,
            BookId = model.BookId,
            UserId = model.UserId
        };
    }
}
