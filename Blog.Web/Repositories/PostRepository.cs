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

    public async Task<BlogPost?> GetAsync(Guid id)
    {
        return await _dbContext.Posts.Include(tmp => tmp.Tags).FirstOrDefaultAsync(tmp => tmp.ID == id);
    }

    public async Task<BlogPost?> UpdateAsync(BlogPost post)
    {
        var existedPost = _dbContext.Posts.Include(tmp => tmp.Tags).FirstOrDefault(tmp => tmp.ID == post.ID);
        if (existedPost != null)
        {
            existedPost.Header = post.Header;
            existedPost.PostTitle = post.PostTitle;
            existedPost.Content = post.Content;
            existedPost.IsVisible = post.IsVisible;
            existedPost.Tags = post.Tags;
            existedPost.PublishedDate = post.PublishedDate;
            existedPost.Author = post.Author;
            existedPost.FeaturedImageUrl = post.FeaturedImageUrl;
            existedPost.ShortDescription = post.ShortDescription;
            existedPost.UrlHandle = post.UrlHandle;
            await _dbContext.SaveChangesAsync();
            return existedPost;
        }
        return null;
    }
}
