namespace Blog.Web.Models.Domain;

public class Comment
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public Guid PostId { get; set; }
    public DateTime DateAdded { get; set; }
}
