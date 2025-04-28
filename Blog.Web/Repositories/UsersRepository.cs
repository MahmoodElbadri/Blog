using Blog.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly AuthDbContext _dbContext;

    public UsersRepository(AuthDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync()
    {
        var users = await _dbContext.Users.ToListAsync();
        var superAdminUser = users.FirstOrDefault(tmp => tmp.Email == "superadmin@badri.com");
        if (superAdminUser is not null)
        {
            users.Remove(superAdminUser);
        }
        return users;
    }
}
