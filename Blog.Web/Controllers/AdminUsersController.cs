using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminUsersController : Controller
{
    private readonly IUsersRepository _usersRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public AdminUsersController(IUsersRepository usersRepository,
        UserManager<IdentityUser> userManager)
    {
        this._usersRepository = usersRepository;
        this._userManager = userManager;
    }

    public async Task<IActionResult> List()
    {
        var users = await _usersRepository.GetAllUsersAsync();

        var userVM = new UserVM();
        userVM.Users = new List<UserModel>();
        foreach (var user in users)
        {
            userVM.Users.Add(new UserModel
            {
                Email = user.Email,
                ID = Guid.Parse(user.Id),
                Name = user.UserName
            });
        }

        return View(userVM);
    }

    [HttpPost]
    public async Task<IActionResult> List(UserVM userVM)
    {
        var user = new IdentityUser
        {
            Email = userVM.Email,
            UserName = userVM.UserName,
        };
        var result = await _userManager.CreateAsync(user, userVM.Password);
        if (result is not null)
        {
            if (result.Succeeded)
            {
                var roles = new List<string>() { "User" };
                if (userVM.IsAdmin)
                {
                    roles.Add("Admin");
                }
                result = await _userManager.AddToRolesAsync(user, roles);
                if (result.Succeeded && result is not null)
                {
                    return RedirectToAction("List");
                }
            }
        }
        return View(userVM);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is not null)
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded && result is not null)
            {
                return RedirectToAction("List");
            }
        }
        return View();
    }
}