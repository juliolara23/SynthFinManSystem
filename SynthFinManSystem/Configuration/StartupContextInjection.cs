using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SynthFinManSystem.Model.Context;
using System;

namespace SynthFinManSystem.Web.Configuration
{
    public static class StartupContextInjection
    {
        public static IServiceCollection AddDbContextInjection(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("SynthFinlMantSystemContext")));
                return services;
            }
            catch (Exception e)
            {                
                throw e;
            }
        }
    }
}
