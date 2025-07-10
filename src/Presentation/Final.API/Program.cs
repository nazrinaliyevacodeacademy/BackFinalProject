using Microsoft.EntityFrameworkCore;
using Final.Persistence;
using Final.Application;
using Final.Application.Validators.Users;
using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Final.API.Middlewares;
using Final.Application.Validators.Medicine;
using Microsoft.Extensions.DependencyInjection;
using Final.Application.Features.Commands.Users.CreateUser;
using Final.Application.Validators.Prescription;
using Microsoft.AspNetCore.Builder;

namespace Final.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // JWT setup
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtSettings["Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Controllers & Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Enter JWT like: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
           
            
            // FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDTOValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateUserDTOValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<MedicinePostDTOValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreatePrescriptionDTOValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PrescriptionItemDtoValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddPersistenceServices();
            builder.Services.AddApplicationServices();
           
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }/*
            app.UseEndpoints();*/
            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}

