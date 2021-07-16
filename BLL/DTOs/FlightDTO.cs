using System;

namespace BLL
{
    // Data Transfer Object - DTO (old POCO)
    public class FlightDTO
    {
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }

        public int DispatchCityId { get; set; }

        public int ArrivalCityId { get; set; }
        public int AirplaneId { get; set; }
        public CityDTO CityFrom { get; set; }
        public CityDTO CityTo { get; set; }
    }
}
