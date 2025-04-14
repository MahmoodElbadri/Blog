using Blog.Web.Data;
using Blog.Web.Models.Domain;

namespace Blog.Web.Repositories;

public class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TagRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<Tag> AddAsync(Tag tag)
    {
        await _dbContext.AddAsync(tag);
        await _dbContext.SaveChangesAsync();
        return tag;
    }

    public Task<Tag?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Tag>> GetAllTagsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tag?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Tag?> UpdateAsync(Tag tag)
    {
        throw new NotImplementedException();
    }
}
