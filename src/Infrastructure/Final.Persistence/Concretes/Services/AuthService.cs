using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Auth;
using Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;

using Umbraco.Core.Models;
using Final.Domain.Enums;

namespace Final.Persistence.Concretes.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    namespace Final.Persistence.Concretes.Services
    {
        public class AuthService : IAuthService
        {
            private readonly FinalDbContext _context;
            private readonly IJwtService _jwtService;

            public AuthService(FinalDbContext context, IJwtService jwtService)
            {
                _context = context;
                _jwtService = jwtService;
            }

            public async Task<AuthResult> RegisterAsync(RegisterDto dto)
            {
                // Email artıq varsa
                if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                    return new AuthResult { Success = false, Message = "Email already registered" };

                // Yeni istifadəçi obyekti
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = dto.UserName,
                    Email = dto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Role = UserRole.Patient 
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Token yaratmaq
                var token = _jwtService.GenerateToken(user);

                return new AuthResult
                {
                    Success = true,
                    Message = "Registered successfully",
                    Token = token,
                    ExpireAt = DateTime.UtcNow.AddHours(1) 
                };
            }

            public async Task<AuthResult> LoginAsync(LoginDto dto)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
                if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                {
                    return new AuthResult
                    {
                        Success = false,
                        Message = "Invalid username or password"
                    };
                }


                // Token yarat
                var token = _jwtService.GenerateToken(user);

                return new AuthResult
                {
                    Success = true,
                    Message = "Logged in successfully",
                    Token = token,
                    ExpireAt = DateTime.UtcNow.AddHours(1)
                };
            }
        }
    }
}
