using Books_Comments.Domain.Entities.Comments;
using Books_Comments.Domain.Entities.Users;
using Books_Comments.Service.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public int BookId { get; set; }

        public AccountBaseViewModel AccountBaseViewModel { get; set; } 

        public static implicit operator Comment(CommentViewModel model)
        {
            return new Comment()
            {
                Description = model.Description,
                BookId = model.BookId,
                Id = model.Id,
            };
        }
    }
}
