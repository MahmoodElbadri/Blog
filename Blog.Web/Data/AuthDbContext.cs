using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Blog.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define IDs
            var adminRoleId = "e3cb2ced-99c7-4297-bb8d-25e7f9379d81";
            var superAdminRoleId = "5000a19e-1049-47cf-a93b-44e252bdff0d";
            var userRoleId = "efcda308-8649-4985-91cd-95720c28745e";
            var superAdminUserId = "F8E1C360-5D8C-4DCF-8F10-AF4724C7BD3E";

            // Create Roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Id = superAdminRoleId,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Create Super Admin User with a STATIC security stamp
            var superAdminUser = new IdentityUser
            {
                Id = superAdminUserId,
                UserName = "superadmin@badri.com",
                Email = "superadmin@badri.com",
                NormalizedUserName = "SUPERADMIN@BADRI.COM",
                NormalizedEmail = "SUPERADMIN@BADRI.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7b15164a-a9c3-4830-86c8-38532e80ea2c"
            };

            // Set password
            var passwordHasher = new PasswordHasher<IdentityUser>();
            superAdminUser.PasswordHash = passwordHasher.HashPassword(superAdminUser, "Super@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Assign Roles to Super Admin
            var superAdminUserRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = superAdminUserId,
                    RoleId = adminRoleId
                },
                new IdentityUserRole<string>
                {
                    UserId = superAdminUserId,
                    RoleId = superAdminRoleId
                },
                new IdentityUserRole<string>
                {
                    UserId = superAdminUserId,
                    RoleId = userRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminUserRoles);
        }
    }
}