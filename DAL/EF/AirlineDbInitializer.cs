using System.Data.Entity;

namespace DAL
{
    // Initializer Types:
    //  - CreateDatabaseIfNotExists
    //  - DropCreateDatabaseIfModelChanges
    //  - DropCreateDatabaseAlways
    public class AirlineDbInitializer : DropCreateDatabaseAlways<AirlinesDbContext>
    {
        protected override void Seed(AirlinesDbContext context)
        {
            base.Seed(context);

            Type type1 = context.Types.Add(new Type() { Name = "Commercial" });
            Type type2 = context.Types.Add(new Type() { Name = "Jets" });
            Type type3 = context.Types.Add(new Type() { Name = "Props" });
            context.SaveChanges();

            Country ua = context.Countries.Add(new Country() { Name = "Ukraine" });
            Country pl = context.Countries.Add(new Country() { Name = "Poland" });
            Country tr = context.Countries.Add(new Country() { Name = "Turkey" });
            Country usa = context.Countries.Add(new Country() { Name = "United States" });
            Country fr = context.Countries.Add(new Country() { Name = "France" });
            context.SaveChanges();

            City kyiv = context.Cities.Add(new City() { Name = "Kyiv", CountryId = ua.Id });
            City lviv = context.Cities.Add(new City() { Name = "Lviv", CountryId = ua.Id });
            City rivne = context.Cities.Add(new City() { Name = "Rivne", CountryId = ua.Id });
            City warsaw = context.Cities.Add(new City() { Name = "Warsaw", CountryId = pl.Id });
            City krakow = context.Cities.Add(new City() { Name = "Kraków", CountryId = pl.Id });
            City istanbul = context.Cities.Add(new City() { Name = "İstanbul", CountryId = tr.Id });
            City ankara = context.Cities.Add(new City() { Name = "Ankara", CountryId = tr.Id });
            context.SaveChanges();

            Airplane airplane1 = context.Airplanes.Add(new Airplane()
            {
                Model = "Boeing 787",
                CountryId = usa.Id,
                MaxPassengers = 287,
                TypeId = type1.Id
            });
            Airplane airplane2 = context.Airplanes.Add(new Airplane()
            {
                Model = "Airbus A320",
                CountryId = fr.Id,
                MaxPassengers = 256,
                TypeId = type1.Id
            });
            context.SaveChanges();

            context.Flights.Add(new Flight()
            {
                DepartureTime = System.DateTime.Now,
                AirplaneId = airplane1.Id,
                DispatchCityId = kyiv.Id,
                ArrivalCityId = ankara.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = System.DateTime.Now,
                AirplaneId = airplane1.Id,
                DispatchCityId = lviv.Id,
                ArrivalCityId = krakow.Id
            });
            context.Flights.Add(new Flight()
            {
                DepartureTime = System.DateTime.Now,
                AirplaneId = airplane2.Id,
                DispatchCityId = warsaw.Id,
                ArrivalCityId = istanbul.Id
            });
            context.SaveChanges();

            context.Clients.Add(new Client()
            {
                Name = "Illia",
                Surname = "Designer",
                BirthDate = new System.DateTime(2010, 10, 1),
                Email = "illia_prog@gmail.com",
                Phone = "+777-777-777"
            });
            context.SaveChanges();
        }
    }
}