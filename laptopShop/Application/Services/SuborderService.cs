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
    class SuborderService : ISuborderService
    {
        private readonly ISuborderRepository _suborderRepository; 
        private readonly IMapper _mapper;

        public SuborderService(ISuborderRepository suborderRepository, IMapper mapper)
        {
            _suborderRepository = suborderRepository;
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
            throw new NotImplementedException();
        }

        ///<inheritdoc cref="ISuborderService"/>
        public async Task<SuborderDTO> AddNewSuborderAsync(CreateSuborderDTO newSuborder)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc cref="ISuborderService"/>
        public async Task<bool> UpdateSuborderAsync(UpdateSuborderDTO updateSuborder)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc cref="ISuborderService"/>
        public async Task<bool> DeleteSuborderAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
