using Blog.Web.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Models.ViewModels;

public class BlogVM
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
    public ICollection<Tag> Tags { get; set; }
    public int TotalLikes { get; set; }
    public bool Liked { get; set; }
    public string? Comment { get; set; }
    public ICollection<BlogComment> Comments { get; set; }
}
