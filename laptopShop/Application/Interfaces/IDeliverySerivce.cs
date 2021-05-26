using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDeliveryService
    {
        /// <summary>
        /// Metoda asynchroniczna zwracająca kolekcję dostaw
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<DeliveryDTO>> GetAllDeliveriesAsync();

        /// <summary>
        /// Metoda asynchroniczna zwracjąca dostawę o konkretynm id
        /// </summary>
        /// <returns>Obietk typu DeliveryDTO</returns>
        public Task<DeliveryDTO> GetDeliveryById(Guid id);

        /// <summary>
        /// Metoda asynchroniczna dodająca nową dostawę
        /// </summary>
        /// <param name="newDelivery"></param>
        /// <returns></returns>
        public Task<DeliveryDTO> AddNewDeliveryAsync(CreateDeliveryDTO newDelivery);

        /// <summary>
        /// Metoda asynchroniczna aktualizująca dostawę
        /// </summary>
        /// <returns></returns>
        public Task<bool> UpdateSuborderAsync(DeliveryDTO newDelivery);

        /// <summary>
        /// Metoda asynchroniczna usuwająca dostawe o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> DeleteDeliveryAsync(Guid id);
    }
}
