using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers;

public class BlogsController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IPostCommentRepository _postCommentRepository;

    public BlogsController(IPostRepository postRepository, ILikeRepository likeRepository
        , SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
        IPostCommentRepository postCommentRepository)
    {
        this._postRepository = postRepository;
        this._likeRepository = likeRepository;
        this._signInManager = signInManager;
        this._userManager = userManager;
        this._postCommentRepository = postCommentRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string urlHandle)
    {
        var post = await _postRepository.GetByUrlHandleAsync(urlHandle);
        var liked = false;
        var blogVM = new BlogVM();
        if (post is not null)
        {
            var likes = await _likeRepository.GetTotalLikes(post.ID);

            if (_signInManager.IsSignedIn(User))
            {
                var allLikesForPost = await _likeRepository.GetLikesForPost(post.ID);
                var userId = _userManager.GetUserId(User);
                if (userId is not null)
                {
                    var userLike = allLikesForPost.FirstOrDefault(tmp => tmp.UserID == Guid.Parse(userId));
                    liked = userLike is not null;
                }
            }

            var blogComments = await _postCommentRepository.GetCommentsForPostAsync(post.ID);

            var blogCommentsVM = new List<BlogComment>();
            foreach (var blogComment in blogComments)
            {
                blogCommentsVM.Add(new BlogComment
                {
                    UserName = (await _userManager.FindByIdAsync(blogComment.UserID.ToString())).UserName,
                    DateAdded = DateTime.Now,
                    Description = blogComment.Description
                });
            }


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
                Liked = liked,
                Comments = blogCommentsVM,
            };
            return View(blogVM);
        }
        return View(post);
    }

    [HttpPost]
    public async Task<IActionResult> Index(BlogVM blogVM)
    {
        if (_signInManager.IsSignedIn(User))
        {
            var comment = new Comment
            {
                PostId = blogVM.ID,
                Description = blogVM.Comment,
                UserID = Guid.Parse(_userManager.GetUserId(User)),
                DateAdded = DateTime.Now,
            };
            await _postCommentRepository.AddCommentAsync(comment);
            return RedirectToAction("Index", "Blogs", new { urlHandle = blogVM.UrlHandle });
        }
        return View(blogVM);
    }
}
