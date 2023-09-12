using AutoMapper;
using BL.DTO;
using DL.DataObjects;

namespace BL.Profiles;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>()
            .ForMember(user => user.IsSubscriptionPeriodValid, opt => opt.Ignore());
        //.ForMember(dest => dest.IsSubscriptionPeriodValid,
        //          opt => opt.MapFrom(src => src.SubscriptionPeriod.Value < DateOnly.FromDateTime(DateTime.Now)))
        //.ReverseMap();
    }
}


