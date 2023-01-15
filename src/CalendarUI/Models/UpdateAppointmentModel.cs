using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalendarUI.Models
{
    public class UpdateAppointmentModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime? DateTime { get; set; }
        public IList<string> Attendees { get; set; }
        [Required]
        public string Organizer { get; set; }
    }
}
