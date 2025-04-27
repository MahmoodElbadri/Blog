using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers;

public class BlogsController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly ILikeRepository _likeRepository;

    public BlogsController(IPostRepository postRepository, ILikeRepository likeRepository)
    {
        this._postRepository = postRepository;
        this._likeRepository = likeRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string urlHandle)
    {
        var post = await _postRepository.GetByUrlHandleAsync(urlHandle);
        var blogVM = new BlogVM();
        if (post is not null)
        {
            var likes = await _likeRepository.GetTotalLikes(post.ID);
            blogVM = new BlogVM
            {
                ID = post.ID,
                Content = post.Content,
                PostTitle = post.PostTitle,
                Author = post.Author,
                FeaturedImageUrl = post.FeaturedImageUrl,
                Header = post.Header,
                PublishedDate = post.PublishedDate,
                ShortDescription = post.ShortDescription,
                UrlHandle = urlHandle,
                IsVisible = post.IsVisible,
                Tags = post.Tags,
                TotalLikes = likes,
            };
            return View(blogVM);
        }
        return View(post);
    }
}
