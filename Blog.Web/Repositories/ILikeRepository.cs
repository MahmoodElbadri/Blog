namespace Blog.Web.Repositories;

public interface ILikeRepository
{
    Task<int> GetTotalLikes(Guid postId);
}
