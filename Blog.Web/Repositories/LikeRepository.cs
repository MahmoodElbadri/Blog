
using Blog.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LikeRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<int> GetTotalLikes(Guid postId)
    {
        return await _dbContext.Likes.Where(tmp => tmp.PostID == postId)?.CountAsync();
    }
}
