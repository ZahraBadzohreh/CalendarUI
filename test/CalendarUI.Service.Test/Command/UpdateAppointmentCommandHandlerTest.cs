using CalendarUI.Data.Repository;
using CalendarUI.Domain.Entities;
using CalendarUI.Service.Command;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalendarUI.Service.Test.Command
{
    public class UpdateAppointmentCommandHandlerTest
    {
        private readonly UpdateAppointmentCommandHandler _testee;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly Appointment _appointment;

        public UpdateAppointmentCommandHandlerTest()
        {
            _appointmentRepository = A.Fake<IAppointmentRepository>();
            _testee = new UpdateAppointmentCommandHandler(_appointmentRepository);

            _appointment = new Appointment
            {
                Description = "Meeting"
            };
        }

        [Fact]
        public async void Handle_ShouldReturnUpdatedAppointment()
        {
            A.CallTo(() => _appointmentRepository.UpdateAsync(A<Appointment>._)).Returns(_appointment);

            var result = await _testee.Handle(new UpdateAppointmentCommand(), default);

            result.Should().BeOfType<Appointment>();
            result.Description.Should().Be(_appointment.Description);
        }

        [Fact]
        public async void Handle_ShouldUpdateAsync()
        {
            await _testee.Handle(new UpdateAppointmentCommand(), default);

            A.CallTo(() => _appointmentRepository.UpdateAsync(A<Appointment>._)).MustHaveHappenedOnceExactly();
        }
    }
}
