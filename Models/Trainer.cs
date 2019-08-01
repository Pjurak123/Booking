using System.ComponentModel.DataAnnotations;
using Booking.Models;

namespace BookingApp.Models
{
    public class Trainer : BaseModel
    {

        [Required(ErrorMessage="Obavezno je unijeti ime")]
        [StringLength(1000)]
        public string Name { get; set; }

        [Required(ErrorMessage="Obavezno je unijeti preime")]
        [StringLength(1000)]
        public string Surname { get; set; }

        [Required]
        [Phone]
        public int PhoneNumber { get; set; }
        
    }
}