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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserOrderService(IUserOrderRepository userOrderRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userOrderRepository = userOrderRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDTO>> GetAllAsync(string userId)
        {
            var orders = await _userOrderRepository.GetAllAsync(userId);

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }
        
        // do ogaruuuuu

        public Task<OrderDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metoda sprawdzająca czy użytkownik ma prawo do danego zasobu
        /// </summary>
        /// <param name="id">Id zasobu do sprawdzenia</param>
        /// <param name="username">Nazwa użytkownika, którego uprawnienia są sprawdzane</param>
        /// <returns>true jeśli użytkownik ma uprawnienia,  false jeśli ich nie ma</returns>
        public async Task<bool> CheckPermitionAsync(Guid id, string username)
        {
            var user = await _userRepository.GetAplicationUserByNameAsync(username);
            var userId = user.Id;

            //var suborder = await _userOrderRepository.GetByIdAysnc(id);

            // tu może być potrzebny include
            //var orderUserId = suborder.Order.UserId;

            //if (orderUserId == userId)
                //return true;
           // else
                return false;
        }

    }
}
