using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Booking.Models;

namespace BookingApp.Models
{

    public class Client : BaseModel
    {
        [Required(ErrorMessage="Obavezno je unijeti ime")]
        [StringLength(1000)]
        public string Name { get; set; }

        [Required(ErrorMessage="Obavezno je unijeti prezime")]
        [StringLength(1000)]
        public string Surname { get; set; }

        [Required(ErrorMessage="Obavezno je unijeti oib")]
        [StringLength(12, ErrorMessage = "Nedozvoljeni broj znakova ", MinimumLength = 10)]
        public string Oib { get; set; }


        public int? ClubId { get; set; }
        public Club Club { get; set;}
        
        public ICollection<ClientAppointment> ClientAppointments { get; set; }
        
    }
 
}
