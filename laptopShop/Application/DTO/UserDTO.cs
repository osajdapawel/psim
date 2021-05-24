using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserDTO
    {
        [DisplayName("Id użytkownika")]
        public virtual Guid Id { get; set; }

        [DisplayName("Nazwa użytkownika")]
        public virtual string UserName { get; set; }

        [DisplayName("Imię")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        public string LastName { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }

        [DisplayName("Numer telefonu")]
        public virtual string PhoneNumber { get; set; }

        [DisplayName("Adres email")]
        public virtual string Email { get; set; }

        [DisplayName("Potwiedzenie adresu email")]
        public virtual bool EmailConfirmed { get; set; }
    }
}
