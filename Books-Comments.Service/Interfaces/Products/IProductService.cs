using Books_Comments.Service.Common.Unils;
using Books_Comments.Service.Dtos.Products;
using Books_Comments.Service.ViewModels;
using Books_Comments.Service.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.Interfaces.Products;

public interface IProductService
{
    public Task<IEnumerable<ProductBaseViewModel>> GetAllAsync(PaginationParams @params);

    public Task<IEnumerable<CommentViewModel>> GetCommentsAsync(int bookId, PaginationParams @params);

    public Task<bool> CreateAsync(CommentDto dto);
}
