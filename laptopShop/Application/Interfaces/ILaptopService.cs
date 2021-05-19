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

        Task<LaptopDTO> AddNewLaptopAsync(CreateLaptopDTO newlaptop);


        /// <summary>
        /// Funkcja do aktualizacjji laptopa
        /// </summary>
        /// <param name="updateLaptopDTO">Obiekt UpdateLaptopDTO do aktualizaji</param>
        /// <returns>True - jeśli aktualizacja się powiodła</returns>
        Task<bool> UpdateLaptopAsync(UpdateLaptopDTO updateLaptopDTO);

        /// <summary>
        /// Metoda usuwająca laptop o konretnym id
        /// </summary>
        /// <param name="id">id laptopa do usunięcia</param>
        /// <returns>True - jeśli usunięcie się powiodło</returns>
        Task<bool> DeleteLaptopAsync(Guid id);
    }
}
