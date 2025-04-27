using Blog.Web.Models.Domain;

namespace Blog.Web.Repositories;

public interface ILikeRepository
{
    Task<int> GetTotalLikes(Guid postId);
    Task<Like> AddLikeAsync(Like like);
}
