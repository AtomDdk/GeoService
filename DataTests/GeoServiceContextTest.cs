using Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTests
{
    public class GeoServiceContextTest : GeoServiceContext
    {
        public GeoServiceContextTest(bool keepExistingDb = false, bool fillDb = true) : base(null)
        {
            _connectionString = @"Data Source=DESKTOP-4NAJBEU\SQLEXPRESS;Initial Catalog=Testing;Integrated Security=True";
            CreateDb(keepExistingDb, fillDb);
        }
        //protected override void SetConnectionString(string connection)
        //{
        //    if (connection == "test")
        //        _connectionString = @"Data Source=DESKTOP-4NAJBEU\SQLEXPRESS;Initial Catalog=Testing;Integrated Security=True";
        //}
        public void CreateDb(bool keepExistingDb, bool fillDb)
        {
            if (keepExistingDb)
                Database.EnsureCreated();
            else
                Database.EnsureDeleted(); Database.EnsureCreated();

            if (fillDb)
            {
                Database.ExecuteSqlRaw("INSERT INTO dbo.Continents VALUES('Europe'), ('Oceania'), ('United States');" +
                    "INSERT INTO dbo.Countries VALUES('Belgium', 200, 100, 1), ('France', 300, 200, 1), ('Australia', 700, 500, 2);" +
                    "INSERT INTO dbo.Cities VALUES('Brussel', 150, 1, 1), ('Gent', 50, 1, 0), ('Perth', 300, 3, 0);" +
                    "INSERT INTO dbo.Rivers VALUES ('Schelde', 300), ('Maas', 500), ('Swan River', 700);" +
                    "INSERT INTO dbo.CountryRiver VALUES (1, 1), (1, 2), (2, 1), (2, 2), (3,3);");
            }
        }

        public List<Continent> TestData()
        {
            Continent europe = new Continent { Id = 1, Name = "Europe" };
            Continent oceania = new Continent { Id = 2, Name = "Oceania" };
            Continent unitedStates = new Continent { Id = 3, Name = "United States" };

            Country belgium = new Country(1, "Belgium", 200, 100, europe, new List<City>(), new List<City>(), new List<River>());
            Country france = new Country(2, "France", 300, 200, europe, new List<City>(), new List<City>(), new List<River>());
            Country australia = new Country(3, "Australia", 700, 500, oceania, new List<City>(), new List<City>(), new List<River>());

            europe.AddCountries(new List<Country> { belgium, france });
            oceania.AddCountry(australia);

            City brussel = new City(1, "Brussel", 150, belgium);
            City gent = new City(2, "Gent", 50, belgium);
            City perth = new City(3, "Perth", 300, australia);

            belgium.AddCapital(brussel);
            belgium.AddCity(gent);
            australia.AddCity(perth);

            River schelde = new River(1, "Schelde", 300, new List<Country> { belgium, france });
            River maas = new River(2, "Maas", 500, new List<Country> { belgium, france });
            River swanRiver = new River(3, "Swan River", 700, new List<Country> { australia });

            belgium.AddRivers(new List<River> { schelde, maas });
            france.AddRivers(new List<River> { schelde, maas });
            australia.AddRivers(new List<River> { swanRiver });

            return new List<Continent> { europe, oceania, unitedStates };
        }
    }
}
