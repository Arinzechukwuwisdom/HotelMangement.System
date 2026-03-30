namespace HotelManagementSystem.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HotelConnection");
        }
    }
}
