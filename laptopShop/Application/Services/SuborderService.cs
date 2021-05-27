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
    public class SuborderService : ISuborderService
    {
        private readonly ISuborderRepository _suborderRepository; 
        private readonly IUserRepository _userRepository; 
        private readonly IMapper _mapper;

        public SuborderService(ISuborderRepository suborderRepository, IUserRepository userRepository, IMapper mapper)
        {
            _suborderRepository = suborderRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        ///<inheritdoc cref="ISuborderService"/>
        public async Task<IEnumerable<SuborderDTO>> GetAllSuborderOfOrderAsync(Guid id)
        {
            var suborders = await _suborderRepository.GetAllSuborderOfOrderAsync(id);
            return _mapper.Map<IEnumerable<SuborderDTO>>(suborders);
        }

        ///<inheritdoc cref="ISuborderService"/>
        public async Task<SuborderDTO> GetSuborderByIdAsync(Guid id)
        {
            var suborder = await _suborderRepository.GetByIdAysnc(id);
            return  _mapper.Map<SuborderDTO>(suborder);
        }

        ///<inheritdoc cref="ISuborderService"/>
        public async Task<SuborderDTO> AddNewSuborderAsync(CreateSuborderDTO newSuborder)
        {
            var suborder = _mapper.Map<Suborder>(newSuborder);
            await _suborderRepository.AddAsync(suborder);

            return _mapper.Map<SuborderDTO>(suborder);
        }

        ///<inheritdoc cref="ISuborderService"/>
        public async Task<bool> UpdateSuborderAsync(UpdateSuborderDTO updateSuborder)
        {
            var suborder = await _suborderRepository.GetByIdAysnc(updateSuborder.Id);
            if (suborder == null)
                return false;

            var updatedSuborder = _mapper.Map(updateSuborder, suborder);

            return await _suborderRepository.UpdateAsync(updatedSuborder);

        }

        ///<inheritdoc cref="ISuborderService"/>
        public async Task<bool> DeleteSuborderAsync(Guid id)
        {
            return await _suborderRepository.DeleteAsync(id);
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

            // tu jest include
            var suborder = await _suborderRepository.GetByIdAysnc(id);

            // tu może być potrzebny include
            var orderUserId = suborder.Order.UserId;

            if (orderUserId.ToString() == userId)
                return true;
            else
                return false;
        }
    }
}
