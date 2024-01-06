using System.ComponentModel.DataAnnotations;

namespace CVProjekt1._0.ViewModels
{
    public class UserChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
