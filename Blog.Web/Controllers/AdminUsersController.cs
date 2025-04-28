using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers;

public class AdminUsersController : Controller
{
    public IActionResult List()
    {
        return View();
    }
}
