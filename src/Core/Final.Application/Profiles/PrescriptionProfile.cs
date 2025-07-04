using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.DTOs.Prescription;
using Final.Domain.Entities;

namespace Final.Application.Profiles
{
    public class PrescriptionProfile:Profile
    {
        public PrescriptionProfile()
        {
            CreateMap<Prescription, CreatePrescriptionDTO>().ReverseMap();
        }
    }
}
