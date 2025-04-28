using Blog.Web.Models.Domain;

namespace Blog.Web.Models.ViewModels;

public class UserVM
{
    public List<UserModel> Users { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
}
