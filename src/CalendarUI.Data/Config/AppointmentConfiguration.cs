using CalendarUI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace CalendarUI.Data.Config
{
    class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {

        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.DateTime)
                .IsRequired()
                .HasDefaultValueSql("GetDate()");

            builder.Property(e => e.Description).HasMaxLength(250);
            builder.Property(e => e.Organizer).HasMaxLength(120);
            builder.Property(e => e.Attendees).HasMaxLength(500);
            builder.Ignore(e => e.AttendeesList);

            builder.HasData(new List<Appointment>
            {
                new Appointment
                {
                    Id=Guid.NewGuid(),
                    Organizer="Amir",
                    AttendeesList = new List<string>{"Fal J","Mark Z","Jeff Z" },
                    DateTime = DateTime.Now.AddDays(5),
                    Description="Interview"
                },
                new Appointment
                {
                    Id=Guid.NewGuid(),
                    Organizer="Javad",
                    AttendeesList = new List<string>{"A J","D S" },
                    DateTime=DateTime.Now.AddDays(15),
                    Description="Meeting"
                },
                new Appointment
                {
                    Id=Guid.NewGuid(),
                    Organizer="Ali",
                    AttendeesList = new List<string>{"Fin J","Dar S" },
                    DateTime=DateTime.Now.AddDays(25),
                    Description="Int with Fin"
                },
                new Appointment
                {
                    Id=Guid.NewGuid(),
                    Organizer="Smith",
                    AttendeesList = new List<string>{"John D","Ali S" },
                    DateTime=DateTime.Now.AddDays(45),
                    Description="Meeting with Ali S"
                },
                new Appointment
                {
                    Id=Guid.NewGuid(),
                    Organizer="John",
                    AttendeesList = new List<string>{ "Smith J", "Sun S" },
                    DateTime=DateTime.Now.AddDays(65),
                    Description="Interview with Smith"
                }
            });
        }
    }
}
