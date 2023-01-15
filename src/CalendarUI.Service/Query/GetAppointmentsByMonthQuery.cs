using CalendarUI.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CalendarUI.Service.Query
{
    public class GetAppointmentsByMonthQuery : IRequest<List<Appointment>>
    {
        public int Month { get; set; }
    }
}
