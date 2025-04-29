using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminTagsController : Controller
{
    private readonly ITagRepository _tagRepository;

    public AdminTagsController(ITagRepository tagRepository)
    {
        this._tagRepository = tagRepository;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(TagAddRequest tagAddRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(tagAddRequest);
        }
        var tag = new Tag
        {
            Name = tagAddRequest.Name,
            DisplayName = tagAddRequest.DisplayName,
        };
        await _tagRepository.AddAsync(tag);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? searchQuery, string? orderBy, string? sortBy, int pageSize = 3, int pageNumber = 1
        )
    {
        var tags = await _tagRepository.GetAllTagsAsync(searchQuery, sortBy: sortBy,
            orderBy: orderBy, pageNumber: pageNumber, pageSize: pageSize);
        var totalRecords = await _tagRepository.GetNumberOfTags();
        var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        if (pageNumber > totalPages)
        {
            pageNumber = totalPages;
        }
        if (pageNumber < 1)
        {
            pageNumber = 1;
        }

        ViewBag.TotalPages = totalPages;
        ViewBag.SearchQuery = searchQuery;
        ViewBag.OrderBy = orderBy;
        ViewBag.SortBy = sortBy;
        ViewBag.PageSize = pageSize;
        ViewBag.PageNumber = pageNumber;
        ViewBag.CurrentPage = pageNumber;
        return View(tags);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
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
        if (!ModelState.IsValid)
        {
            //Show failure toast
            return View(tagEditRequest);
        }
        var tag = new Tag
        {
            ID = tagEditRequest.ID,
            Name = tagEditRequest.Name,
            DisplayName = tagEditRequest.DisplayName,
        };

        var existTag = await _tagRepository.UpdateAsync(tag);
        if (existTag != null)
        {
            //Show Suucess toast
        }
        else
        {
            //Show failure toast
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
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
        var tag = await _tagRepository.DeleteAsync(id);
        if ((tag != null))
        {
            //show failure notification
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("Edit", new { id = id = tag.ID });
    }
}
