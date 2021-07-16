using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        public int MaxPassengers { get; set; }

        // FOREIGN KEYS
        public int? CountryId { get; set; }
        public int TypeId { get; set; }

        // NAVIGATION PROPERTIES
        public virtual Country Country { get; set; }
        public virtual Type Type { get; set; }
    }
}