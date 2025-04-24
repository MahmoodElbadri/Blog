using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Data;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var adminRoleID = "e3cb2ced-99c7-4297-bb8d-25e7f9379d81";
        var superAdminRoleID = "5000a19e-1049-47cf-a93b-44e252bdff0d";
        var userRoleID = "efcda308-8649-4985-91cd-95720c28745e";
        var roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Id = adminRoleID,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = adminRoleID,
            },
            new IdentityRole
            {
                Id = superAdminRoleID,
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                ConcurrencyStamp = superAdminRoleID,
            },
            new IdentityRole
            {
                Id = userRoleID,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = userRoleID,
            }
        };
    }
}
