using Domain.Authentication;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, DataBaseContext dbContext)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task<IEnumerable<ApplicationUser>> GetAllAplicationUsersAsync()
        
            => await _userManager.GetUsersInRoleAsync(UserRoles.User);
        

        public async Task<ApplicationUser> GetAplicationUserByEmailAsync(string email)
        
            => await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail.ToUpper() == email.ToUpper());
        

        public async Task<ApplicationUser> GetAplicationUserByIdAsync(Guid id)
        
            => await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());

        /// <summary>
        /// Metoda sprawdzająca czy użytkownik ma prawo do danego zasobu
        /// </summary>
        /// <typeparam name="TResource">Typ zasobu do sprawdzenia</typeparam>
        /// <param name="id">Id zasobu do sprawdzenia</param>
        /// <param name="username">Nazwa użytkownika, którego uprawnienia są sprawdzane</param>
        /// <returns>true jeśli użytkownik ma uprawnienia,  false jeśli ich nie ma</returns>
        public async Task<bool> CheckPermitionAsync<TResource>(Guid id, string username)
        {
            var user = await _userManager.Users.SingleAsync(u => u.UserName == username);
            
            if (TResource == Order)
            
            var resource = _dbContext.

            return false;
        }
    }
}
