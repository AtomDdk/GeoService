using Domain.Exceptions;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests.ModelTests
{
    [TestClass]
    public class RiverTests
    {
        [TestMethod]
        public void NameIsNull()
        {
            List<Country> countries = new List<Country>
            {
                new Country(),
                new Country()
            };

            Assert.ThrowsException<RiverException>(() => new River(1, null, 10000, countries));
        }
        [TestMethod]
        public void NameIsEmpty()
        {
            List<Country> countries = new List<Country>
            {
                new Country(),
                new Country()
            };

            Assert.ThrowsException<RiverException>(() => new River(1, "", 10000, countries));
        }
        [TestMethod]
        public void LengthIsLessThenOne()
        {
            List<Country> countries = new List<Country>
            {
                new Country(),
                new Country()
            };

            Assert.ThrowsException<RiverException>(() => new River(1, "", 0, countries));
        }
        [TestMethod]
        public void CountriesIsEmpty()
        {
            List<Country> countries = new List<Country>();

            Assert.ThrowsException<RiverException>(() => new River(1, "Schelde", 10000, countries));
        }
        [TestMethod]
        public void CountriesIsNull()
        {
            List<Country> countries = new List<Country>();

            Assert.ThrowsException<RiverException>(() => new River(1, "Schelde", 10000, null));
        }
        [TestMethod]
        public void CountriesAreNotUnique()
        {


            Continent continent = new Continent(1, "Europe", new List<Country>());
            Country country = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            Country country1 = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            List<Country> countries = new List<Country> { country, country1 };

            Assert.ThrowsException<RiverException>(() => new River(1, "Schelde", 100, countries));
        }
    }
}
