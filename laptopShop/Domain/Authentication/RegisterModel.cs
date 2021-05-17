using System.ComponentModel.DataAnnotations;

namespace Domain.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Wymagana jest nazwa użytkownika")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Wymagane jest hasło")]
        public string Password { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


    }
}
