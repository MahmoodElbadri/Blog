using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers;

public class AccountsController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
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
                UserName = registerVM.UserName,
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

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (ModelState.IsValid)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password,
                isPersistent: false, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        ModelState.AddModelError("", "Username or password is incorrect");
        return View(loginVM);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }

}
