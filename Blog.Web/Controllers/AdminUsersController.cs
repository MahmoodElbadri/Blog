using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminUsersController : Controller
{
    private readonly IUsersRepository _usersRepository;

    public AdminUsersController(IUsersRepository usersRepository)
    {
        this._usersRepository = usersRepository;
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
}