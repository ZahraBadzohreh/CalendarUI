using CalendarUI.Data.Repository;
using CalendarUI.Domain.Entities;
using CalendarUI.Service.Query;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CalendarUI.Service.Test.Query
{
    public class GetAppointmentByIdQueryHandlerTest
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly GetAppointmentByIdQueryHandler _testee;
        private readonly Appointment _appointment;
        private readonly Guid _id = Guid.Parse("803a95ef-89c5-43d5-aa2c-82a3695d9894");

        public GetAppointmentByIdQueryHandlerTest()
        {
            _appointmentRepository = A.Fake<IAppointmentRepository>();
            _testee = new GetAppointmentByIdQueryHandler(_appointmentRepository);

            _appointment = new Appointment { Id = _id, Description = "Interview" };
        }

        [Fact]
        public async Task Handle_WithValidId_ShouldReturnAppointment()
        {
            A.CallTo(() => _appointmentRepository.GetAppointmentByIdAsync(_id, default)).Returns(_appointment);

            var result = await _testee.Handle(new GetAppointmentByIdQuery { Id = _id }, default);

            A.CallTo(() => _appointmentRepository.GetAppointmentByIdAsync(_id, default)).MustHaveHappenedOnceExactly();
            result.Description.Should().Be("Interview");
        }
    }
}
