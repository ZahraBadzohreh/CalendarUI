using CalendarUI.Data.Repository;
using CalendarUI.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CalendarUI.Service.Query
{
    public class GetAppointmentsByMonthQueryHandler : IRequestHandler<GetAppointmentsByMonthQuery, List<Appointment>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public GetAppointmentsByMonthQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<Appointment>> Handle(GetAppointmentsByMonthQuery request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.GetAppointmentsByMonthAsync(request.Month, cancellationToken);
        }
    }
}
