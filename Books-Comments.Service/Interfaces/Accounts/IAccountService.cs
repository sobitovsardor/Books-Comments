using Books_Comments.Domain.Entities.Users;
using Books_Comments.Service.Dtos.Accounts;
using Books_Comments.Service.ViewModels.Accounts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Books_Comments.Service.Interfaces.Accounts;

public interface IAccountService
{
    public Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto);

    public Task<string> LoginAsync(AccountLoginDto accountLoginDto);

    public Task<AccountBaseViewModel> ProfileAsync();
}
