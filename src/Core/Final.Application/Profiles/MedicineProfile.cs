using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.DTOs;
using Final.Application.DTOs.Medicine;
using Final.Domain.Entities;

namespace Final.Application.Profiles
{
  public class MedicineProfile:Profile
    {
        /*    public class MappingProfile : Profile
            {
                public MappingProfile()
                {
                    CreateMap<User, UserDto>().ReverseMap();
                    CreateMap<Medicine, MedicineDto>().ReverseMap();
                    CreateMap<Prescription, PrescriptionDto>().ReverseMap();
                }
            }
    */
        /*public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // User
                CreateMap<User, UserDto>().ReverseMap();
                CreateMap<RegisterUserDto, User>()
                    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // пароль хэшуется отдельно

                // Medicine
                CreateMap<Medicine, GetMedicineDto>();
                CreateMap<CreateMedicineDto, Medicine>();
                CreateMap<UpdateMedicineDto, Medicine>();

                // Prescription
                CreateMap<Prescription, PrescriptionDto>()
                    .ForMember(dest => dest.MedicineIds,
                        opt => opt.MapFrom(src => src.PrescriptionMedicines.Select(pm => pm.MedicineId)));

                CreateMap<CreatePrescriptionDto, Prescription>()
                    .ForMember(dest => dest.PrescriptionMedicines, opt => opt.MapFrom(src =>
                        src.MedicineIds.Select(mid => new PrescriptionMedicine { MedicineId = mid })));
            }
        }
        */
        public MedicineProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Medicine,MedicineGetDTO>().ReverseMap();
           /*CreateMap<Prescription, PrescriptionDTO>().ReverseMap();*/

        }
    }
}
