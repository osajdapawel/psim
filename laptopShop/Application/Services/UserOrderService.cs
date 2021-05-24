using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserOrderService : IUserOrderService
    {
        private readonly IUserOrderRepository _userOrderRepository;
        private readonly IMapper _mapper;

        public UserOrderService(IUserOrderRepository userOrderRepository, IMapper mapper)
        {
            _userOrderRepository = userOrderRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDTO>> GetAllAsync(string userId)
        {
            var orders = await _userOrderRepository.GetAllAsync(userId);

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetByIdAsync(string userId,Guid id)
        {
            var order = await _userOrderRepository.GetByIdAsync(userId,id);
            return _mapper.Map<OrderDTO>(order);
        }
    }
}
