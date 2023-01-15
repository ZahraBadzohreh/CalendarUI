using CalendarUI.Data.Repository;
using CalendarUI.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalendarUI.Service.Command
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Appointment>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.AddAsync(request.appointment);
        }
    }
}
