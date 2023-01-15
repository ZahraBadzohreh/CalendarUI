using CalendarUI.Domain.Entities;
using MediatR;
using System;

namespace CalendarUI.Service.Query
{
    public class GetAppointmentByIdQuery : IRequest<Appointment>
    {
        public Guid Id { get; set; }
    }
}
