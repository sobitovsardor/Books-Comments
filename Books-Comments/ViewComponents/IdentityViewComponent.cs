using Books_Comments.Service.Services.Common;
using Books_Comments.Service.ViewModels.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Books_Comments.ViewComponents;

public class IdentityViewComponent : ViewComponent
{
    private readonly IdentityService _identityService;
    public IdentityViewComponent(IdentityService identity)
    {
        this._identityService = identity;
    }
    public IViewComponentResult Invoke()
    {
        AccountBaseViewModel accountBaseViewModel = new AccountBaseViewModel()
        {
            Id = (int)_identityService.Id!.Value,
            Email = _identityService.Email,
            UserName = _identityService.UserName,
            ImagePath = _identityService.ImagePath
        };
        return View(accountBaseViewModel);
    }
}
