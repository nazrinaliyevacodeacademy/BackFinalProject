﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Application.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Email { get; set; }
}

