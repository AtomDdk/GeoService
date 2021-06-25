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

            var belgiumTest = contextTest.TestData()[0].Countries.ToList()[0];
            var belgiumData = repo.Get(1);

            Assert.AreEqual(belgiumTest, belgiumData);
            Assert.AreEqual(belgiumTest.Continent.Id, belgiumData.Continent.Id);
            Assert.AreEqual(belgiumTest.Continent.Name, belgiumData.Continent.Name);
            
            Assert.AreEqual(belgiumTest.Cities.Count, belgiumData.Cities.Count);
            for (int i = 0; i < belgiumTest.Cities.Count; i++)
                Assert.AreEqual(belgiumTest.Cities[i], belgiumData.Cities[i]);
            
            Assert.AreEqual(belgiumTest.Capitals.Count, belgiumData.Capitals.Count);
            for (int i = 0; i < belgiumTest.Capitals.Count; i++)
                Assert.AreEqual(belgiumTest.Capitals[i], belgiumData.Capitals[i]);
            
            Assert.AreEqual(belgiumTest.Rivers.Count, belgiumData.Rivers.Count);
            for (int i = 0; i < belgiumTest.Rivers.Count; i++)
                Assert.AreEqual(belgiumTest.Rivers[i], belgiumData.Rivers[i]);
        }

        [TestMethod()]
        public void GetTestName()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(new GeoServiceContextTest());

            var belgiumTest = contextTest.TestData()[0].Countries.ToList()[0];
            var belgiumData = repo.Get("Belgium");

            Assert.AreEqual(belgiumTest, belgiumData);
            Assert.AreEqual(belgiumTest.Continent.Id, belgiumData.Continent.Id);
            Assert.AreEqual(belgiumTest.Continent.Name, belgiumData.Continent.Name);

            Assert.AreEqual(belgiumTest.Cities.Count, belgiumData.Cities.Count);
            for (int i = 0; i < belgiumTest.Cities.Count; i++)
                Assert.AreEqual(belgiumTest.Cities[i], belgiumData.Cities[i]);
            
            Assert.AreEqual(belgiumTest.Capitals.Count, belgiumData.Capitals.Count);
            for (int i = 0; i < belgiumTest.Capitals.Count; i++)
                Assert.AreEqual(belgiumTest.Capitals[i], belgiumData.Capitals[i]);
            
            Assert.AreEqual(belgiumTest.Rivers.Count, belgiumData.Rivers.Count);
            for (int i = 0; i < belgiumTest.Rivers.Count; i++)
                Assert.AreEqual(belgiumTest.Rivers[i], belgiumData.Rivers[i]);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            CountryRepo repo = new CountryRepo(contextTest);

            var countriesTest = contextTest.TestData()[0].Countries;
            var countriesData = repo.GetAll();

            Assert.AreEqual(3, countriesData.Count);
            for (int countryI = 0;countryI<countriesTest.Count;countryI++)
            {
                Assert.AreEqual(countriesTest[countryI].Cities.Count, countriesData[countryI].Cities.Count);
                for (int i = 0; i < countriesTest[countryI].Cities.Count; i++)
                    Assert.AreEqual(countriesTest[countryI].Cities[i], countriesData[countryI].Cities[i]);

                Assert.AreEqual(countriesTest[countryI].Capitals.Count, countriesData[countryI].Capitals.Count);
                for (int i = 0; i < countriesTest[countryI].Capitals.Count; i++)
                    Assert.AreEqual(countriesTest[countryI].Capitals[i], countriesData[countryI].Capitals[i]);


                Assert.AreEqual(countriesTest[countryI].Rivers.Count, countriesData[countryI].Rivers.Count);
                for (int i = 0; i < countriesTest[countryI].Rivers.Count; i++)
                    Assert.AreEqual(countriesTest[countryI].Rivers[i], countriesData[countryI].Rivers[i]);
            }
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

            var testData = contextTest.TestData();
            var belgiumTest = testData[0].Countries[0];
            //var countryToUpdate = continents[0].Countries.Last();
            //countryToUpdate.Population = 10;

            belgiumTest.AddRiver(testData[1].Countries[0].Rivers[0]);
            belgiumTest.RemoveRiver(belgiumTest.Rivers[0]);
            belgiumTest.Population = 1000;
            belgiumTest.Continent = testData[1];
            belgiumTest.Name = "NotBelgium";


            repo.Update(belgiumTest);
            contextTest.SaveChanges();

            var belgiumData = repo.Get(1);

            Assert.AreEqual(belgiumTest, belgiumData);
            Assert.AreEqual(belgiumTest.Continent.Id, belgiumData.Continent.Id);
            Assert.AreEqual(belgiumTest.Continent.Name, belgiumData.Continent.Name);

            Assert.AreEqual(belgiumTest.Cities.Count, belgiumData.Cities.Count);
            for (int i = 0; i < belgiumTest.Cities.Count; i++)
                Assert.AreEqual(belgiumTest.Cities[i], belgiumData.Cities[i]);

            Assert.AreEqual(belgiumTest.Capitals.Count, belgiumData.Capitals.Count);
            for (int i = 0; i < belgiumTest.Capitals.Count; i++)
                Assert.AreEqual(belgiumTest.Capitals[i], belgiumData.Capitals[i]);

            Assert.AreEqual(belgiumTest.Rivers.Count, belgiumData.Rivers.Count);
            for (int i = 0; i < belgiumTest.Rivers.Count; i++)
                Assert.AreEqual(belgiumTest.Rivers[i], belgiumData.Rivers[i]);
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