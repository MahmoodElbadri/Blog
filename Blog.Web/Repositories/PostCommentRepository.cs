using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Repositories;

public class PostCommentRepository : IPostCommentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PostCommentRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        await _dbContext.Comments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task<IEnumerable<Comment>> GetCommentsForPostAsync(Guid postId)
    {
        return await _dbContext.Comments.Where(tmp => tmp.PostId == postId).ToListAsync();
    }
}
