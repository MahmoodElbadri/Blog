using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels;

public class LoginVM
{
    [Required]
    [EmailAddress]
    [Display(Name = "User Name")]
    public string? UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
