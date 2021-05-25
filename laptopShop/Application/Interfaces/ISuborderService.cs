using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISuborderService
    {
        /// <summary>
        /// Metoda  asynchroniczna zwracją wszystkie podzamówienia jednego zamówienia
        /// </summary>
        /// <param name="id">Id zamówienia głównego, którego podzamówienia chcemy otrzymać</param>
        /// <returns>Kolekcja podzamówień</returns>
        public Task<IEnumerable<SuborderDTO>> GetAllSuborderOfOrderAsync(Guid id);

        /// <summary>
        /// Metoda asynchroniczna zwracająca podzamówienie o konkretnym id
        /// </summary>
        /// <param name="id">Id podzamówienia</param>
        /// <returns>Obiekt SuborderDTO</returns>
        public Task<SuborderDTO> GetSuborderByIdAsync(Guid id);

        /// <summary>
        /// Metoda asynchroniczna dodająca nowe podzamówienie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<SuborderDTO> AddNewSuborderAsync(CreateSuborderDTO newSuborder);


        /// <summary>
        /// Metoda asynchroniczna aktualizująca podzamówienie - tak naprawde tylko ilość kupionych laptopów
        /// </summary>
        /// <param name="updateSuborder"></param>
        /// <returns>True jeśli aktualizacja powiodła się</returns>
        public Task<bool> UpdateSuborderAsync(UpdateSuborderDTO updateSuborder);

        /// <summary>
        /// Metoda asynchroniczna usuwająca podzamówienie o konkretnym id
        /// </summary>
        /// <param name="id">id podzamówienia do usunięcia</param>
        /// <returns>true jeśli operacja powiodła się</returns>
        public Task<bool> DeleteSuborderAsync(Guid id);
    }
}
