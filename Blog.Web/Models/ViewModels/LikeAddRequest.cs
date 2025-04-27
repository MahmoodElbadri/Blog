namespace Blog.Web.Models.ViewModels;

public class LikeAddRequest
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
}
