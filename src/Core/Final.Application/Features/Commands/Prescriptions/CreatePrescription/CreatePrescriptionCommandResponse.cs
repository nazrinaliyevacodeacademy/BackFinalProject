﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Application.Features.Commands.Prescriptions.CreatePrescription
{
    public class CreatePrescriptionCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Guid? PrescriptionId { get; set; }
    }
}
