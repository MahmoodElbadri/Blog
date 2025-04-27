namespace Blog.Web.Models.Domain;

public class Comment
{
    public Guid ID { get; set; }
    public string Description { get; set; }
    public Guid PostId { get; set; }
    public DateTime DateAdded { get; set; }
    public Guid UserID { get; set; }
}
