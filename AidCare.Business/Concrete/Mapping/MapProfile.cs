using AidCare.Business.Concrete.DTOs.Users;
using AidCare.Entities.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Business.Concrete.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, AddUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
        }
    }
}
