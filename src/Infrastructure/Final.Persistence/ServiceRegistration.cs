using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Persistence.Concretes.Repositories;
using Final.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Final.Persistence.Concretes.Services;
using Final.Application.Abstraction.Repositories;
using Final.Application.Abstraction.Services;

namespace Final.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        /*DbContext*/
        services.AddDbContext<FinalDbContext>(opt =>
         {
             opt.UseSqlServer(ConfigManager.ConnectionStr);
         });

       /* Repositories*/
        services.AddScoped<IMedicineReadRepository, MedicineReadRepository>();
        services.AddScoped<IMedicineWriteRepository, MedicineWriteRepository>();

        /*Services*/

        services.AddScoped<IMedicineService, MedicineService>();
    }
}
