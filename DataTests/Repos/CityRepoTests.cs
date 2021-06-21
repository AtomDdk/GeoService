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
    public class CityRepoTests
    {
        [TestMethod()]
        public void ExistsTest()
        {
            CityRepo repo = new CityRepo(new GeoServiceContextTest());
            Assert.AreEqual(true, repo.Exists("Brussel"));
            Assert.AreEqual(false, repo.Exists("New York"));
        }

        [TestMethod()]
        public void GetTestId()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(new GeoServiceContextTest());

            var brussel = contextTest.TestData()[0].Countries.ToList()[0].Cities.ToList()[0];

            Assert.AreEqual(brussel, repo.Get(1));
        }

        [TestMethod()]
        public void GetTestName()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(new GeoServiceContextTest());

            var brussel = contextTest.TestData()[0].Countries.ToList()[0].Cities.ToList()[0];

            Assert.AreEqual(brussel, repo.Get("Brussel"));
        }

        [TestMethod()]
        public void GetAllTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(contextTest);

            var continents = contextTest.TestData();
            var citysDb = repo.GetAll();

            var brussel = continents[0].Countries.ToList()[0].Cities[0];
            var gent = continents[0].Countries.ToList()[0].Cities[1];
            var perth = continents[1].Countries.ToList()[0].Cities[0];

            Assert.AreEqual(brussel, citysDb[0]);
            Assert.AreEqual(gent, citysDb[1]);
            Assert.AreEqual(perth, citysDb[2]);
            Assert.AreEqual(3, citysDb.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(contextTest);
            var continents = contextTest.TestData();

            City city = new City
            {
                Name = "Parijs",
                Population = 20,
                Country = continents[0].Countries.ToList()[1]
            };

            repo.Add(city);
            contextTest.SaveChanges();

            Assert.AreEqual(true, repo.Exists("Parijs"));
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(contextTest);
            var continents = contextTest.TestData();

            List<City> cities = new List<City> {
                new City
                    {
                        Name = "Parijs",
                        Population = 20,
                        Country = continents[0].Countries.ToList()[1]
                    },
                new City
                    {
                        Name = "Nice",
                        Population = 30,
                        Country = continents[0].Countries.ToList()[1]
                    }
            };
            repo.AddRange(cities);
            contextTest.SaveChanges();

            Assert.AreEqual(true, repo.Exists("Parijs"));
            Assert.AreEqual(true, repo.Exists("Nice"));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(contextTest);

            var continents = contextTest.TestData();

            repo.Remove(continents[0].Countries.ToList()[0].Cities[0]);
            contextTest.SaveChanges();

            Assert.AreEqual(false, repo.Exists("Brussel"));
        }

        [TestMethod()]
        public void RemoveRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(contextTest);

            var continents = contextTest.TestData();

            repo.RemoveRange(continents[0].Countries.ToList()[0].Cities);
            contextTest.SaveChanges();

            Assert.AreEqual(false, repo.Exists("Brussel"));
            Assert.AreEqual(false, repo.Exists("Gent"));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(contextTest);
            var brussel = contextTest.TestData()[0].Countries.ToList()[0].Cities[0];

            brussel.Population = 50;

            repo.Update(brussel);
            contextTest.SaveChanges();

            Assert.AreEqual(50, repo.Get(1).Population);
        }

        [TestMethod()]
        public void UpdateRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CityRepo repo = new CityRepo(contextTest);
            var cities = contextTest.TestData()[0].Countries.ToList()[0].Cities;

            cities[0].Population = 50;
            cities[1].Population = 100;

            repo.UpdateRange(cities);
            contextTest.SaveChanges();

            Assert.AreEqual(50, repo.Get(1).Population);
            Assert.AreEqual(100, repo.Get(2).Population);
        }
    }
}