using Blog.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<BlogPost> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Tag>? Likes { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}
