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
    class SuborderRepository : ISuborderRepository
    {
        private readonly DataBaseContext _dbContext;

        public SuborderRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Suborder>> GetAllSuborderOfOrderAsync(Guid id)
        {
            var suborders = await _dbContext.Suborders.Where(p => p.Id == id).ToListAsync();
            return suborders;
        }

        public async Task<Suborder> GetByIdAysnc(Guid id)
        {
            var suborder = await _dbContext.Suborders.FindAsync(id);
            return suborder;
        }

        public async Task AddAsync(Suborder suborder)
        {
            await _dbContext.Suborders.AddAsync(suborder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Suborder suborder)
        {
            _dbContext.Suborders.Update(suborder);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var suborder = await _dbContext.Suborders.FindAsync(id);
            if (suborder == null)
                return false;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
