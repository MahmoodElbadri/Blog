using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Web.Models.ViewModels;

public class PostAddRequest
{
    public string Header { get; set; }
    public string PageTitle { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Author { get; set; }
    public bool IsVisible { get; set; }
    public IEnumerable<SelectListItem> Tags { get; set; }
    public string SelectedTag { get; set; }
}
