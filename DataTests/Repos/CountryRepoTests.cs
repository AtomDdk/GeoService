using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using DataTests;
using System.Linq;
using Domain.Models;

namespace Data.Repos.Tests
{
    [TestClass()]
    public class CountryRepoTests
    {
        [TestMethod()]
        public void ExistsTest()
        {
            CountryRepo repo = new CountryRepo(new GeoServiceContextTest());
            Assert.AreEqual(true, repo.Exists("Belgium"));
            Assert.AreEqual(false, repo.Exists("Germany"));
        }

        [TestMethod()]
        public void GetTestId()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(new GeoServiceContextTest());

            var belgium = contextTest.TestData()[0].Countries.ToList()[0];

            Assert.AreEqual(belgium, repo.Get(1));
        }

        [TestMethod()]
        public void GetTestName()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(new GeoServiceContextTest());

            var belgium = contextTest.TestData()[0].Countries.ToList()[0];

            Assert.AreEqual(belgium, repo.Get("Belgium"));
        }

        [TestMethod()]
        public void GetAllTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(contextTest);

            var continents = contextTest.TestData();
            var countriesDb = repo.GetAll();

            var belgium = continents[0].Countries.ToList()[0];
            var france = continents[0].Countries.ToList()[1];
            var australia = continents[1].Countries.ToList()[0];

            Assert.AreEqual(belgium, countriesDb[0]);
            Assert.AreEqual(france, countriesDb[1]);
            Assert.AreEqual(australia, countriesDb[2]);
            Assert.AreEqual(3, countriesDb.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(contextTest);
            var continents = contextTest.TestData();

            Country country = new Country
            {
                Name = "Germany",
                Continent = continents[0],
                Population = 50,
                Surface = 100
            };

            repo.Add(country);
            contextTest.SaveChanges();

            Assert.AreEqual(true, repo.Exists("Germany"));
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(contextTest);
            var continents = contextTest.TestData();

            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Name = "Germany",
                    Continent = continents[0],
                    Population = 50,
                    Surface = 100
                },
                new Country
                {
                    Name = "Italy",
                    Continent = continents[0],
                    Population = 10,
                    Surface = 500
                }
            };

            repo.AddRange(countries);
            contextTest.SaveChanges();

            Assert.AreEqual(true, repo.Exists("Germany"));
            Assert.AreEqual(true, repo.Exists("Italy"));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(contextTest);
            var continents = contextTest.TestData();

            repo.Remove(continents[0].Countries.First());
            contextTest.SaveChanges();

            Assert.AreEqual(false, repo.Exists("Belgium"));
        }

        [TestMethod()]
        public void RemoveRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(contextTest);
            var continents = contextTest.TestData();

            repo.Remove(continents[0].Countries.First());
            repo.Remove(continents[0].Countries.Last());
            contextTest.SaveChanges();

            Assert.AreEqual(false, repo.Exists("Belgium"));
            Assert.AreEqual(false, repo.Exists("France"));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(contextTest);
            var continents = contextTest.TestData();
            var countryToUpdate = continents[0].Countries.Last();
            countryToUpdate.Population = 10;

            repo.Update(countryToUpdate);
            contextTest.SaveChanges();

            var updatedCountry = repo.Get(2);

            Assert.AreEqual(countryToUpdate, updatedCountry);
        }

        [TestMethod()]
        public void UpdateRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(contextTest);
            var continents = contextTest.TestData();
            var countryToUpdate = continents[1].Countries.First();
            countryToUpdate.Population = 600;
            var countryToUpdate1 = continents[0].Countries.Last();
            countryToUpdate1.Population = 50;

            repo.UpdateRange(new List<Country> { countryToUpdate, countryToUpdate1 });
            contextTest.SaveChanges();

            var updatedCountry = repo.Get(3);
            var updatedCountry1 = repo.Get(2);

            Assert.AreEqual(countryToUpdate, updatedCountry);
            Assert.AreEqual(countryToUpdate1, updatedCountry1);
        }
    }
}