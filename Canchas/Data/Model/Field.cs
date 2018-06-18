using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Model
{
    public class Field : SharedModel
    { 
        [Required(ErrorMessage = "Select a owner")]
        public int BusinessId { get; set; } 
        [Required(ErrorMessage = "Select a game")]
        public int GameId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Size { get; set; } 

        public Game Game { get; set; }

        public Business Business { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
