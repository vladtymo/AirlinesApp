using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Flight
    {
        [Key] // set primary key
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }

        // FOREIGN KEYS
        [ForeignKey(nameof(DispatchCity))]
        public int DispatchCityId { get; set; }

        [ForeignKey(nameof(ArrivalCity))]
        public int ArrivalCityId { get; set; }
        public int AirplaneId { get; set; }

        // NAVIGATION PROPERTIES
        public virtual City DispatchCity { get; set; }
        public virtual City ArrivalCity { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}