using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = registerVM.Name,
                    Email = registerVM.Email,
                };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    var identityRole = await _userManager.AddToRoleAsync(user, "User");
                    if (identityRole.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerVM);
        }
    }
}
