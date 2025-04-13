using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers;

public class AdminTagsController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public AdminTagsController(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(TagAddRequest tagAddRequest)
    {
        var tag = new Tag
        {
            Name = tagAddRequest.Name,
            DisplayName = tagAddRequest.DisplayName,
        };
        _dbContext.Tags.Add(tag);
        _dbContext.SaveChanges();
        return View();
    }
}
