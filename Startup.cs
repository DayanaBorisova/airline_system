
using AirlineSystemApp.Repositories;
using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services;
using AirlineSystemApp.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using AirlineSystemApp.Data.Entities;
using System;
using AirlineSystemApp.Data.Constants;
using System.Threading.Tasks;
using AirlineSystemApp.Data;

namespace AirlineSystemApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("AirlineSystemAppContextConnection"));
                options.UseLazyLoadingProxies();
            }             
            );

            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IFlightService, FlightService>();

            services.AddScoped<IPassengerRepository, PassengerRepository>();
            services.AddScoped<IPassengerService, PassengerService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddAuthorization(options =>
            {
                foreach (var role in Enum.GetNames(typeof(UserRolesEnum)))
                {
                    options.AddPolicy(role, policy => policy.RequireRole(role));
                }
            }
            );

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<ApplicationContext>();

            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IUserService userService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            //DataSeed.SeedUserRoles(app);
            CreateInitialUsers(userService).Wait();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Flight}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }

        private async Task CreateInitialUsers(IUserService userService)
        {
            await userService.SeedUserWithRoleAsync("admin@example.com", "Admin123!", UserRolesEnum.Admin);
            await userService.SeedUserWithRoleAsync("operator@example.com", "Operator123!", UserRolesEnum.Operator);
            await userService.SeedUserWithRoleAsync("user@example.com", "User123!", UserRolesEnum.User);
        }
    }
}
