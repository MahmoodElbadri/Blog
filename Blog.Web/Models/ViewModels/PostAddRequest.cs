using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels;

public class PostAddRequest
{
    [Required]
    [Display(Name = "Post Header")]
    public string? Header { get; set; }
    [Required]
    [Display(Name = "Post Title")]
    public string? PageTitle { get; set; }
    [Required]
    [Display(Name = "Post Content")]
    public string? Content { get; set; }
    [Required]
    [Display(Name = "Post Short Description")]
    public string? ShortDescription { get; set; }
    [Required]
    [Display(Name = "Post Featured Image Url")]
    public string? FeaturedImageUrl { get; set; }
    [Required]
    [Display(Name = "Post Url Handle")]
    public string? UrlHandle { get; set; }
    [Required]
    [Display(Name = "Post Publish Date")]
    public DateTime PublishedDate { get; set; }
    [Required]
    [Display(Name = "Post Author")]
    public string? Author { get; set; }
    [Required]
    [Display(Name = "Would you like to show this post?")]
    public bool IsVisible { get; set; }
    [Required]
    [Display(Name = "Post Tags")]
    public IEnumerable<SelectListItem> Tags { get; set; }
    public string[] SelectedTags { get; set; } = Array.Empty<string>();
}
