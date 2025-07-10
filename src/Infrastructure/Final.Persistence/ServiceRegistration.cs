using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Persistence.Concretes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Final.Persistence.Concretes.Services;
using Final.Application.Abstraction.Repositories;
using Final.Application.Abstraction.Services;
using Final.Persistence.Concretes.Services.Final.Persistence.Concretes.Services;


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
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IPrescriptionReadRepository, PrescriptionReadRepository> ();
        services.AddScoped<IPrescriptionWriteRepository, PrescriptionWriteRepository>();
        /*Services*/
        services.AddScoped<IMedicineService, MedicineService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IPrescriptionService, PrescriptionService>();
    }
}
