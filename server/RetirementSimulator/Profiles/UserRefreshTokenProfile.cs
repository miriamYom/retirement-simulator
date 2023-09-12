using AutoMapper;
using BL.DTO;
using DL.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    public class UserRefreshTokenProfile:Profile
    {
        public UserRefreshTokenProfile()
        {
            CreateMap<UserRefreshToken, UserRefreshTokenDTO>().ReverseMap();

        }
    }
}
