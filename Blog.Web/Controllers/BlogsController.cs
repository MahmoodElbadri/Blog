using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers;

public class BlogsController : Controller
{
    private readonly IPostRepository _postRepository;

    public BlogsController(IPostRepository postRepository)
    {
        this._postRepository = postRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string urlHandle)
    {
        var post = await _postRepository.GetByUrlHandleAsync(urlHandle);
        return View(post);
    }
}
