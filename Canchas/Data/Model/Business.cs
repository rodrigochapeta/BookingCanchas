using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data.Model
{
    public class Business : SharedModel
    {
         
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } 
       
        public string ProfilePicture { get; set; }

        public virtual ICollection<Field> Fields { get; set; }

    }
}
