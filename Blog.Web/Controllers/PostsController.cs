using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Blog.Web.Controllers;

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

        if (post == null)
            return NotFound();

        var allTags = await _tagRepository.GetAllTagsAsync();

        var model = new PostEditRequest
        {
            ID = post.ID,
            Header = post.Header,
            PostTitle = post.PostTitle,
            Content = post.Content,
            ShortDescription = post.ShortDescription,
            FeaturedImageUrl = post.FeaturedImageUrl,
            UrlHandle = post.UrlHandle,
            PublishedDate = post.PublishedDate,
            Author = post.Author,
            IsVisible = post.IsVisible,

            SelectedTags = post.Tags.Select(t => t.ID.ToString()).ToArray(),

            Tags = allTags.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.ID.ToString()
            }).ToList()
        };

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(PostEditRequest request)
    {
        if (!ModelState.IsValid)
        {
            var allTags = await _tagRepository.GetAllTagsAsync();

            request.Tags = allTags.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.ID.ToString(),
                Selected = request.SelectedTags != null && request.SelectedTags.Contains(t.ID.ToString())
            }).ToList();

            return View(request);
        }

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
        foreach (var tagId in request.SelectedTags)
        {
            if (Guid.TryParse(tagId, out var guid))
            {
                var existingTag = await _tagRepository.GetByIdAsync(guid);
                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
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


    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
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
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(PostEditRequest post)
    {
        await _postRepository.DeleteAsync(post.ID);
        return RedirectToAction(nameof(Index));
    }
}
