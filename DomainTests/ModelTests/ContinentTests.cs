using Domain.Exceptions;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests.ModelTests
{
    [TestClass]
    public class ContinentTests
    {
        [TestMethod]
        public void NameIsNull()
        {
            Assert.ThrowsException<ContinentException>(() => new Continent(1, null, new List<Country>()));
        }
        [TestMethod]
        public void NameIsEmpty()
        {
            Assert.ThrowsException<ContinentException>(() => new Continent(1, "", new List<Country>()));
        }

        [TestMethod]
        public void CountriesAreNotUniqueAddRange()
        {
            Continent continent = new Continent(1, "Europe", new List<Country>());
            Country country = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            Country country1 = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            Assert.ThrowsException<ContinentException>(() => continent.AddCountries(new List<Country> { country, country1 }));
        }

        [TestMethod]
        public void CountriesAreNotUniqueAdd()
        {
            Continent continent = new Continent(1, "Europe", new List<Country>());
            Country country = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            Country country1 = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            continent.AddCountry(country1);
            Assert.ThrowsException<ContinentException>(() => continent.AddCountry(country));
        }

        [TestMethod]
        public void CountryNamesAreNotUniqueAddRange()
        {
            Continent continent = new Continent(1, "Europe", new List<Country>());
            Country country = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            Country country1 = new Country(130, "Belgium", 400, 300, continent, new List<City>(), new List<City>(), new List<River>());
            Assert.ThrowsException<ContinentException>(() => continent.AddCountries(new List<Country> { country, country1 }));
        }

        [TestMethod]
        public void CountryNamesAreNotUniqueAdd()
        {
            Continent continent = new Continent(1, "Europe", new List<Country>());
            Country country = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            Country country1 = new Country(130, "Belgium", 400, 300, continent, new List<City>(), new List<City>(), new List<River>());
            continent.AddCountry(country1);
            Assert.ThrowsException<ContinentException>(() => continent.AddCountry(country));
        }
        [TestMethod]
        public void PopulationOfCountriesIsCorrect()
        {

            Continent continent = new Continent(1, "Europe", new List<Country>());
            Country country = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            Country country1 = new Country(2, "France", 400, 300, continent, new List<City>(), new List<City>(), new List<River>());

            Assert.AreEqual(500, country.Population + country1.Population);
        }
    }
}
