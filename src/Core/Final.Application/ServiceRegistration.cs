using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Final.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MedicineProfile).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
            });
        }
    }
}
