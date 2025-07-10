using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.DTOs.Medicine;
using Final.Application.DTOs.User;
using Final.Domain.Entities;

namespace Final.Application.Profiles
{
  public class MedicineProfile:Profile
    {
        public MedicineProfile()
        {
          
            CreateMap<Medicine,MedicineGetDTO>().ReverseMap();
            CreateMap<Medicine, MedicinePostDTO>().ReverseMap();

        }
    }
}
