using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Web.Models.ViewModels;

public class PostEditRequest
{
    public Guid ID { get; set; }
    public string Header { get; set; }
    public string PostTitle { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Author { get; set; }
    public bool IsVisible { get; set; }
    public IEnumerable<SelectListItem> Tags { get; set; } = Enumerable.Empty<SelectListItem>();
    public string[] SelectedTags { get; set; } = Array.Empty<string>();
}
