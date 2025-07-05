﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Enums;

namespace Final.Application.DTOs.User
{
    public class UpdateUserDTO
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRole? Role { get; set; }
    }

}

