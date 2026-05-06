using HotelManagementSystem.API.Context;
using HotelManagementSystem.API.Data_Access.Interfaces;
using HotelManagementSystem.API.Data_Access.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HotelConnection");

            services.AddDbContext<HotelContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<ICustomer, CustomerRepository>(); // Dependency Injection for Customers.
            services.AddScoped<IRoom, RoomRepository>();
        }

    }
}
