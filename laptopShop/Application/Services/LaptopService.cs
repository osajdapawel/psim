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


        public async Task<LaptopDTO> AddNewLaptopAsync(CreateLaptopDTO newlaptop)
        {
            if (string.IsNullOrEmpty(newlaptop.Model) || newlaptop.Quantity < 0 || string.IsNullOrEmpty(newlaptop.Description))
                throw new Exception("Laptop can not be created.");

            var laptopik = _mapper.Map<Laptop>(newlaptop);
            await _laptopRepository.addAsyc(laptopik);

            return _mapper.Map<LaptopDTO>(laptopik);
            // nie działało bo nie było async'a i ałejta

        }

        /// <summary>
        /// Funkcja do aktualizacjji laptopa
        /// </summary>
        /// <param name="updateLaptopDTO"></param>
        /// <returns>True - jeśli aktualizacja się powiodła</returns>
        public async Task<bool> UpdateLaptopAsync(UpdateLaptopDTO updateLaptopDTO)
        {
            var laptop = await _laptopRepository.GetByIdAsync(updateLaptopDTO.Id);
            if (laptop == null)
                return false;

            var updatedLaptop = _mapper.Map(updateLaptopDTO, laptop);

            await _laptopRepository.UpdateAsync(updatedLaptop);

            return true;
        }

        /// <summary>
        /// Metoda usuwająca laptop o konretnym id
        /// </summary>
        /// <param name="id">id laptopa do usunięcia</param>
        /// <returns>True - jeśli usunięcie się powiodło</returns>
        public async Task<bool> DeleteLaptopAsync(Guid id)
        {
/*            var laptop = await _laptopRepository.GetByIdAsync(id);
            
            if (laptop == null)
                return false;*/

            return await _laptopRepository.DeleteAsync(id);
        }
    }
}
