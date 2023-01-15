using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CalendarUI.Data.Database;
using CalendarUI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CalendarUI.Data.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(CalendarContext calendarContext) : base(calendarContext)
        {
        }

        public async Task<Appointment> GetAppointmentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _calendarContext.Appointments.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Appointment>> GetAppointmentsByMonthAsync(int month, CancellationToken cancellationToken)
        {
            return await _calendarContext.Appointments
                .AsNoTracking()
                .Where(a => a.DateTime.Value.Month == month)
                .ToListAsync(cancellationToken);
        }
    }
}