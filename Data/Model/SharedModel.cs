using System;
using System.ComponentModel.DataAnnotations;


namespace Data.Model
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
    public static class ISharedModelExtensions
    {

        public static bool IsNullOrEmpty(this SharedModel entity)
        {
            if (!IsObjectNull(entity))
            {
                if (!IsEmptyObject(entity))
                {
                    return false;
                }
                else return false;
            }
            else return false;
        }
        public static bool IsObjectNull(this SharedModel entity)
        {
            return entity == null;
        }

        public static bool IsEmptyObject(this SharedModel entity)
        {
            return entity.Id == 0;
        }
    }
}

