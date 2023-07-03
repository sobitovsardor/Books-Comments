using Books_Comments.Service.Common.Helpers;
using Books_Comments.Service.Dtos.Accounts;
using Books_Comments.Service.Interfaces.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books_Comments.Controllers;


[Route("accounts")]
public class AccountController : Controller
{
    private IAccountService _service;

    public AccountController(IAccountService accountService)
    {
        this._service = accountService;
    }


    [HttpGet("Login")]
    public ViewResult Login()
    {
        return View("Login");
    }

    [HttpGet("Registor")]
    public ViewResult Registor()
    {
        return View("Registor");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
    {
        string token = await _service.LoginAsync(accountLoginDto);
        HttpContext.Response.Cookies.Append("Acces-Token", token, new CookieOptions()
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict
        });
        return RedirectToAction("Index", "Home", new { area = "" });
    }


    [HttpPost("registor")]
    public async Task<IActionResult> RegistorAsync(AccountRegisterDto accountRegsitorDto)
    {
        if (ModelState.IsValid)
        {
            bool result = await _service.RegisterAsync(accountRegsitorDto);
            if (result)
            {
                return RedirectToAction("login", "accounts", new { area = "" });
            }
            else
            {
                return Registor();
            }
        }
        else return Registor();
    }

    [HttpGet("logout")]
    public IActionResult LogOut()
    {
        HttpContext.Response.Cookies.Append("Acces-Token", "", new CookieOptions()
        {
            Expires = TimeHelper.GetCurrentServerTime().AddDays(-1)
        });
        return RedirectToAction("Login", "Accounts", new { area = "" });
    }
}
