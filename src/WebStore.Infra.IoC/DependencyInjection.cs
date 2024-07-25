using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebStore.Domain.Interfaces;
using WebStore.Domain.Notifications;
using WebStore.Identity.Application.Interfaces;
using WebStore.Identity.Application.Services;
using WebStore.Infra.Data.Repository;
using WebStore.Product.Application.Interfaces;
using WebStore.Product.Application.Services;

namespace WebStore.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INotifier, Notificator>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<INotifier, Notificator>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "WebStore.Identity.API",
                    ValidAudience = "WebStore.Identity.API",
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("lautertdev@12345678901234567890##@@")),
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
