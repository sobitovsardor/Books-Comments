using Books_Comments.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.ViewModels.Accounts;

public class AccountBaseViewModel
{
    public int Id { get; set; }

    public string UserName { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

    public static implicit operator AccountBaseViewModel(User viewModel)
    {
        return new AccountBaseViewModel()
        {
            Id = viewModel.Id,
            UserName = viewModel.UserName,
            Email = viewModel.Email,
            ImagePath = viewModel.ImagePath,
        };
    }
}