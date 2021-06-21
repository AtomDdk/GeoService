using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using DataTests;
using Domain.Models;
using System.Linq;

namespace Data.Repos.Tests
{
    [TestClass()]
    public class RiverRepoTests
    {

        [TestMethod()]
        public void ExistsTest()
        {
            RiverRepo repo = new RiverRepo(new GeoServiceContextTest());
            Assert.AreEqual(true, repo.Exists("Schelde"));
            Assert.AreEqual(false, repo.Exists("Nile"));
        }

        [TestMethod()]
        public void GetTestId()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(new GeoServiceContextTest());
            
            var schelde = contextTest.TestData()[0].Countries.ToList()[0].Rivers.ToList()[0];

            var river = repo.Get(1);

            Assert.AreEqual(schelde, river);
            for (int i = 0; i < river.Countries.Count; i++)
                Assert.AreEqual(schelde.Countries[i], river.Countries[i]);
        }

        [TestMethod()]
        public void GetTestName()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(new GeoServiceContextTest());

            var schelde = contextTest.TestData()[0].Countries.ToList()[0].Rivers.ToList()[0];
            var river = repo.Get("schelde");

            Assert.AreEqual(schelde, river);
            for (int i = 0; i < river.Countries.Count; i++)
                Assert.AreEqual(schelde.Countries[i], river.Countries[i]);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(contextTest);

            var continents = contextTest.TestData();
            var riversDb = repo.GetAll();

            var schelde = continents[0].Countries.ToList()[0].Rivers[0];
            var maas = continents[0].Countries.ToList()[0].Rivers[1];
            var swanRiver = continents[1].Countries.ToList()[0].Rivers[0];
            
            Assert.AreEqual(schelde , riversDb[0]);
            for (int i = 0; i < schelde.Countries.Count; i++)
                Assert.AreEqual(schelde.Countries[i], riversDb[0].Countries[i]);

            Assert.AreEqual(maas , riversDb[1]);
            for (int i = 0; i < maas.Countries.Count; i++)
                Assert.AreEqual(maas.Countries[i], riversDb[1].Countries[i]);

            Assert.AreEqual(swanRiver, riversDb[2]);
            for (int i = 0; i < swanRiver.Countries.Count; i++)
                Assert.AreEqual(swanRiver.Countries[i], riversDb[2].Countries[i]);

            Assert.AreEqual(3, riversDb.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(contextTest);
            var continents = contextTest.TestData();

            River river = new River("Rijn", 160, continents[0].Countries);

            repo.Add(river);
            contextTest.SaveChanges();

            Assert.AreEqual(true, repo.Exists("Rijn"));
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(contextTest);
            var continents = contextTest.TestData();

            List<River> rivers = new List<River>
            {
                new River("Rijn", 160, continents[0].Countries),
                new River("Mississipi", 600, continents[0].Countries)
            };

            repo.AddRange(rivers);
            contextTest.SaveChanges();

            Assert.AreEqual(true, repo.Exists("Rijn"));
            Assert.AreEqual(true, repo.Exists("Mississipi"));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(contextTest);

            var continents = contextTest.TestData();

            repo.Remove(continents[0].Countries.ToList()[0].Rivers[0]);
            contextTest.SaveChanges();

            Assert.AreEqual(false, repo.Exists("Schelde"));
        }

        [TestMethod()]
        public void RemoveRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(contextTest);

            var continents = contextTest.TestData();

            repo.RemoveRange(continents[0].Countries.ToList()[0].Rivers);
            contextTest.SaveChanges();

            Assert.AreEqual(false, repo.Exists("Schelde"));
            Assert.AreEqual(false, repo.Exists("Maas"));
        }

        [TestMethod()]
        public void UpdateRangeTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(contextTest);
            var rivers = contextTest.TestData()[0].Countries.ToList()[0].Rivers;

            rivers[0].Length = 900;
            rivers[1].Length = 60;

            repo.UpdateRange(rivers);
            contextTest.SaveChanges();

            Assert.AreEqual(900, repo.Get(1).Length);
            Assert.AreEqual(60, repo.Get(2).Length);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            GeoServiceContextTest contextTest = new GeoServiceContextTest();
            RiverRepo repo = new RiverRepo(contextTest);
            var river = contextTest.TestData()[0].Countries.ToList()[0].Rivers[0];

            river.Length = 900;

            repo.Update(river);
            contextTest.SaveChanges();

            Assert.AreEqual(900, repo.Get(1).Length);
        }
    }
}