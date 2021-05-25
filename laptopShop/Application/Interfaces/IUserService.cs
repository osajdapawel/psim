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
    }
}
