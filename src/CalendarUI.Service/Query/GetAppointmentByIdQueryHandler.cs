using CalendarUI.Data.Repository;
using CalendarUI.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalendarUI.Service.Query
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, Appointment>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentByIdQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(request.Id, cancellationToken);
        }
    }
}
