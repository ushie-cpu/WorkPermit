using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WorkPermitApp.Data;

namespace WorkPermitApp.ServiceExtensions
{
    public static class DbConfiguration
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WorkPermitDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
        }
        public static void AddAuthSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowAnyOrigin();
                });
            });

        }
    }
}
