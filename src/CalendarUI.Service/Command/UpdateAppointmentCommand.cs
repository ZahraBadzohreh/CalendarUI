using CalendarUI.Domain.Entities;
using MediatR;

namespace CalendarUI.Service.Command
{
    public class UpdateAppointmentCommand : IRequest<Appointment>
    {
        public Appointment appointment { get; set; }
    }
}
