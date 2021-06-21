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
            Assert.ThrowsException<CountryException>(() => new Country(1, null, 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void NameIsEmpty()
        {
            Assert.ThrowsException<CountryException>(() => new Country(1, "", 200, 200, new Continent(), new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void ContinentIsNull()
        {
            Assert.ThrowsException<CountryException>(() => new Country(1, "Belgium", 200, 200, null, new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void PopulationIsLessThanOne()
        {
            Assert.ThrowsException<CountryException>(() => new Country(1, "Belgium", 0, 200, new Continent(), new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void SurfaceIsLessThanOne()
        {
            Assert.ThrowsException<CountryException>(() => new Country(1, "Belgium", 200, 0, new Continent(), new List<City>(), new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void CityIsNotUnique()
        {
            City capital = new City(1, "Gent", 100, new Country());
            City capital1 = new City(1, "Gent", 100, new Country());
            Assert.ThrowsException<CountryException>(() => new Country(1, "Belgium", 200, 200, new Continent(), new List<City>(), new List<City> { capital, capital1 }, new List<River>()));
        }
        [TestMethod]
        public void CapitalIsNotUnique()
        {
            City city = new City(1, "Brussel", 100, new Country());
            City city1 = new City(1, "Brussel", 100, new Country());
            Assert.ThrowsException<CountryException>(() => new Country(1, "Belgium", 200, 200, new Continent(), new List<City> { city, city1 }, new List<City>(), new List<River>()));
        }
        [TestMethod]
        public void CapitalIsInCities()
        {
            City capital = new City(1, "Brussel", 100, new Country());
            City city = new City(1, "Gent", 100, new Country());
            Country country = new Country(1, "Belgium", 200, 200, new Continent(), new List<City> { capital }, new List<City> { city }, new List<River>());

            Assert.AreEqual(1, country.Capitals.Count);
            Assert.AreEqual(2, country.Cities.Count);
        } 
        [TestMethod]
        public void CitiesPopulaionIsHigherThanCountry()
        {
            City capital = new City(1, "Brussel", 100, new Country());
            City city = new City(1, "Gent", 100, new Country());
            Assert.ThrowsException<CountryException>(() => new Country(1, "Belgium", 100, 200, new Continent(), new List<City> { capital }, new List<City> { city }, new List<River>()));
        }
    }
}
