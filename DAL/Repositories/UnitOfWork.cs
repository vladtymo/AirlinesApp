using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        void Save();
        GenericRepository<Flight> FlightRepository { get; }
        GenericRepository<Client> ClientRepository { get; }
        GenericRepository<Airplane> AirplaneRepository { get; }
        GenericRepository<City> CityRepository { get; }
        GenericRepository<Country> CountryRepository { get; }
        GenericRepository<Type> TypeRepository { get; }
    }
  
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AirlinesDbContext context = new AirlinesDbContext();

        private GenericRepository<Flight> flightRepository;
        private GenericRepository<Client> clientRepository;
        private GenericRepository<Airplane> airplaneRepository;
        private GenericRepository<City> cityRepository;
        private GenericRepository<Country> countryRepository;
        private GenericRepository<Type> typeRepository;

        public GenericRepository<Flight> FlightRepository
        {
            get
            {
                // lazy loading
                if (this.flightRepository == null)
                {
                    this.flightRepository = new GenericRepository<Flight>(context);
                }
                return flightRepository;
            }
        }
        public GenericRepository<Client> ClientRepository
        {
            get
            {
                // lazy loading
                if (this.clientRepository == null)
                {
                    this.clientRepository = new GenericRepository<Client>(context);
                }
                return clientRepository;
            }
        }
        public GenericRepository<Airplane> AirplaneRepository
        {
            get
            {
                // lazy loading
                if (this.airplaneRepository == null)
                {
                    this.airplaneRepository = new GenericRepository<Airplane>(context);
                }
                return airplaneRepository;
            }
        }
        public GenericRepository<City> CityRepository
        {
            get
            {
                // lazy loading
                if (this.cityRepository == null)
                {
                    this.cityRepository = new GenericRepository<City>(context);
                }
                return cityRepository;
            }
        }
        public GenericRepository<Country> CountryRepository
        {
            get
            {
                // lazy loading
                if (this.countryRepository == null)
                {
                    this.countryRepository = new GenericRepository<Country>(context);
                }
                return countryRepository;
            }
        }
        public GenericRepository<Type> TypeRepository
        {
            get
            {
                // lazy loading
                if (this.typeRepository == null)
                {
                    this.typeRepository = new GenericRepository<Type>(context);
                }
                return typeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
