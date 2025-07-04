using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Application.DTOs.Auth
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public string? Token { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
