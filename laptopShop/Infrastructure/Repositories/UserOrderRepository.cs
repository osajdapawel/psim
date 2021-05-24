using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserOrderRepository : IUserOrderRepository
    {
        private readonly DataBaseContext _dbContext;

        public UserOrderRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Metoda zwracająca zamówienia użytkownika o podanym Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetAllAsync(string userId)
        {
            return await Task.Run(() =>_dbContext.Orders.Where(o => o.UserId == userId).ToList());

        }

        /// <summary>
        /// Metoda zwracająca konkretne zamówienie użytkownika o podanym Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<Order> GetByIdAsync(string userId, Guid orderId)
        {
            var orders = await GetAllAsync(userId);
            return orders.FirstOrDefault(o => o.Id == orderId);
        }
    }
}
