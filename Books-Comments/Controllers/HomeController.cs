using Books_Comments.Models;
using Books_Comments.Service.Common.Unils;
using Books_Comments.Service.Dtos.Products;
using Books_Comments.Service.Interfaces.Accounts;
using Books_Comments.Service.Interfaces.Products;
using Books_Comments.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Books_Comments.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAccountService _service;
    private readonly IProductService _productService;
    private readonly int _pageSize = 30;

    public HomeController(ILogger<HomeController> logger, IAccountService service, IProductService productService)
    {
        _logger = logger;
        _service = service;
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }

   

    //[HttpGet("bookpage")]
    //public async Task<IActionResult> BookPage([FromForm] CommentDto commentdto, int BookId, int page = 1, int bookId = 1)
    //{
    //    var result = await _productService.CreateAsync(commentdto, bookId);
    //    var result1 = await _productService.GetCommentsAsync(bookId, new PaginationParams(page, _pageSize));
    //    Tuple<CommentDto, List<CommentViewModel>> tuple = new Tuple<CommentDto, List<CommentViewModel>>(result, result1.ToList());
    //    return View("BookPage", tuple);
    //}

    //[HttpGet("bookpage")]
    //public async Task<IActionResult> BookPage(int page = 1, int bookId=1)
    //{
    //    return View("BookPage", await _productService.GetCommentsAsync(bookId, new PaginationParams(page, _pageSize)));
    //}


    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> ProfileAsync()
    {
        return View("Profile", await _service.ProfileAsync());
    }

    [HttpGet("product")]
    public async Task<IActionResult> Books(int page = 1)
    {
        var products = await _productService.GetAllAsync(new PaginationParams(page, _pageSize));
        return View("Books", products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet("bookpage")]
    public async Task<IActionResult> BookPage([FromQuery] int bookId, int page = 1)
    {
        var result = new CommentDto()
        {
            BookId = bookId,
        };
        var result1 = await _productService.GetCommentsAsync(bookId, new PaginationParams(page, _pageSize));
        Tuple<CommentDto, List<CommentViewModel>> tuple = new Tuple<CommentDto, List<CommentViewModel>>(result, result1.ToList());
        return View("BookPage", tuple);
    }

    //[HttpPost("Bookpage")]
    //public async Task<IActionResult> CommentPage(CommentDto commentDto, int BookId)
    //{
    //    var reult = await _productService.CreateAsync(commentDto, commentDto.BookId = BookId);
    //    return RedirectToAction("Bookpage", "Home", new { area = "" });
    //}
}