using System.ComponentModel.DataAnnotations;

namespace CVProjekt1._0.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
