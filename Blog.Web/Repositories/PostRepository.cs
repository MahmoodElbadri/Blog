using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Repositories;

public class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PostRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<BlogPost> AddAsync(BlogPost post)
    {
        await _dbContext.AddAsync(post);
        await _dbContext.SaveChangesAsync();
        return post;
    }

    public Task<BlogPost?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _dbContext.Posts.Include(tmp => tmp.Tags).ToListAsync();
    }

    public Task<BlogPost?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost?> UpdateAsync(BlogPost post)
    {
        throw new NotImplementedException();
    }
}
