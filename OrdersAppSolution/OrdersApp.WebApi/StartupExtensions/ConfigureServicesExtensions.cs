using Microsoft.EntityFrameworkCore;
using OrdersApp.Core.Services.OrderItems;
using OrdersApp.Core.Services.Orders;
using OrdersApp.Core.ServicesContracts.OrderItems;
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
            services.AddScoped<IOrdersAdderService, OrdersAdderService>();

            services.AddScoped<IOrderItemsGetterService, OrderItemsGetterService>();
            services.AddScoped<IOrderItemsDeleterService, OrderItemsDeleterService>();
            services.AddScoped<IOrderItemsUpdaterService, OrderItemsUpdaterService>();
            services.AddScoped<IOrderItemsAdderService, OrderItemsAdderService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }

        #endregion
    }
}
