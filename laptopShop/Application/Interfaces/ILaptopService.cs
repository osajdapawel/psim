using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ILaptopService
    {
        Task<IEnumerable<LaptopDTO>> GetAllLaptopsAsync();

        Task<LaptopDTO> GetLaptopByIdAsync(Guid id);

        Task<LaptopDTO> AddNewLaptopAsync(LaptopDTO)

        // getAllLaptopsAsync zwracające DTOsy
        // getByIdAsync 
        // 
    }
}
