using Microsoft.Extensions.DependencyInjection;
using SynthFinManSystem.Model.Abstract;
using SynthFinManSystem.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SynthFinManSystem.Web.Abstract;
using SynthFinManSystem.Web.Business;

namespace SynthFinManSystem.Web.Configuration
{
    public static class StartupEntityInjection
    {
        public static IServiceCollection AddScopedInjection(this IServiceCollection services)
        {
            #region Model Injection
            services.AddScoped<IUserBusiness,UserBusiness> ();
            #endregion

            #region Web Injection
            services.AddScoped<IAccountBusiness, AccountBusiness>();
            #endregion

            return services;
        }
    }
}
