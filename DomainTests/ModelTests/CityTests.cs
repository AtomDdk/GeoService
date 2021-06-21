using Domain.Exceptions;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests.ModelTests
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        public void NameIsNull()
        {
            Assert.ThrowsException<CityException>(() => new City(1, null, 10000, new Country()));
        }
        [TestMethod]
        public void NameIsEmpty()
        {
            Assert.ThrowsException<CityException>(() => new City(1, "", 10000, new Country()));
        }
        [TestMethod]
        public void CountryIsNull()
        {
            Assert.ThrowsException<CityException>(() => new City(1, null, 10000, null));
        }
    }
}
