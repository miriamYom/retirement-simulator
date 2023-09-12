using AutoMapper;
using BL.DTO;

namespace BL.Profiles;

internal class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        //CreateMap<object, BudgetPensionEmployee>()
        //    .ForMember(Employee => Employee.WorkPeriods,
        //         opt => opt.MapFrom(src => src.SubscriptionPeriod.Value < DateOnly.FromDateTime(DateTime.Now))));
        //.ForMember(dest => dest.IsSubscriptionPeriodValid,
        //          opt => opt.MapFrom(src => src.SubscriptionPeriod.Value < DateOnly.FromDateTime(DateTime.Now)))
        //.ReverseMap();
    }
}

// נראה לי לא צריך את המחלקה הזו!!!!!!!!!!!