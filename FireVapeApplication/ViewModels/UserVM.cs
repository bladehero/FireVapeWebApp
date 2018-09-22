using System.ComponentModel.DataAnnotations;

namespace FireVapeApplication.ViewModels
{
    public class UserVM
    {
        [Display(Name = "Логин:")]
        [Required]
        public string Username { get; set; }
        [Display(Name = "Пароль:")]
        [Required]
        public string Password { get; set; }
    }
}
