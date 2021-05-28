using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Metoda zwracająca wszystkie zamówienia
        /// </summary>
        /// <returns>Kolekcję wszystkich zamówień</returns>
        public Task<IEnumerable<Order>> GetAllAsync();

        /// <summary>
        /// Metoda zwracająca konkretne zamówienie o podanym Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Order> GetByIdAsync(Guid id);

        /// <summary>
        /// Metoda zwracająca zamówienia użytkownika o podanym Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Order>> GetByUserIdAsync(string userId);

        /// <summary>
        /// Metoda asynchroniczna zwracająca zamówienia użytkownika o podanej nazwie
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Task<IEnumerable<Order>> GetByUserNameAsync(string username);

        /// <summary>
        /// Asynchroniczna metoda dodająca zamówienie do bazy
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Task AddAsync(Order order);

        /// <summary>
        /// Metoda asynchroniczna aktualizująca zamówienie
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(Order order);

        /// <summary>
        /// Metoda asynchroniczna usuwająca zamówienie o podanym id
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(Guid id);


    }
}
