using Books_Comments.DataAccess.Interfaces;
using Books_Comments.Domain.Entities.Users;
using Books_Comments.Service.Common.Security;
using Books_Comments.Service.Dtos.Accounts;
using Books_Comments.Service.Interfaces;
using Books_Comments.Service.Interfaces.Accounts;
using Books_Comments.Service.ViewModels.Accounts;
using System.Security.Principal;

namespace Books_Comments.Service.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _repository;
    private readonly IAuthService _authService;
    private readonly IIdentityService _identity;

    public AccountService(IUnitOfWork unitOfWork, IAuthService authService,  IIdentityService identity)
    {
        this._repository = unitOfWork;
        this._authService = authService;
        _identity = identity;
    }

    public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
    {
        var emailedUser = await _repository.Users.FirstOrDefaultAsync(x => x.Email == accountLoginDto.Email);
        if (emailedUser is null) throw new Exception();

        var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, emailedUser.PasswrodHash, emailedUser.Salt);

        if (hasherResult)
        {
            string token = _authService.GenerationToken(emailedUser);
            return token;
        }
        else throw new Exception("Password is invalid");
    }

    public async Task<AccountBaseViewModel> ProfileAsync()
    {
        if (_identity.Id is not null)
            return new AccountBaseViewModel
            {
                Id = Convert.ToInt32(_identity.Id),
                UserName = _identity.UserName,
                Email = _identity.Email,
                ImagePath= _identity.ImagePath,
            };
        return null;
    }

    public async Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto)
    {
        var emailedUser = await _repository.Users.FirstOrDefaultAsync(x => x.Email == accountRegisterDto.Email);
        if (emailedUser is not null) throw new Exception();

        var hasherResult = PasswordHasher.Hash(accountRegisterDto.Password);
        var user = (User)accountRegisterDto;
        user.PasswrodHash = hasherResult.Hash;
        user.Salt = hasherResult.Salt;
        user.ImagePath = "https://img.icons8.com/bubbles/100/000000/user.png";

        _repository.Users.Add(user);
        var dbResult = await _repository.SaveChangeAsync();
        return dbResult > 0;
    }
}
