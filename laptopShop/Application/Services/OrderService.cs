using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Metoda asynchroniczna
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        /// <summary>
        /// Metoda asynchroniczna zwracająca zamówienie o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderDTO> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDTO>(order);
        }

        /// <summary>
        /// Metoda asynchroniczna zwracająca kolekcję zamówień użytkownika o konkretnym id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OrderDTO>> GetAllUserOrdersByUserIdAsync(Guid userId)
        {
            var userOrders = await _orderRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<OrderDTO>>(userOrders);
        }

        /// <summary>
        /// Metoda asynchroniczna zwracająca kolekcję zamówień użytkownika o konkretnej nazwie
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OrderDTO>> GetAllUserOrdersByUserNameAsync(string username)
        {
            var orders = await _orderRepository.GetByUserNameAsync(username);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        /// <summary>
        /// Metoda asynchroniczna dodająca nowe zamówienie
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public async Task<OrderDTO> AddNewOrderAsync(CreateOrderDTO newOrder)
        {
            var order = _mapper.Map<Order>(newOrder);

            await _orderRepository.AddAsync(order);

            return _mapper.Map<OrderDTO>(order);
        }

        /// <summary>
        /// Metoda asynchroniczna aktualizująca zamówienie o konkretnym id
        /// </summary>
        /// <param name="updateSuborder"></param>
        /// <returns></returns>
        public async Task<bool> UpdateOrderAsync(UpdateOrderDTO updateOrder)
        {
            var order = await _orderRepository.GetByIdAsync(updateOrder.Id);
            if (order == null)
                return false;
            var updatedOrder = _mapper.Map(updateOrder, order);
            return await _orderRepository.UpdateAsync(updatedOrder);
        }

        /// <summary>
        /// Metoda asynchroniczna usuwająca zamówienie o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            return await _orderRepository.DeleteAsync(id);
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
