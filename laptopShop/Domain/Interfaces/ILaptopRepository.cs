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
        Task AddAsyc(Laptop laptop);

        /// <summary>
        /// Metoda aktualizująca laptop
        /// </summary>
        /// <param name="laptop"></param>
        /// <returns>True - jeśli aktualizacja się powiodła</returns>
        Task<bool> UpdateAsync(Laptop laptop);

        /// <summary>
        /// Metoda usuwająca laptop o konretnym id
        /// </summary>
        /// <param name="id">id laptopa do usunięcia</param>
        /// <returns>True - jeśli aktualizaja się powiodła</returns>
        Task<bool> DeleteAsync(Guid id);
    }
}
