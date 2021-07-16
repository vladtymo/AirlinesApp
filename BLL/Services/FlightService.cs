using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public interface IFlightService
    {
        void Add(FlightDTO flight);
        IEnumerable<FlightDTO> GetAll();
        IEnumerable<FlightDTO> GetByDate(DateTime dateFrom);
        void AddCountry(string name);
        IEnumerable<string> GetCountries();
    }
    public class FlightService : IFlightService
    {
        IUnitOfWork unitOfWork;
        IRepository<Flight> flights;
        IMapper mapper;

        public FlightService()
        {
            unitOfWork = new UnitOfWork();
            flights = unitOfWork.FlightRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Flight, FlightDTO>()
                    .ForMember(f => f.CityFrom, opt => opt.MapFrom(src => src.DispatchCity))
                    .ForMember(f => f.CityTo, opt => opt.MapFrom(src => src.ArrivalCity));
                cfg.CreateMap<City, CityDTO>()
                    .ForMember(c => c.CountryName, opt => opt.MapFrom(src => src.Country.Name));

                cfg.CreateMap<FlightDTO, Flight>();
                cfg.CreateMap<CityDTO, City>();
            });

            mapper = new Mapper(config);
        }

        public void Add(FlightDTO flight)
        {
            //Flight f = new Flight()
            //{
            //    Number = flight.Number,
            //    DepartureTime = flight.DepartureTime,
            //    AirplaneId = flight.AirplaneId,
            //    ArrivalCityId = flight.ArrivalCityId,
            //    DispatchCityId = flight.DispatchCityId
            //};
            //flights.Insert(f);
            flights.Insert(mapper.Map<Flight>(flight));
        }

        public IEnumerable<FlightDTO> GetAll()
        {
            //IList<FlightDTO> result = new List<FlightDTO>();

            //foreach (var flight in flights.Get())
            //{
            //    FlightDTO dto = new FlightDTO()
            //    {
            //        Number = flight.Number,
            //        DepartureTime = flight.DepartureTime,
            //        AirplaneId = flight.AirplaneId,
            //        ArrivalCityId = flight.ArrivalCityId,
            //        DispatchCityId = flight.DispatchCityId,
            //        CityFrom = new CityDTO()
            //        {
            //            Id = flight.DispatchCity.Id,
            //            Name = flight.DispatchCity.Name,
            //            CountryName = flight.DispatchCity.Country.Name
            //        },
            //        CityTo = new CityDTO()
            //        {
            //            Id = flight.ArrivalCity.Id,
            //            Name = flight.ArrivalCity.Name,
            //            CountryName = flight.ArrivalCity.Country.Name
            //        }
            //    };
            //    result.Add(dto);
            //}

            //return result;

            //foreach (var flight in flights.Get())
            //{
            //    yield return new FlightDTO()
            //    {
            //        Number = flight.Number,
            //        DepartureTime = flight.DepartureTime,
            //        AirplaneId = flight.AirplaneId,
            //        ArrivalCityId = flight.ArrivalCityId,
            //        DispatchCityId = flight.DispatchCityId,
            //        CityFrom = new CityDTO()
            //        {
            //            Id = flight.DispatchCity.Id,
            //            Name = flight.DispatchCity.Name,
            //            CountryName = flight.DispatchCity.Country.Name
            //        },
            //        CityTo = new CityDTO()
            //        {
            //            Id = flight.ArrivalCity.Id,
            //            Name = flight.ArrivalCity.Name,
            //            CountryName = flight.ArrivalCity.Country.Name
            //        }
            //    };
            //}

            return mapper.Map<IEnumerable<FlightDTO>>(flights.Get());
        }

        public IEnumerable<FlightDTO> GetByDate(DateTime dateFrom)
        {
            return mapper.Map<IEnumerable<FlightDTO>>(flights.Get(f => f.DepartureTime >= dateFrom));
        }

        public void AddCountry(string name)
        {
            unitOfWork.CountryRepository.Insert(new Country { Name = name });
            unitOfWork.Save();
        }
        public IEnumerable<string> GetCountries()
        {
            return unitOfWork.CountryRepository.Get().Select(c => c.Name);
        }
    }
}
