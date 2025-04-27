using Blog.Web.Models.Domain;

namespace Blog.Web.Repositories;

public interface IPostCommentRepository
{
    Task<Comment> AddCommentAsync(Comment comment);
    Task<IEnumerable<Comment>> GetCommentsForPostAsync(Guid postId);
}
