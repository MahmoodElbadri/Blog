using Blog.Web.Models.Domain;

namespace Blog.Web.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllAsync();
    Task<BlogPost?> GetAsync(Guid id);
    Task<BlogPost> AddAsync(BlogPost post);
    Task<BlogPost?> UpdateAsync(BlogPost post);
    Task<BlogPost?> DeleteAsync(Guid id);
}
