using System.ComponentModel.DataAnnotations;

namespace Domain.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Wymagana jest nazwa użytkownika")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Wymagane jest hasło")]
        public string Password { get; set; }
    }
}
