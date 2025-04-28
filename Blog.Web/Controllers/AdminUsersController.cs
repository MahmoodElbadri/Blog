using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers;

public class AdminUsersController : Controller
{
    private readonly IUsersRepository _usersRepository;

    public AdminUsersController(IUsersRepository usersRepository)
    {
        this._usersRepository = usersRepository;
    }

    public async Task<IActionResult> List()
    {
        // Get users from repository
        var users = await _usersRepository.GetAllUsersAsync();

        // Create view model
        var userVM = new UserVM();
        userVM.Users = new List<UserModel>();

        // Map the returned users to UserModel
        foreach (var user in users)
        {
            // Make sure to map from the correct type (likely IdentityUser)
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