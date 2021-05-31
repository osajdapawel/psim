using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Metoda asynchroniczna zwracająca wszystkie zamówienia
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();

        /// <summary>
        /// Metoda asynchroniczna zwracająca zamówienie o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<OrderDTO> GetOrderByIdAsync(Guid id);

        /// <summary>
        /// Metoda asynchroniczna zwracająca kolekcję zamówień użytkownika o konkretnym id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<IEnumerable<OrderDTO>> GetAllUserOrdersByUserIdAsync(string userId);

        /// <summary>
        /// Metoda asynchroniczna zwracająca kolekcję zamówień użytkownika o konkretnej nazwie
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Task<IEnumerable<OrderDTO>> GetAllUserOrdersByUserNameAsync(string username);

        /// <summary>
        /// Metoda asynchroniczna dodająca nowe zamówienie
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public Task<OrderDTO> AddNewOrderAsync(CreateOrderDTO newOrder);

        /// <summary>
        /// Metoda asynchroniczna aktualizująca zamówienie o konkretnym id
        /// </summary>
        /// <param name="updateSuborder"></param>
        /// <returns></returns>
        public Task<bool> UpdateOrderAsync(UpdateOrderDTO updateOrder);

        /// <summary>
        /// Metoda asynchroniczna usuwająca zamówienie o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> DeleteOrderAsync(Guid id);

        /// <summary>
        /// Metoda asynchroniczna sprawdzająca czy użytkownik ma prawo do danego zasobu
        /// </summary>
        /// <param name="id">Id zasobu do sprawdzenia</param>
        /// <param name="username">Nazwa użytkownika, którego uprawnienia są sprawdzane</param>
        /// <returns>true jeśli użytkownik ma uprawnienia,  false jeśli ich nie ma</returns>
        public Task<bool> CheckPermitionAsync(Guid id, string username);

        /// <summary>
        /// Metoda asynchroniczna potwierdzająca zakup danego zamówienia - odejmuje od liczby laptopów na stanie liczbę zakupionych lapotopów w poszczególnym subordersie
        /// </summary>
        /// <param name="id">Id zamówienia do potwierdzenia</param>
        /// <returns>True - jeśli udało się potwierdzić zamówienie - jest wystarczająco laptopów na stanie, false - jeśli nie udało się potwierdzić zamówienia</returns>
        public Task<IEnumerable<SuborderDTO>> ConfirmPurchaseAsync(Guid id);
    }
}
