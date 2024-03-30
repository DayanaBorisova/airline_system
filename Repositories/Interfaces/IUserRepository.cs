using AirlineSystemApp.Models.User;
using System.Collections.Generic;

namespace AirlineSystemApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserViewModel> GetAll();
    }
}
