using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels;

public class PostEditRequest
{
    [DisplayName("Post ID")]
    public Guid ID { get; set; }
    [Required]
    [DisplayName("Post Header")]
    public string Header { get; set; }
    [Required]
    [DisplayName("Post Title")]
    public string PostTitle { get; set; }
    [Required]
    [DisplayName("Post Content")]
    public string Content { get; set; }
    [DisplayName("Short Description")]
    [Required]
    public string ShortDescription { get; set; }
    [DisplayName("Featured Image")]
    [Required]
    public string FeaturedImageUrl { get; set; }
    [DisplayName("Url Handle")]
    [Required]
    public string UrlHandle { get; set; }
    [DisplayName("Published Date")]
    public DateTime PublishedDate { get; set; }
    [DisplayName("Author")]
    [Required]
    public string Author { get; set; }
    [DisplayName("Would you like to show this post? ")]
    public bool IsVisible { get; set; }
    public IEnumerable<SelectListItem> Tags { get; set; } = Enumerable.Empty<SelectListItem>();
    public string[] SelectedTags { get; set; } = Array.Empty<string>();
}
