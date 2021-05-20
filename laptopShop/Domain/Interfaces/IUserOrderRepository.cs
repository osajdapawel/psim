using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserOrderRepository
    {
        /// <summary>
        /// Metoda zwracająca zamówienia użytkownika o podanym Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetAllAsync(string userId);

        /// <summary>
        /// Metoda zwracająca konkretne zamówienie użytkownika o podanym Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> GeAsync(string userId, Guid orderId);
    }
}
