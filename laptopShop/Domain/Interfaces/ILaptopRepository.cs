using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Laptop
    /// </summary>
    public interface ILaptopRepository
    {
        /// <summary>
        /// Metoda asynchroniczna zwracająca laptopy
        /// </summary>
        /// <returns>Lista laptopów</returns>
        Task<IEnumerable<Laptop>> GetAllAsync();

        /// <summary>
        /// Metoda asynchroniczna zwracająca laptop o konkretnym id
        /// </summary>
        /// <param name="id">Id laptopa</param>
        /// <returns>Laptop o konkretnym id</returns>
        Task<Laptop> GetByIdAsync(Guid id);

        /// <summary>
        /// Metoda asynchroniczna dodająca laptop
        /// </summary>
        /// <param name="laptop"></param>
        /// <returns></returns>
        Task addAsyc(Laptop laptop);

        Task<bool> UpdateAsync(Laptop laptop);

        Task<bool> DeleteAsync(Guid id);
    }
}
