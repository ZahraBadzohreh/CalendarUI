using CalendarUI.Data.Database;
using CalendarUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarUI.Data.Test.Infrastructure
{
    class DatabaseInitializer
    {
        public static void Initialize(CalendarContext context)
        {
            if (context.Appointments.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(CalendarContext context)
        {
            var appointments = new[]
            {
                new Appointment
                {
                    Id = Guid.Parse("9f35b48d-cb87-4783-bfdb-21e36012930a"),
                    Organizer="Amir",
                    AttendeesList = new List<string>{"Fal J","Mark Z","Jeff Z" },
                    DateTime = DateTime.Now.AddDays(18),
                    Description="Interview"
                },
                new Appointment
                {
                    Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                    Organizer="Ali",
                    AttendeesList = new List<string>{"Fin J","Dar S" },
                    DateTime=DateTime.Now.AddDays(55),
                    Description="Meeting"
                },
                new Appointment
                {
                    Id = Guid.Parse("971316e1-4966-4426-b1ea-a36c9dde1066"),
                    Organizer="John",
                    AttendeesList = new List<string>{ "Smith J", "Sun S" },
                    DateTime=DateTime.Now.AddDays(85),
                    Description="Interview with Smith"
                }
            };

            context.Appointments.AddRange(appointments);
            context.SaveChanges();
        }
    }
}
