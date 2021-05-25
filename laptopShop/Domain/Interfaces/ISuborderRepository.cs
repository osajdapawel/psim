using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISuborderRepository
    {
        /// <summary>
        /// Metoda asynchroniczna pobierająca z bazy danych kolekcje podzamówień zamówienia o konkretnym id
        /// </summary>
        /// <param name="id">Id zamówienia, którego podzamówienia mają być zwrócone</param>
        /// <returns>Kolekcja podzamówień danego zamówienia</returns>
        public Task<IEnumerable<Suborder>> GetAllSuborderOfOrderAsync(Guid id);

        /// <summary>
        /// Metoda asynchroniczna zwracająca podzamówienie o konkretnym id
        /// </summary>
        /// <param name="id">Id podzamówienia, które ma zostać zwrócone</param>
        /// <returns>podzamówienie o konkretnym id</returns>
        public Task<Suborder> GetByIdAysnc(Guid id);

        /// <summary>
        /// Asynchroniczna metoda dodająca do bazy danych nowe podzamówienie
        /// </summary>
        /// <param name="suborder">Podzamówienie do dodania</param>
        /// <returns></returns>
        public Task AddAsync(Suborder suborder);

        /// <summary>
        /// Asynchroniczna metoda aktualizująca podzamówienie
        /// </summary>
        /// <param name="suborder"></param>
        /// <returns>true - jeśli operacja aktualizacji powiodła się</returns>
        public Task<bool> UpdateAsync(Suborder suborder);

        /// <summary>
        /// Metoda asynchroniczna usuwająca podzamówienie o konkretym id
        /// </summary>
        /// <param name="id">Id podzamówienia do usunięcia</param>
        /// <returns>true - jeśli operacja aktualizacji usuwania się</returns>
        public Task<bool> DeleteAsync(Guid id);

    }
}
