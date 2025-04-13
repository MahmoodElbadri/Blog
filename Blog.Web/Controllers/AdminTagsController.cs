using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers;

public class AdminTagsController : Controller
{
    public IActionResult Add()
    {
        return View();
    }
}
