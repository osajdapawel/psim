using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LaptopRepository : ILaptopRepository
    {
        private readonly DbContext _dbContext;



        public async Task<IEnumerable<Laptop>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Laptop> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task addAsyc(Laptop laptop)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Laptop laptop)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
