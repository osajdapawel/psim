using Application.DTO;
using Application.Interfaces;
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

        public SuborderService(ISuborderRepository suborderRepository)
        {
            _suborderRepository = suborderRepository;
        }



        ///<inheritdoc cref="ISuborderService"/>
        public Task<IEnumerable<SuborderDTO>> GetAllSuborderOfOrderAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc cref="ISuborderService"/>
        public Task<SuborderDTO> GetSuborderByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc cref="ISuborderService"/>
        public Task<SuborderDTO> AddNewSuborderAsync(CreateSuborderDTO newSuborder)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc cref="ISuborderService"/>
        public Task<bool> DeleteSuborderAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc cref="ISuborderService"/>
        public Task<bool> UpdateSuborderAsync(UpdateSuborderDTO updateSuborder)
        {
            
            return  true;
        }
    }
}
