using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IMapper _mapper;

        public LaptopService(ILaptopRepository laptopRepository, IMapper mapper)
        {
            _laptopRepository = laptopRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LaptopDTO>> GetAllLaptopsAsync()
        {
            var laptops = await _laptopRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<LaptopDTO>>(laptops);
        }

        public async Task<LaptopDTO> GetLaptopByIdAsync(Guid id)
        {
            var laptop = await _laptopRepository.GetByIdAsync(id);
            return _mapper.Map<LaptopDTO>(laptop);
        }
    }
}
