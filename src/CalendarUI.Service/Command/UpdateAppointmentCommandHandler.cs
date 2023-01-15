using CalendarUI.Data.Repository;
using CalendarUI.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalendarUI.Service.Command
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, Appointment>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.UpdateAsync(request.appointment);

            return appointment;
        }
    }
}
