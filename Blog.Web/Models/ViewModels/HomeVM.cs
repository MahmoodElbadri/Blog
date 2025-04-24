using Blog.Web.Models.Domain;

namespace Blog.Web.Models.ViewModels;

public class HomeVM
{
    public List<BlogPost>? Posts { get; set; }
    public List<Tag>? Tags { get; set; }
}
