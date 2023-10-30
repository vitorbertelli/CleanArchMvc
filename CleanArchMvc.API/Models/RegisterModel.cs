using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.API.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Email is requered!")]
    [EmailAddress(ErrorMessage = "Invalid format email.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is requered!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password don't match.")]
    public string ConfirmPassword { get; set; }
}
