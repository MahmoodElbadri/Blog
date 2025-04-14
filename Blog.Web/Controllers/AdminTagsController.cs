using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers;

public class AdminTagsController : Controller
{


    public AdminTagsController()
    {

    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(TagAddRequest tagAddRequest)
    {
        var tag = new Tag
        {
            Name = tagAddRequest.Name,
            DisplayName = tagAddRequest.DisplayName,
        };
        await _dbContext.Tags.AddAsync(tag);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var tags = await _dbContext.Tags.ToListAsync();
        return View(tags);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var tag = await _dbContext.Tags.FirstOrDefaultAsync(tmp => tmp.ID == id);
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
    public async Task<IActionResult> Edit(TagEditRequest tagEditRequest)
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

        var existTag = await _dbContext.Tags.FindAsync(tagEditRequest.ID);
        if (existTag != null)
        {
            existTag.Name = tagEditRequest.Name;
            existTag.DisplayName = tagEditRequest.DisplayName;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View("Edit", new { tagEditRequest.ID });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var tag = await _dbContext.Tags.FirstOrDefaultAsync(tmp => tmp.ID == id);
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
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var tag = await _dbContext.Tags.FirstOrDefaultAsync(tmp => tmp.ID == id);
        if ((tag != null))
        {
            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
