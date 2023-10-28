using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is requered!")]
    [EmailAddress(ErrorMessage = "Invalid format email.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is requered!")]
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string ReturnUrl{ get; set; }
}
