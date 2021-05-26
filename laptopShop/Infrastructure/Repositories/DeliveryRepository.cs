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
    class DeliveryRepository : IDeliveryRepository
    {
        private readonly DataBaseContext _dbContext;

        public DeliveryRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Metoda pobierająca wszystkie laptopy
        /// </summary>
        /// <returns>wszystkie laptopy</returns>
        public async Task<IEnumerable<Delivery>> GetAllAsync()

            => await _dbContext.Deliveries.ToListAsync();


        /// <summary>
        /// Metoda zwracająca laptop o konkretnym id
        /// </summary>
        /// <param name="id">Id laptopa do pobrania</param>
        /// <returns>laptop o konkretnym id</returns>
        public async Task<Delivery> GetByIdAsync(Guid id)

            => await _dbContext.Deliveries.FindAsync(id);


        /// <summary>
        /// Metoda tworząca nowy laptop
        /// </summary>
        /// <param name="laptop"></param>
        /// <returns>Utworzony laptop</returns>
        public async Task AddAsync(Delivery delivery)
        {
            await _dbContext.Deliveries.AddAsync(delivery);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Metoda aktualizująca laptop
        /// </summary>
        /// <param name="laptop"></param>
        /// <returns>True - jeśli aktualizacja się powiodła</returns>
        public async Task<bool> UpdateAsync(Delivery delivery)
        {
            _dbContext.Deliveries.Update(delivery);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Metoda usuwająca laptop o konretnym id
        /// </summary>
        /// <param name="id">id laptopa do usunięcia</param>
        /// <returns>True - jeśli aktualizaja się powiodła</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var delivery = await _dbContext.Deliveries.FindAsync(id);
            if (delivery == null)
                return false;

            _dbContext.Deliveries.Remove(delivery);
            return await _dbContext.SaveChangesAsync() > 0;
        }

    }
}
