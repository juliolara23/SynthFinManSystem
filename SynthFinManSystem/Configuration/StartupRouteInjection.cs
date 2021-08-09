using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynthFinManSystem.Web.Configuration
{
    public static class StartupRouteInjection
    {
        public static IApplicationBuilder UseMvcInjection(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}
