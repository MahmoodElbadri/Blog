using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels;

public class LoginVM
{
    [Required]
    [Display(Name = "User UserName")]
    public string? UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public string? ReturnUrl { get; set; }
}
