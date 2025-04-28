using Blog.Web.Data;
using Microsoft.AspNetCore.Identity;

namespace Blog.Web.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly AuthDbContext _dbContext;

    public UsersRepository(AuthDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public Task<IEnumerable<IdentityUser>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }
}
