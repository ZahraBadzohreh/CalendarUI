using CalendarUI.Data.Database;
using CalendarUI.Data.Repository;
using CalendarUI.Data.Test.Infrastructure;
using CalendarUI.Domain.Entities;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CalendarUI.Data.Test.Repository
{
    public class RepositoryTests : DatabaseTestBase
    {
        private readonly CalendarContext _CalendarContext;
        private readonly Repository<Appointment> _testee;
        private readonly Repository<Appointment> _testeeFake;
        private readonly Appointment _newAppointment;
        public RepositoryTests()
        {
            _CalendarContext = A.Fake<CalendarContext>();
            _testeeFake = new Repository<Appointment>(_CalendarContext);
            _testee = new Repository<Appointment>(Context);
            _newAppointment = new Appointment
            {
                Organizer = "Ali",
                AttendeesList = new List<string> { "Fin J", "Dar S" },
                DateTime = DateTime.Now.AddDays(25),
                Description = "Int with Fin"
            };
        }

        [Theory]
        [InlineData("Changed")]
        [InlineData("Updated")]
        public async void UpdateAppointmentAsync_WhenAppointmentIsNotNull_ShouldReturnAppointment(string description)
        {
            var appointment = Context.Appointments.First();
            appointment.Description = description;

            var result = await _testee.UpdateAsync(appointment);

            result.Should().BeOfType<Appointment>();
            result.Description.Should().Be(description);
        }

        [Fact]
        public void AddAsync_WhenEntityIsNull_ThrowsException()
        {
            _testee.Invoking(x => x.AddAsync(null)).Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public void AddAsync_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _CalendarContext.SaveChangesAsync(default)).Throws<Exception>();

            _testeeFake.Invoking(x => x.AddAsync(new Appointment()))
                .Should().ThrowAsync<Exception>()
                .WithMessage("entity could not be saved: Exception of type 'System.Exception' was thrown.");
        }

        [Fact]
        public async void CreateAppointmentAsync_WhenAppointmentIsNotNull_ShouldReturnAppointment()
        {
            var result = await _testee.AddAsync(_newAppointment);

            result.Should().BeOfType<Appointment>();
        }

        [Fact]
        public async void CreateAppointmentAsync_WhenAppointmentIsNotNull_ShouldShouldAddAppointment()
        {
            var AppointmentCount = Context.Appointments.Count();

            await _testee.AddAsync(_newAppointment);

            Context.Appointments.Count().Should().Be(AppointmentCount + 1);
        }

        [Fact]
        public void GetAll_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _CalendarContext.Set<Appointment>()).Throws<Exception>();

            _testeeFake.Invoking(x => x.GetAll())
                .Should().Throw<Exception>()
                .WithMessage("Couldn't retrieve entities: Exception of type 'System.Exception' was thrown.");
        }

        [Fact]
        public void UpdateAsync_WhenEntityIsNull_ThrowsException()
        {
            _testee.Invoking(x => x.UpdateAsync(null)).Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public void UpdateAsync_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _CalendarContext.SaveChangesAsync(default)).Throws<Exception>();

            _testeeFake.Invoking(x => x.UpdateAsync(new Appointment()))
                .Should().ThrowAsync<Exception>()
                .WithMessage("entity could not be updated Exception of type 'System.Exception' was thrown.");
        }
    }
}
