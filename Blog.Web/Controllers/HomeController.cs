using System.Diagnostics;
using System.Threading.Tasks;
using Blog.Web.Models;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;

    public HomeController(ILogger<HomeController> logger, IPostRepository postRepository, ITagRepository tagRepository)
    {
        _logger = logger;
        this._postRepository = postRepository;
        this._tagRepository = tagRepository;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _postRepository.GetAllAsync();
        var tags = await _tagRepository.GetAllTagsAsync();
        HomeVM homeVM = new HomeVM
        {
            Posts = posts.ToList(),
            Tags = tags.ToList(),
        };
        return View(homeVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
