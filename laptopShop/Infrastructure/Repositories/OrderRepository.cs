using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataBaseContext _dbContext;

        public OrderRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Metoda zwracająca wszystkie zamówienia
        /// </summary>
        /// <returns>Kolekcję wszystkich zamówień</returns>
        public async Task<IEnumerable<Order>> GetAllAsync()

            => await _dbContext.Orders.ToListAsync();


        /// <summary>
        /// Metoda zwracająca konkretne zamówienie o podanym Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetByIdAsync(Guid id)

            => await _dbContext.Orders.FindAsync(id);

        /// <summary>
        /// Metoda zwracająca zamówienia użytkownika o podanym Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId)

            => await _dbContext.Orders.Where(p => p.UserId == userId).ToListAsync();

        /// <summary>
        /// Metoda asynchroniczna zwracająca zamówienia użytkownika o podanej nazwie
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetByUserNameAsync(string username)
        
            => await _dbContext.Orders.Where(p => p.User.NormalizedUserName.ToUpper() == username.ToUpper()).ToListAsync();

        /// <summary>
        /// Asynchroniczna metoda dodająca zamówienie do bazy
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Metoda asynchroniczna aktualizująca zamówienie
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Metoda asynchroniczna usuwająca zamówienie o podanym id
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null)
                return false;

            return await _dbContext.SaveChangesAsync() > 0;
        }





        /*        /// <summary>
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
                }*/
    }
}
