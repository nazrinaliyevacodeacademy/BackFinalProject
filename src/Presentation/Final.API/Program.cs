
using Final.Application.Profiles;
using Final.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Final.Persistence;
using Final.Application;
using Final.Persistence.Contexts;
namespace Final.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          /*  builder.Services.AddAutoMapper(typeof(MedicineProfile));*/
           /*Services
            DBContext*/
            builder.Services.AddPersistenceServices();
            /*AutoMapper*/
            builder.Services.AddApplicationServices();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
