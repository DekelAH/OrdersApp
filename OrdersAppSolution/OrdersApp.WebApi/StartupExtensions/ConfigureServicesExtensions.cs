using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.Identity;
using OrdersApp.Core.Services.Jwt;
using OrdersApp.Core.Services.OrderItems;
using OrdersApp.Core.Services.Orders;
using OrdersApp.Core.ServicesContracts;
using OrdersApp.Core.ServicesContracts.OrderItems;
using OrdersApp.Core.ServicesContracts.Orders;
using OrdersApp.Infrastructure.DataBaseContext;
using OrdersApp.Infrastructure.Repositories;
using System.Text;

namespace OrdersApp.WebApi.StartupExtensions
{
    public static class ConfigureServicesExtensions
    {
        #region Methods

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                var authorizationPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(authorizationPolicy));
            });

            services.AddTransient<IJwtService, JwtService>();
            services.AddScoped<IOrdersGetterService, OrdersGetterService>();
            services.AddScoped<IOrdersAdderService, OrdersAdderService>();
            services.AddScoped<IOrdersUpdaterService, OrdersUpdaterService>();
            services.AddScoped<IOrdersDeleterService, OrdersDeleterService>();

            services.AddScoped<IOrderItemsGetterService, OrderItemsGetterService>();
            services.AddScoped<IOrderItemsAdderService, OrderItemsAdderService>();
            services.AddScoped<IOrderItemsUpdaterService, OrderItemsUpdaterService>();
            services.AddScoped<IOrderItemsDeleterService, OrderItemsDeleterService>();

            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
                .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidAudience = configuration["Jwt:Audience"],
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenSecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization();


            return services;
        }

        #endregion
    }
}
