using Blog.Web.Models.Domain;

namespace Blog.Web.Repositories;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllTagsAsync(string? searchQuery = null, string? orderBy = null, string? sortBy = null,
        int pageNumber = 1, int pageSize = 100);
    Task<Tag?> GetByIdAsync(Guid id);
    Task<Tag> AddAsync(Tag tag);
    Task<Tag?> UpdateAsync(Tag tag);
    Task<Tag?> DeleteAsync(Guid id);
    Task<int> GetNumberOfTags();
}
