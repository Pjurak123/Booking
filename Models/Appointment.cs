using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Booking;
using Booking.Models;

namespace BookingApp.Models
{
    public class Appointment : BaseModel
    {
        
        [Required(ErrorMessage="Ovo polje je obavezno")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        
        [Required]
        public int Price { get; set; }

        public ICollection<ClientAppointment> ClientAppointments { get; set; }
        public string DateTime { get; internal set; }
    }
}