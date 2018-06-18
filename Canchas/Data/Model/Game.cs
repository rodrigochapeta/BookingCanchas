using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Model
{
    public class Game : SharedModel
    { 
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } // Futbol 
        [Required(ErrorMessage = "Size is required")]
        public int Size { get; set; } // 5 - 7 - 11   

        public virtual ICollection<Field> Fields { get; set; }
    }
}
