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
        public Task<LaptopDTO> AddNewLaptopAsync(CreateLaptopDTO newlaptop)
        {
            if (string.IsNullOrEmpty(newlaptop.Model) || newlaptop.Quantity < 0 || string.IsNullOrEmpty(newlaptop.Description))
                throw new Exception("Laptop can not be created.");

            var laptop = _mapper.Map<Laptop>(newlaptop);

            // nie działa
            // return _mapper.Map<LaptopDTO>(laptop);


        }
    }
}
