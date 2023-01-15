using AutoMapper;
using CalendarUI.Domain.Entities;
using CalendarUI.Models;

namespace CalendarUI.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAppointmentModel, Appointment>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.AttendeesList, opt => opt.MapFrom(src => src.Attendees));

            CreateMap<UpdateAppointmentModel, Appointment>()
                .ForMember(x => x.AttendeesList, opt => opt.MapFrom(src => src.Attendees));

            CreateMap<Appointment, UpdateAppointmentModel>()
                .ForMember(x => x.Attendees, opt => opt.MapFrom(src => src.AttendeesList));
        }
    }
}
