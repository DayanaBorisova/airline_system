using AirlineSystemApp.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineSystemApp.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAll();

        Task<IEnumerable<UserViewModel>> GetAllAsync();
    }
}
