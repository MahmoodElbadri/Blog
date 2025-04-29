using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Tag?> DeleteAsync(Guid id)
    {
        var existingTag = await _dbContext.Tags.FindAsync(id);
        if (existingTag != null)
        {
            _dbContext.Tags.Remove(existingTag);
            await _dbContext.SaveChangesAsync();
            return existingTag;
        }
        return null;
    }

    public async Task<IEnumerable<Tag>> GetAllTagsAsync(string? searchQuery)
    {
        //return await _dbContext.Tags.ToListAsync();
        var query = _dbContext.Tags.AsQueryable();
        if (!string.IsNullOrEmpty(searchQuery))
        {
            query = query.Where(tmp => tmp.Name.Contains(searchQuery) || tmp.DisplayName.Contains(searchQuery));
        }
        return await query.ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        var tag = await _dbContext.Tags.FirstOrDefaultAsync(tmp => tmp.ID == id);
        if (tag == null) { return null; }
        return tag;
    }

    public async Task<Tag?> UpdateAsync(Tag tag)
    {
        var existingTag = await _dbContext.Tags.FirstOrDefaultAsync(tmp => tmp.ID == tag.ID);
        if (existingTag != null)
        {
            existingTag.Name = tag.Name;
            existingTag.DisplayName = tag.DisplayName;
            await _dbContext.SaveChangesAsync();
            return tag;
        }
        return null;
    }
}
