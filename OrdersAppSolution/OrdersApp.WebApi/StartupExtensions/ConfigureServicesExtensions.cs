using Microsoft.EntityFrameworkCore;
using OrdersApp.Core.Services;
using OrdersApp.Core.ServicesContracts.Orders;
using OrdersApp.Infrastructure.DataBaseContext;

namespace OrdersApp.WebApi.StartupExtensions
{
    public static class ConfigureServicesExtensions
    {
        #region Methods

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddScoped<IOrdersGetterService, OrdersGetterService>();
            services.AddScoped<IOrdersUpdaterService, OrdersUpdaterService>();
            services.AddScoped<IOrdersDeleterService, OrdersDeleterService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }

        #endregion
    }
}
