using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped<IMyContext, MyContext>(x =>
            {
               return new MyContext(configuration.GetConnectionString("DefaultConnection"));
            });
            //services.AddScoped<IMyContext, MyContext>(provider => provider.GetRequiredService<MyContext>());
            return services;
        }
    }
}
