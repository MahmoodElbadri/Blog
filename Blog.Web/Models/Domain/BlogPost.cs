using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Models.Domain;

public class BlogPost
{
    public Guid ID { get; set; }
    public string Header { get; set; }
    [Column("PageTitle")]
    public string PostTitle { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Author { get; set; }
    public bool IsVisible { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Like>? Likes { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}
