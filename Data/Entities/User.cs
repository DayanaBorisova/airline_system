using Microsoft.AspNetCore.Identity;

namespace AirlineSystemApp.Data.Entities
{
    public class User : IdentityUser
    {
        public string Name { set; get; }
    }
}
