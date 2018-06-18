using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Model
{
    public abstract class SharedModel
    { 
        [Key]
        public int Id { get; set; }
        public string Desc { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int ModifiedBy { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }
        [Required(ErrorMessage = "Erased is required")]
        public int Erased { get; set; }
    }
}
