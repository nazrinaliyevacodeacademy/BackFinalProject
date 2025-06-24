﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, Guid id)
            : base($"{name} not found with Id = {id}  ") { }
    }

}
