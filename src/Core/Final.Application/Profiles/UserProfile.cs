using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.DTOs.User;
using Final.Domain.Entities;

namespace Final.Application.Profiles
{
   public class UserProfile:Profile
    {
 
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap(); 
           
            // DTO -> Entity для создания
            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            // DTO -> Entity для обновления
            CreateMap<UpdateUserDTO, User>()
               
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }

}

