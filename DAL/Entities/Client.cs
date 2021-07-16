using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Client
    {
        public int Id { get; set; }
        [Required]          // set not null
        [MaxLength(100)]    // set max lenght (nvarchar(100))
        public string Name { get; set; }
        [Required, MaxLength(100)]   
        public string Surname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [CreditCard]
        public string CreditCard { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }

        // NAVIGATION PROPERTIES
        public virtual ICollection<Flight> Flights { get; set; }
    }
}