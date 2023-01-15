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
    public class CreateAppointmentCommandHandlerTest
    {
        private readonly CreateAppointmentCommandHandler _testee;
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentCommandHandlerTest()
        {
            _appointmentRepository = A.Fake<IAppointmentRepository>();
            _testee = new CreateAppointmentCommandHandler(_appointmentRepository);
        }

        [Fact]
        public async void Handle_ShouldCallAddAsync()
        {
            await _testee.Handle(new CreateAppointmentCommand(), default);

            A.CallTo(() => _appointmentRepository.AddAsync(A<Appointment>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Handle_ShouldReturnCreatedAppointment()
        {
            A.CallTo(() => _appointmentRepository.AddAsync(A<Appointment>._)).Returns(new Appointment
            {
                Description = "Meeting"
            });

            var result = await _testee.Handle(new CreateAppointmentCommand(), default);

            result.Should().BeOfType<Appointment>();
            result.Description.Should().Be("Meeting");
        }
    }
}
