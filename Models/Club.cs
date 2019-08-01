using System.ComponentModel.DataAnnotations;
using Booking.Models;

namespace BookingApp.Models
{
    public class Club : BaseModel
    {
        
        [Required(ErrorMessage="Obavezno je unijeti ime")]
        [StringLength(1000)]
        public string Name { get; set; }
       
        [Required(ErrorMessage="Obavezno je unijeti oib")]
        [StringLength(12, ErrorMessage = "Nedozvoljeni broj znakova ", MinimumLength = 10)]
        public string Oib { get; set;}

      
        [StringLength(1000)]
        public string Address { get; set;}

    }
}