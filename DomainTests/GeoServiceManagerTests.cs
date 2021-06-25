using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using DataTests;
using Domain.Interfaces;
using Data;
using System.Linq;
using Domain.Models;
using Domain.Exceptions;

namespace Domain.Tests
{
    [TestClass()]
    public class GeoServiceManagerTests
    {
        [TestMethod()]
        public void GetCityTest()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));

            var brussel = context.TestData()[0].Countries[0].Cities[0];

            Assert.AreEqual(brussel, manager.GetCity("Brussel"));
        }

        [TestMethod()]
        public void GetCityTest_DoesNotExist()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));

            Assert.ThrowsException<DomainException>(() => manager.GetCity("unknown"));
        }

        [TestMethod()]
        public void GetContinentTest()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));

            var europe = context.TestData()[0];

            Assert.AreEqual(europe, manager.GetContinent("Europe"));
        }

        [TestMethod()]
        public void GetContinentTest_DoesNotExist()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));

            Assert.ThrowsException<DomainException>(() => manager.GetContinent("unknown"));
        }

        [TestMethod()]
        public void GetCountryTest()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));

            var belgium = context.TestData()[0].Countries[0];

            Assert.AreEqual(belgium, manager.GetCountry("Belgium"));
        }

        [TestMethod()]
        public void GetCountryTest_DoesNotExist()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            Assert.ThrowsException<DomainException>(() => manager.GetCountry("unknown"));
        }

        [TestMethod()]
        public void GetRiverTest()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));

            var belgium = context.TestData()[0].Countries[0];

            Assert.AreEqual(belgium, manager.GetCountry("Belgium"));
        }

        [TestMethod()]
        public void GetRiverTest_DoesNotExist()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            Assert.ThrowsException<DomainException>(() => manager.GetCity("unknown"));
        }

        [TestMethod()]
        public void AddCityTest()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            City city = new City
            {
                Name = "Paris",
                Population = 140,
                Country = context.TestData()[0].Countries[1]
            };

            manager.AddCity(city);
            city.Id = 4;

            Assert.AreEqual(city, manager.GetCity(city.Name));
        }

        [TestMethod()]
        public void AddCityTest_AlreadyExists()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            City city = context.TestData()[0].Countries[0].Cities[0];
            Assert.ThrowsException<DomainException>(() => manager.AddCity(city));
        }

        [TestMethod()]
        public void AddContinentTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));
            Continent antartica = new Continent { Name = "Antartica" };

            manager.AddContinent(antartica);
            antartica.Id = 4;

            Assert.AreEqual(antartica, manager.GetContinent(antartica.Name));
        }

        [TestMethod()]
        public void AddContinentTest_AlreadyExists()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            Assert.ThrowsException<DomainException>(() => manager.AddContinent(context.TestData()[0]));
        }

        [TestMethod()]
        public void AddCountryTest()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            Country germany = new Country
            {
                Name = "Germany",
                Continent = context.TestData()[0],
                Population = 120,
                Surface = 30
            };

            manager.AddCountry(germany);
            germany.Id = 4;

            Assert.AreEqual(germany, manager.GetCountry(germany.Name));

        }

        [TestMethod()]
        public void AddCountryTest_AlreadyExists()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));

            Assert.ThrowsException<DomainException>(() => manager.AddCountry(context.TestData()[0].Countries[0]));
        }

        [TestMethod()]
        public void AddRiverTest()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            River rijn = new River("Rijn", 300, context.TestData()[0].Countries);

            manager.AddRiver(rijn);
            rijn.Id = 4;

            Assert.AreEqual(rijn, manager.GetRiver(rijn.Name));
        }

        [TestMethod()]
        public void AddRiverTest_AlreadyExists()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));
            Assert.ThrowsException<DomainException>(() => manager.AddRiver(manager.GetRiver("Schelde")));
        }

        [TestMethod()]
        public void RemoveCityTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));
            manager.RemoveCity(manager.GetCity("Brussel"));

            Assert.ThrowsException<DomainException>(() => manager.GetCity("Brussel"));
        }

        [TestMethod()]
        public void RemoveCityTest_DoesNotExist()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            Assert.ThrowsException<DomainException>(() => manager.RemoveCity(new City { Id = 4, Name = "not", Population = 10, Country = context.TestData()[0].Countries[0] }));
        }

        [TestMethod()]
        public void RemoveContinentTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));
            manager.RemoveContinent(manager.GetContinent("United States"));

            Assert.ThrowsException<DomainException>(() => manager.GetContinent("United States"));
        }

        [TestMethod()]
        public void RemoveContinentTest_ContinentHasCountries()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));
            Assert.ThrowsException<DomainException>(() => manager.RemoveContinent(manager.GetContinent("Europe")));
        }

        [TestMethod()]
        public void RemoveContinentTest_DoesNotExist()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));
            Assert.ThrowsException<DomainException>(() => manager.RemoveContinent(new Continent { Name = "nfmklfds" }));
        }

        [TestMethod()]
        public void RemoveCountryTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));
            manager.RemoveCountry(manager.GetCountry("France"));

            Assert.ThrowsException<DomainException>(() => manager.GetCountry("France"));
        }

        [TestMethod()]
        public void RemoveCountryTest_CountryHasCities()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));
            Assert.ThrowsException<DomainException>(() => manager.RemoveCountry(manager.GetCountry("Belgium")));
        }

        [TestMethod()]
        public void RemoveCountryTest_CountryDoesNotExist()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            Assert.ThrowsException<DomainException>(() => manager.RemoveCountry(new Country { Id = 5, Name = "dfdfd", Population = 10, Surface = 60, Continent = context.TestData()[0] }));
        }

        [TestMethod()]
        public void RemoveRiverTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));

            River schelde = manager.GetRiver("Schelde");
            manager.RemoveRiver(schelde);

            Assert.ThrowsException<DomainException>(() => manager.GetRiver(schelde.Name));
        }

        [TestMethod()]
        public void RemoveRiverTest_DoesNotExist()
        {
            GeoServiceContextTest context = new GeoServiceContextTest();
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(context));
            Assert.ThrowsException<DomainException>(() => manager.RemoveRiver(new River(9, "de", 165, context.TestData()[0].Countries.ToList())));
        }

        [TestMethod()]
        public void UpdateCityTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));

            City brussel = manager.GetCity("Brussel");
            brussel.Name = "NotBrussel";
            brussel.Population = 10;
            manager.UpdateCity(brussel);

            Assert.AreEqual(brussel, manager.GetCity("NotBrussel"));
        }

        [TestMethod()]
        public void UpdateContinentTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));

            var europe = manager.GetContinent("Europe");
            europe.Name = "NotEurope";
            manager.UpdateContinent(europe);

            Assert.AreEqual(europe, manager.GetContinent("NotEurope"));
        }

        [TestMethod()]
        public void UpdateCountryTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));

            var belgium = manager.GetCountry("Belgium");
            belgium.Name = "NotBelgium";
            belgium.Surface = 10;
            belgium.Population = 500;
            manager.UpdateCountry(belgium);


            Assert.AreEqual(belgium, manager.GetCountry("NotBelgium"));
        }
        
        [TestMethod()]
        public void UpdateRiverTest()
        {
            IGeoServiceManager manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContextTest()));

            var schelde = manager.GetRiver("Schelde");
            schelde.Name = "NotSchelde";
            schelde.Length = 10;
            manager.UpdateRiver(schelde);

            Assert.AreEqual(schelde, manager.GetRiver("NotSchelde"));
        }
    }
}