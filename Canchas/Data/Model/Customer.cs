using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Model
{
    public class Customer : SharedModel
    { 

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60,ErrorMessage ="Name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "Password can't be longer than 30 characters")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        [Required(ErrorMessage = "Mail is required")]
        public string Mail { get; set; }

        [StringLength(60, ErrorMessage = "Phone can't be longer than 60 characters")]
        [Required(ErrorMessage = "Cellphone is required")]
        public string CellPhone { get; set; }

        public string ProfilePicture { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public int AccountType { get; set; } // 0 User 1 Operario 2 Admin 3 HelperGral 4 Admin Sistema

        [DataType(DataType.DateTime)]
        public DateTime? LastLogin { get; set; } 

        public int TrustLevel { get; set; } 

        public virtual ICollection<Booking> Bookings { get; set; } 


    }
}
