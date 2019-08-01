using System.ComponentModel.DataAnnotations;
using Booking.Models;

namespace BookingApp.Models
{
    public class ClientAppointment : BaseModel
    {   [Required]
        public string Price { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        

    }
}