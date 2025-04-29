using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels;

public class TagAddRequest
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? DisplayName { get; set; }
}
