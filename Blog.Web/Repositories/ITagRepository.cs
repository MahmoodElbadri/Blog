using Blog.Web.Models.Domain;

namespace Blog.Web.Repositories;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllTagsAsync();
    Task<Tag?> GetByIdAsync(Guid id);
    Task<Tag> AddAsync(Tag tag);
    Task<Tag?> UpdateAsync(Tag tag);
    Task<Tag?> DeleteAsync(Guid id);
}
