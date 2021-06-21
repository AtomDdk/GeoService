using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Continent> ContinentRepo { get; }
        public IRepository<Country> CountryRepo{ get; }
        public IRepository<City> CityRepo { get; }
        public IRepository<River> RiverRepo { get; }
    }
}
