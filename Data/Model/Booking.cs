using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Booking : SharedModel
    {

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int FieldId { get; set; }

        [Required]
        [Range(1, 16, ErrorMessage = "La cantidad de horas de alquiler deben ser minimo {1} y maximo {2}.")]
        public int Amount { get; set; }

        [Required]
        [Range(0, 99999, ErrorMessage = "La cantidad minima cobrada es de {1} y maximo {2}.")]
        public int Charged { get; set; }

        [Required] 
        [DataType(DataType.DateTime)]

        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Length { get; set; } //inHs 
        public Customer Customer { get; set; }
        public Field Field { get; set; }
    }
}
