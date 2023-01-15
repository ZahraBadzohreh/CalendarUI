using CalendarUI.Data.Repository;
using CalendarUI.Domain.Entities;
using CalendarUI.Service.Query;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CalendarUI.Service.Test.Query
{
    public class GetAppointmentsByMonthQueryHandlerTest
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly GetAppointmentsByMonthQueryHandler _testee;
        private readonly List<Appointment> _appointments;
        private readonly int _month = 10;
        public GetAppointmentsByMonthQueryHandlerTest()
        {
            _appointmentRepository = A.Fake<IAppointmentRepository>();
            _testee = new GetAppointmentsByMonthQueryHandler(_appointmentRepository);

            _appointments = new List<Appointment>
            {
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    DateTime = new DateTime(2021,_month,10)
                },
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    DateTime = new DateTime(2021,_month,10)
                }
            };
        }

        [Fact]
        public async Task Handle_ShouldReturnAppointments()
        {
            A.CallTo(() => _appointmentRepository.GetAppointmentsByMonthAsync(_month, default)).Returns(_appointments);

            var result = await _testee.Handle(new GetAppointmentsByMonthQuery { Month = _month }, default);

            A.CallTo(() => _appointmentRepository.GetAppointmentsByMonthAsync(_month, default)).MustHaveHappenedOnceExactly();
            result.Should().BeOfType<List<Appointment>>();
            result.Count.Should().Be(2);
        }
    }
}
