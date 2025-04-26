using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels;

public class RegisterVM
{
    [Required]
    [StringLength(50)]
    [Display(Name = "User Name")]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(50)]
    [Display(Name = "Email Address")]
    public string? Email { get; set; }

    [Required]
    [StringLength(50)]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
