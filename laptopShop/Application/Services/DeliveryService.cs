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
     public class DeliveryService : IDeliveryService
     {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeliveryDTO>> GetAllDeliveriesAsync()
        {
            var deliveries = await _deliveryRepository.GetAllAsync();
            return _mapper.Map <IEnumerable<DeliveryDTO>>(deliveries);

        }

        public async Task<DeliveryDTO> GetDeliveryByIdAsync(Guid id)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(id);
            return _mapper.Map<DeliveryDTO>(delivery);
        }

        public async Task<DeliveryDTO> AddNewDeliveryAsync(CreateDeliveryDTO newDelivery)
        {
            if (string.IsNullOrEmpty(newDelivery.Type) || newDelivery.Price < 0 || newDelivery.DeliveryTime < 0 )
                throw new Exception("Laptop can not be created.");

            var delivery = _mapper.Map<Delivery>(newDelivery);
            await _deliveryRepository.AddAsync(delivery);

            return _mapper.Map<DeliveryDTO>(delivery);
        }

        public async Task<bool> UpdateSuborderAsync(DeliveryDTO newDelivery)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(newDelivery.Id);
            if (delivery == null)
                return false;

            var updatedDelivery = _mapper.Map(newDelivery, delivery);
            return await _deliveryRepository.UpdateAsync(updatedDelivery);
        }

        public async Task<bool> DeleteDeliveryAsync(Guid id)
        {
            return await _deliveryRepository.DeleteAsync(id);
        }
    }
}
