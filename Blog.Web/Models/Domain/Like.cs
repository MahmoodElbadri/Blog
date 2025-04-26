namespace Blog.Web.Models.Domain;

public class Like
{
    public Guid ID { get; set; }
    public Guid PostID { get; set; }
    public Guid UserID { get; set; }
}
