using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly ITagRepository _tagRepository;
        private readonly IPostRepository _postRepository;

        public PostsController(ITagRepository tagRepository, IPostRepository postRepository)
        {
            this._tagRepository = tagRepository;
            this._postRepository = postRepository;
        }
        public async Task<IActionResult> Index()
        {
            var posts = await _postRepository.GetAllAsync();
            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            var model = new PostAddRequest
            {
                Tags = tags.Select(tmp => new SelectListItem
                {
                    Text = tmp.Name,
                    Value = tmp.ID.ToString(),
                })
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostAddRequest request)
        {
            var post = new BlogPost
            {
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                Header = request.Header,
                IsVisible = request.IsVisible,
                PostTitle = request.PostTitle,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
            };
            var selectedTags = new List<Tag>();
            foreach (var selectedTagId in request.SelectedTags)
            {
                var selectedTagIdAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await _tagRepository.GetByIdAsync(selectedTagIdAsGuid);
                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }
            post.Tags = selectedTags;

            await _postRepository.AddAsync(post);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var post = await _postRepository.GetAsync(id);
            if (post != null)
            {
                var postEditRequest = new PostEditRequest
                {
                    ID = id,
                    Author = post.Author,
                    Content = post.Content,
                    FeaturedImageUrl = post.FeaturedImageUrl,
                    Header = post.Header,
                    IsVisible = post.IsVisible,
                    PostTitle = post.PostTitle,
                    PublishedDate = post.PublishedDate,
                    ShortDescription = post.ShortDescription,
                    UrlHandle = post.UrlHandle,
                };
                postEditRequest.Tags = post.Tags.Select(tmp => new SelectListItem
                {
                    Text = tmp.Name,
                    Value = tmp.ID.ToString(),
                });
                postEditRequest.SelectedTags = post.Tags.Select(tmp => tmp.ID.ToString()).ToArray();
                return View(postEditRequest);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostEditRequest request)
        {
            var post = new BlogPost
            {
                ID = request.ID,
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                Header = request.Header,
                IsVisible = request.IsVisible,
                PostTitle = request.PostTitle,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
            };
            var selectedTags = new List<Tag>();
            foreach (var tag in request.Tags)
            {
                Guid guid = Guid.Parse(tag.Value);
                var existingTag = await _tagRepository.GetByIdAsync(guid);
                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }
            post.Tags = selectedTags;
            var updatedPost = await _postRepository.UpdateAsync(post);
            if (updatedPost != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Edit", new { id = post.ID });
        }
    }
}
