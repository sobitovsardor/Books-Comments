using Books_Comments.DataAccess.Interfaces;
using Books_Comments.Domain.Entities.Comments;
using Books_Comments.Service.Common.Helpers;
using Books_Comments.Service.Common.Unils;
using Books_Comments.Service.Dtos.Products;
using Books_Comments.Service.Interfaces;
using Books_Comments.Service.Interfaces.Products;
using Books_Comments.Service.ViewModels;
using Books_Comments.Service.ViewModels.Accounts;
using Books_Comments.Service.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.Services.Products;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _repository;
    private readonly IIdentityService _identity;
    public ProductService(IUnitOfWork unitOfWork, IIdentityService identity)
    {
        this._repository = unitOfWork;
        _identity = identity;
    }

    public async Task<bool> CreateAsync(CommentDto dto)
    {

        if (dto.Description is not null)
        {   
            Comment comment = new Comment()
            {
                BookId= dto.BookId,
                UserId = Convert.ToInt32(_identity.Id!.Value),
                Description = dto.Description!,
            };
             
            _repository.Comments.Add(comment);
            var dbResult = await _repository.SaveChangeAsync();
            return dbResult > 0;
        }
        return false;


    }

    public async Task<IEnumerable<ProductBaseViewModel>> GetAllAsync(PaginationParams @params)
    {
        var query = from product in _repository.Books.GetAll() 
                    select new ProductBaseViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        ImagePath = product.ImagePath,
                        Description = product.Description,
                        AuthorName = product.AuthorName,
                        Category = product.Category
                    };
        return await query.Skip((@params.PageNumber - 1) * @params.PageSize)
                          .Take(@params.PageSize).AsNoTracking()
                          .ToListAsync();
    }

    public async Task<IEnumerable<CommentViewModel>> GetCommentsAsync(int bookId, PaginationParams @params)
    {
        var query = from comment in _repository.Comments.GetAll().Where(x => x.BookId == bookId)
                    select new CommentViewModel()
                    {
                        Id = comment.Id,
                        BookId = comment.BookId,
                        Description = comment.Description,
                        AccountBaseViewModel = (AccountBaseViewModel)comment.User,
                    };
        return await query.Skip((@params.PageNumber - 1) * @params.PageSize)
                          .Take(@params.PageSize).AsNoTracking()
                          .ToListAsync();
    }
}
