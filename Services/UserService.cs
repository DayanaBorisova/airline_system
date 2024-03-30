using AirlineSystemApp.Data.Constants;
using AirlineSystemApp.Data.Entities;
using AirlineSystemApp.Models.User;
using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystemApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(
            IUserRepository userRepository,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedUserWithRoleAsync(string email, string password, UserRolesEnum role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = CreateUser(email);
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        if (!await roleManager.RoleExistsAsync(role.ToString()))
                        {
                            await roleManager.CreateAsync(new IdentityRole(role.ToString()));
                        }

                        await userManager.AddToRoleAsync(user, role.ToString());
                        
                    }
                }
        }

        public IEnumerable<UserViewModel> GetAll()
            => userRepository.GetAll();

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var users = new List<UserViewModel>();

            var userRoles = Enum.GetValues(typeof(UserRolesEnum));
            foreach (var role in userRoles)
            {
                var usersInRoleEntities = await userManager.GetUsersInRoleAsync(role.ToString());
                var usersInRole = usersInRoleEntities
                    .Select(user => new UserViewModel(user.Id, user.Email, user.Name, role.ToString()));

                users.AddRange(usersInRole);
            }

            return users;
        }


        private User CreateUser(string email)
            => new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                UserName = email,
                Name = email
            };
    }
}
