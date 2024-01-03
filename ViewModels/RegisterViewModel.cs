using System.ComponentModel.DataAnnotations;

namespace CVProjekt1._0.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(255)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
