using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAllAsync(string userId);

        public Task<OrderDTO> GetByIdAsync(Guid id);

        public Task<bool> CheckPermitionAsync(Guid id, string username);

    }
}
