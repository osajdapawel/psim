using Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Metoda zwracająca wszystkich użytkowników aplikacji
        /// </summary>
        /// <returns>Wszyscy użytkownicy aplikacji</returns>
        Task<IEnumerable<ApplicationUser>> GetAllAplicationUsersAsync();

        /// <summary>
        /// Metoda zwracająca użytkownika o konkretnym emailu
        /// </summary>
        /// <param name="email">Email użytkownika do wyszukania</param>
        /// <returns>Obiekt typu AplicationUser</returns>
        Task<ApplicationUser> GetAplicationUserByEmailAsync(string email);

        /// <summary>
        /// Metoda zwracająca użytkownika o konkretnym id
        /// </summary>
        /// <param name="id">id użytkownika do wyszukania</param>
        /// <returns>Obiekt typu AplicationUser</returns>
        Task<ApplicationUser> GetAplicationUserByIdAsync(Guid id);

        /// <summary>
        /// Metoda sprawdzająca czy użytkownik ma prawo do danego zasobu
        /// </summary>
        /// <typeparam name="TResource">Typ zasobu do sprawdzenia</typeparam>
        /// <param name="id">Id zasobu do sprawdzenia</param>
        /// <param name="username">Nazwa użytkownika, którego uprawnienia są sprawdzane</param>
        /// <returns>true jeśli użytkownik ma uprawnienia,  false jeśli ich nie ma</returns>
        public Task<bool> CheckPermitionAsync<TResource>(Guid id, string username);
    }
}
