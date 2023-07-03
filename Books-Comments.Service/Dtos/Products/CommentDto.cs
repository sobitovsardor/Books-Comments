using Books_Comments.Domain.Entities.Comments;
using Books_Comments.Service.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.Dtos.Products;

public class CommentDto
{
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public int BookId { get; set; }
    public int UserId { get; set; }

    public static implicit operator CommentDto(Comment dto)
    {
        return new CommentDto
        {
            Id = dto.Id,
            Description = dto.Description,
            BookId = dto.BookId,
            UserId = dto.UserId
        };
    }
}
