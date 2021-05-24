﻿using Application.DTO;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AutoMapper.IMapper _mapper;

        public UserService(IUserRepository userRepository, AutoMapper.IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Funkcja zwracająca wszystkich użytkowników
        /// </summary>
        /// <returns>Kolekcję obiektów UserDTO</returns>
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAplicationUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        /// <summary>
        /// Funkcja zwracająca użytkownika o konkretnym emailu
        /// </summary>
        /// <param name="email"></param>
        /// <returns>obiekt UserDTO</returns>
        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetAplicationUserByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// Funkcja zwracająca użytkownika o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>obiekt UserDTO</returns>
        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetAplicationUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// Metoda sprawdzająca czy użytkownik ma prawo do danego zasobu
        /// </summary>
        /// <typeparam name="TResource">Typ zasobu do sprawdzenia</typeparam>
        /// <param name="id">Id zasobu do sprawdzenia</param>
        /// <param name="username">Nazwa użytkownika, którego uprawnienia są sprawdzane</param>
        /// <returns>true jeśli użytkownik ma uprawnienia,  false jeśli ich nie ma</returns>
        public async Task<bool> HasPermition<TResource>(Guid id, string username)
        {
            var userName 
            return true;
        }
    }
}
