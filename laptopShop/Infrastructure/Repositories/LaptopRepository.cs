using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class LaptopRepository : ILaptopRepository
    {
        private readonly DataBaseContext _dbContext;

        public LaptopRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Metoda pobierająca wszystkie laptopy
        /// </summary>
        /// <returns>wszystkie laptopy</returns>
        public async Task<IEnumerable<Laptop>> GetAllAsync()
          
            => await _dbContext.Laptops.ToListAsync();


        /// <summary>
        /// Metoda zwracająca laptop o konkretnym id
        /// </summary>
        /// <param name="id">Id laptopa do pobrania</param>
        /// <returns>laptop o konkretnym id</returns>
        public async Task<Laptop> GetByIdAsync(Guid id)

            => await _dbContext.Laptops.SingleOrDefaultAsync(p => p.Id == id);

        /// <summary>
        /// Metoda tworząca nowy laptop
        /// </summary>
        /// <param name="laptop"></param>
        /// <returns>Utworzony laptop</returns>
        public async Task addAsyc(Laptop laptop)
        {
            await _dbContext.Laptops.AddAsync(laptop);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Metoda aktualizująca laptop
        /// </summary>
        /// <param name="laptop"></param>
        /// <returns>True - jeśli aktualizacja się powiodła</returns>
        public async Task<bool> UpdateAsync(Laptop laptop)
        {
            _dbContext.Laptops.Update(laptop);
            //return await _dbContext.SaveChangesAsync() > 0;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Metoda usuwająca laptop o konretnym id
        /// </summary>
        /// <param name="id">id laptopa do usunięcia</param>
        /// <returns>True - jeśli aktualizaja się powiodła</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var laptop = await _dbContext.Laptops.FindAsync(id);
            if (laptop == null)
                return false;
            _dbContext.Laptops.Remove(laptop);
            
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}


