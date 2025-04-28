using Microsoft.AspNetCore.Identity;

namespace Blog.Web.Repositories;

public interface IUsersRepository
{
    Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
}
