using CalendarUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CalendarUI.Data.Repository
{
    public interface IAppointmentRepository: IRepository<Appointment>
    {
        Task<Appointment> GetAppointmentByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Appointment>> GetAppointmentsByMonthAsync(int month, CancellationToken cancellationToken);
    }
}