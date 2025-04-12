namespace Blog.Web.Models.Domain;

public class BlogPost
{
    public Guid ID { get; set; }
    public string Header { get; set; }
    public string PageTitle { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Author { get; set; }
    public bool IsVisible { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
