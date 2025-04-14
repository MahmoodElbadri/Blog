using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers;

public class AdminTagsController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public AdminTagsController(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(TagAddRequest tagAddRequest)
    {
        var tag = new Tag
        {
            Name = tagAddRequest.Name,
            DisplayName = tagAddRequest.DisplayName,
        };
        _dbContext.Tags.Add(tag);
        _dbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Index()
    {
        var tags = _dbContext.Tags.ToList();
        return View(tags);
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var tag = _dbContext.Tags.FirstOrDefault(tmp => tmp.ID == id);
        if (tag != null)
        {
            var tagEditRequest = new TagEditRequest
            {
                ID = id,
                Name = tag.Name,
                DisplayName = tag.DisplayName,
            };
            return View(tagEditRequest);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Edit(TagEditRequest tagEditRequest)
    {
        if (tagEditRequest == null)
        {
            return View();
        }
        var tag = new Tag
        {
            ID = tagEditRequest.ID,
            Name = tagEditRequest.Name,
            DisplayName = tagEditRequest.DisplayName,
        };

        var existTag = _dbContext.Tags.Find(tagEditRequest.ID);
        if (existTag != null)
        {
            existTag.Name = tagEditRequest.Name;
            existTag.DisplayName = tagEditRequest.DisplayName;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Edit", new { tagEditRequest.ID });
    }

    [HttpGet]
    public IActionResult Delete(Guid id)
    {
        var tag = _dbContext.Tags.FirstOrDefault(tmp => tmp.ID == id);
        if (tag == null)
        {
            return RedirectToAction(nameof(Index));
        }
        var tagEditRequest = new TagEditRequest
        {
            Name = tag.Name,
            DisplayName = tag.DisplayName,
            ID = id
        };

        return View(tagEditRequest);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(Guid id)
    {
        var tag = _dbContext.Tags.FirstOrDefault(tmp => tmp.ID == id);
        if ((tag != null))
        {
            _dbContext.Tags.Remove(tag);
            _dbContext.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
