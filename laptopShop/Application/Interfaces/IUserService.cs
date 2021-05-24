using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Funkcja zwracająca wszystkich użytkowników
        /// </summary>
        /// <returns>Kolekcję obiektów UserDTO</returns>
        Task<IEnumerable<UserDTO>> GetAllAsync();

        /// <summary>
        /// Funkcja zwracająca użytkownika o konkretnym emailu
        /// </summary>
        /// <param name="email"></param>
        /// <returns>obiekt UserDTO</returns>
        Task<UserDTO> GetUserByEmailAsync(string email);

        /// <summary>
        /// Funkcja zwracająca użytkownika o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>obiekt UserDTO</returns>
        Task<UserDTO> GetUserByIdAsync(Guid id);

        /// <summary>
        /// Metoda określająca czy użytkownik ma prawo do danego zasobu
        /// </summary>
        /// <typeparam name="TResource">Typ zasobu do sprawdzenia</typeparam>
        /// <param name="id">Id zasobu do sprawdzenia</param>
        /// <param name="username">Nazwa użytkownika, którego uprawnienia są sprawdzane</param>
        /// <returns>true jeśli użytkownik ma uprawnienia,  false jeśli ich nie ma</returns>
        public Task<bool> HasPermition<TResource>(Guid id, string username);
    }
}
