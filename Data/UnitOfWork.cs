using Data.Repos;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private GeoServiceContext _context;
        public UnitOfWork(GeoServiceContext context)
        {
            _context = context;
        }
        public IRepository<Continent> ContinentRepo => new ContinentRepo(_context);

        public IRepository<Country> CountryRepo => new CountryRepo(_context);

        public IRepository<City> CityRepo => new CityRepo(_context);

        public IRepository<River> RiverRepo => new RiverRepo(_context);
    }
}
