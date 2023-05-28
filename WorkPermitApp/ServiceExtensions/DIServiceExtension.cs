using System;
using WorkPermitApp.Repository.Implementation;
using WorkPermitApp.Repository.Interfaces;
using WorkPermitApp.Services.Implementation;
using WorkPermitApp.Services.IServices;

namespace WorkPermitApp.ServiceExtensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IWorkPermitRepository, WorkPermitRepository>();
            services.AddScoped<IWorkPermitService, WorkPermitService>();
        }
    }
}
