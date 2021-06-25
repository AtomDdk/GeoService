using Domain.Exceptions;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests.ModelTests
{
    [TestClass]
    public class CountryTests
    {
        [TestMethod]
        public void NameIsNull()
        {
            Assert.ThrowsException<DomainException>(() => new Country(1, null, 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void NameIsEmpty()
        {
            Assert.ThrowsException<DomainException>(() => new Country(1, "", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void ContinentIsNull()
        {
            Assert.ThrowsException<DomainException>(() => new Country(1, "Belgium", 200, 200, null, new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void PopulationIsLessThanOne()
        {
            Assert.ThrowsException<DomainException>(() => new Country(1, "Belgium", 0, 200, new Continent(), new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void SurfaceIsLessThanOne()
        {
            Assert.ThrowsException<DomainException>(() => new Country(1, "Belgium", 200, 0, new Continent(), new List<City>(), new List<City>(), new List<River>()));
        }

        [TestMethod]
        public void AddCityTest()
        {
            Country country = new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>());
            City city = new City(1, "Gent", 100, country);

            country.AddCity(city);

            Assert.AreEqual(1, country.Cities.Count);
        }

        [TestMethod]
        public void AddCityTest_CityIsNotUnique()
        {
            City capital = new City(1, "Gent", 100, new Country());
            City capital1 = new City(1, "Gent", 100, new Country());
            Assert.ThrowsException<DomainException>(() => new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City> { capital, capital1 }, new List<River>()));
        }

        [TestMethod]
        public void RemoveCityTest()
        {
            Country country = new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>());
            City city = new City(1, "Gent", 100, country);

            country.AddCity(city);
            country.RemoveCity(city);

            Assert.AreEqual(0, country.Cities.Count);
        }

        [TestMethod]
        public void AddCapitalTest()
        {
            Country country = new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>());
            City capital = new City(1, "Gent", 100, country);

            country.AddCapital(capital);

            Assert.AreEqual(1, country.Cities.Count);
            Assert.AreEqual(1, country.Capitals.Count);
        }

        [TestMethod]
        public void AddCapitalTest_CapitalIsNotUnique()
        {
            City city = new City(1, "Brussel", 100, new Country());
            City city1 = new City(1, "Brussel", 100, new Country());
            Assert.ThrowsException<DomainException>(() => new Country(1, "Belgium", 200, 200, new Continent(), new List<City> { city, city1 }, new List<City>(), new List<River>()));
        }

        [TestMethod]
        public void RemoveCapitalTest()
        {
            Country country = new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>());
            City capital = new City(1, "Gent", 100, country);

            country.AddCapital(capital);
            country.RemoveCapital(capital);

            Assert.AreEqual(0, country.Cities.Count);
            Assert.AreEqual(0, country.Capitals.Count);
        }

        [TestMethod]
        public void CitiesPopulaionIsHigherThanCountry()
        {
            City capital = new City(1, "Brussel", 100, new Country());
            City city = new City(1, "Gent", 100, new Country());
            Assert.ThrowsException<DomainException>(() => new Country(1, "Belgium", 100, 200, new Continent(), new List<City> { capital }, new List<City> { city }, new List<River>()));
        }

        [TestMethod]
        public void AddRiverTest()
        {
            Country country = new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>());
            River river = new River(1, "Schelde", 100, new List<Country> { country });

            country.AddRiver(river);

            Assert.AreEqual(1, country.Rivers.Count);
        }

        [TestMethod]
        public void AddRiverTest_RiverIsNotUnique()
        {
            Country country = new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>());
            River river = new River(1, "Schelde", 100, new List<Country> { country });
            River river1 = new River(1, "Schelde", 100, new List<Country> { country });

            Assert.ThrowsException<DomainException>(() => country.AddRivers(new List<River> { river, river1 }));
        }

        [TestMethod]
        public void RemoveRiverTest()
        {
            Country country = new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>());
            River river = new River(1, "Schelde", 100, new List<Country> { country });

            country.AddRiver(river);
            country.RemoveRiver(river);

            Assert.AreEqual(0, country.Rivers.Count);
        }
    }
}
