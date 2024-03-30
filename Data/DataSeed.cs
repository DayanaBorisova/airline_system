using AirlineSystemApp.Data.Constants;
using AirlineSystemApp.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AirlineSystemApp.Data
{
    public static class DataSeed
    {
        public static void SeedUserRoles(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                var roles = Enum.GetValues(typeof(UserRolesEnum));
                foreach (var role in roles)
                {
                    var roleName = role.ToString();

                    var roleExists = dbContext.Roles.Any(roleEntity => roleEntity.Name == roleName);
                    if (!roleExists)
                    {
                        var identityRole = new IdentityRole(roleName)
                        {
                            NormalizedName = roleName.ToUpper()
                        };

                        dbContext.Roles.Add(identityRole);
                    }
                }

                dbContext.SaveChanges();
            }
        }
    }
}
