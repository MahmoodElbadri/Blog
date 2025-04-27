using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikesController : ControllerBase
{
    private readonly ILikeRepository _likeRepository;

    public LikesController(ILikeRepository likeRepository)
    {
        this._likeRepository = likeRepository;
    }
    [HttpPost]
    public async Task<IActionResult> LikePost(LikeAddRequest likeAddRequest)
    {
        var model = new Like
        {
            PostID = likeAddRequest.PostId,
            UserID = likeAddRequest.UserId
        };
        await _likeRepository.AddLikeAsync(model);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetLikes(Guid id)
    {
        var likes = await _likeRepository.GetTotalLikes(id);
        return Ok(likes);
    }
}
