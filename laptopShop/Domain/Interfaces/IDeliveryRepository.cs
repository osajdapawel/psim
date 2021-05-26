using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDeliveryRepository
    {
        /// <summary>
        /// Metoda asynchroniczna pobierająca z bazy wszystkie dostawy
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Delivery>> GetAllAsync();

        /// <summary>
        /// Metoda aynchroniczna zwracająca laptop o konkretnym id
        /// </summary>
        /// <returns></returns>
        Task<Delivery> GetByIdAsync(Guid id);

        /// <summary>
        /// Metoda asynchroniczna dodająca nową dostawę do bazy
        /// </summary>
        /// <param name="deliver"></param>
        /// <returns></returns>
        Task AddAsync(Delivery delivery);

        /// <summary>
        /// Metoda aktualizująca dostawę
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Delivery delivery);

        /// <summary>
        /// Metoda usuwająca dostawę o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid id);
    }
}
