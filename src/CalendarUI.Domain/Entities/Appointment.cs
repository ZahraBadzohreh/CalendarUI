using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarUI.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime? DateTime { get; set; }
        public string Attendees { get; set; }
        public string Organizer { get; set; }
        public virtual IList<string> AttendeesList
        {
            get
            {
                return Attendees.Split(',');
            }
            set
            {
                Attendees = string.Join(", ", value.ToArray());
            }
        }
    }
}
