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
    public class ContinentRepoTests
    {
        [TestMethod()]
        public void ExistsTest()
        {
            ContinentRepo repo = new ContinentRepo(new GeoServiceContextTest());
            Assert.AreEqual(true, repo.Exists("Europe"));
            Assert.AreEqual(false, repo.Exists("Antartica"));
        }

        [TestMethod()]
        public void GetTestId()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(new GeoServiceContextTest());

            var europe = contextTest.TestData()[0];

            var continent = repo.Get(1);

            Assert.AreEqual(europe, continent);
            for (int i = 0; i < europe.Countries.Count; i++)
            {
                Assert.AreEqual(europe.Countries[i], continent.Countries[i]);

                for (int riverI = 0; riverI < europe.Countries[i].Rivers.Count; riverI++)
                    Assert.AreEqual(europe.Countries[i].Rivers[riverI], continent.Countries[i].Rivers[riverI]);

                for (int cityI = 0; cityI < europe.Countries[i].Cities.Count; cityI++)
                    Assert.AreEqual(europe.Countries[i].Cities[cityI], continent.Countries[i].Cities[cityI]);

                for (int capitalI = 0; capitalI < europe.Countries[i].Capitals.Count; capitalI++)
                    Assert.AreEqual(europe.Countries[i].Capitals[capitalI], continent.Countries[i].Capitals[capitalI]);
            }
        }

        [TestMethod()]
        public void GetTestName()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(new GeoServiceContextTest());

            var europe = contextTest.TestData()[0];
            var continent = repo.Get("Europe");

            Assert.AreEqual(europe, continent);
            for (int i = 0; i < europe.Countries.Count; i++)
            {
                Assert.AreEqual(europe.Countries[i], continent.Countries[i]);

                for (int riverI = 0; riverI < europe.Countries[i].Rivers.Count; riverI++)
                    Assert.AreEqual(europe.Countries[i].Rivers[riverI], continent.Countries[i].Rivers[riverI]);

                for (int cityI = 0; cityI < europe.Countries[i].Cities.Count; cityI++)
                    Assert.AreEqual(europe.Countries[i].Cities[cityI], continent.Countries[i].Cities[cityI]);

                for (int capitalI = 0; capitalI < europe.Countries[i].Capitals.Count; capitalI++)
                    Assert.AreEqual(europe.Countries[i].Capitals[capitalI], continent.Countries[i].Capitals[capitalI]);
            }
        }

        [TestMethod()]
        public void GetAllTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(new GeoServiceContextTest());

            var continents = contextTest.TestData();
            var continentsDb = repo.GetAll();

            for (int i = 0; i < continents.Count; i++)
            {
                Assert.AreEqual(continents[i], continentsDb[i]);

                for (int countryI = 0; countryI < continents[i].Countries.Count; countryI++)
                {
                    Assert.AreEqual(continents[i].Countries[countryI], continentsDb[i].Countries[countryI]);

                    for (int riverI = 0; riverI < continents[i].Countries[countryI].Rivers.Count; riverI++)
                        Assert.AreEqual(continents[i].Countries[countryI].Rivers[riverI], continentsDb[i].Countries[countryI].Rivers[riverI]);

                    for (int cityI = 0; cityI < continents[i].Countries[countryI].Cities.Count; cityI++)
                        Assert.AreEqual(continents[i].Countries[countryI].Cities[cityI], continentsDb[i].Countries[countryI].Cities[cityI]);

                    for (int capitalI = 0; capitalI < continents[i].Countries[countryI].Capitals.Count; capitalI++)
                        Assert.AreEqual(continents[i].Countries[countryI].Capitals[capitalI], continentsDb[i].Countries[countryI].Capitals[capitalI]);
                }
            }
        }

        [TestMethod()]
        public void AddTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(contextTest);

            Continent antartica = new Continent
            {
                Name = "Antartica"
            };

            repo.Add(antartica);
            contextTest.SaveChanges();

            Assert.AreEqual(true, repo.Exists("Antartica"));
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(contextTest);

            List<Continent> continents = new List<Continent>
            {
                new Continent
                {
                Name = "Antartica"
                },
                new Continent
                {
                Name = "Asia"
                }
            };

            repo.AddRange(continents);
            contextTest.SaveChanges();

            Assert.AreEqual(true, repo.Exists("Antartica"));
            Assert.AreEqual(true, repo.Exists("Asia"));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(contextTest);

            repo.Remove(contextTest.TestData()[2]);
            contextTest.SaveChanges();

            Assert.AreEqual(false, repo.Exists("United States"));
        }

        [TestMethod()]
        public void RemoveRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(contextTest);
            var continents = contextTest.TestData();

            repo.RemoveRange(continents);
            contextTest.SaveChanges();

            Assert.AreEqual(false, repo.Exists("United States"));
            Assert.AreEqual(false, repo.Exists("Europe"));
            Assert.AreEqual(false, repo.Exists("Oceania"));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(contextTest);

            var europe = contextTest.TestData()[0];
            europe.Name = "NotEurope";

            repo.Update(europe);
            contextTest.SaveChanges();

            Assert.AreEqual(europe, repo.Get(1));
        }

        [TestMethod()]
        public void UpdateRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            ContinentRepo repo = new ContinentRepo(contextTest);

            var continents = contextTest.TestData();
            continents[0].Name = "NotEurope";
            continents[1].Name = "NotOceania";
            continents[2].Name = "NotUnitedStates";

            repo.UpdateRange(continents);
            contextTest.SaveChanges();

            Assert.AreEqual(continents[0], repo.Get(1));
            Assert.AreEqual(continents[1], repo.Get(2));
            Assert.AreEqual(continents[2], repo.Get(3));
        }
    }
}