using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Type
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        // NAVIGATION PROPERTIES
        public virtual ICollection<Airplane> Airplanes { get; set; }
    }
}