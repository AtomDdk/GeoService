using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repos
{
    public class CityRepo : IRepository<City>
    {
        private GeoServiceContext _context;
        public CityRepo(GeoServiceContext context)
        {
            _context = context;
        }

        public void Add(City value)
        {
            try
            {
                _context.Cities.Add(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRange(IEnumerable<City> values)
        {
            try
            {
                _context.Cities.AddRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(string name)
        {
            try
            {
                return _context.Cities.AsNoTracking().Any(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public City Get(int id)
        {
            try
            {
                var city = _context.Cities.AsNoTracking().Where(x => x.Id == id).Include(c => c.Country).ThenInclude(x => x.Continent).Single();
                return Mapper.DbToModel(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public City Get(string name)
        {
            try
            {
                return Mapper.DbToModel(_context.Cities.AsNoTracking().Where(x => x.Name == name).Include(c => c.Country).ThenInclude(x => x.Continent).Single());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<City> GetAll()
        {
            try
            {
                var cities = _context.Cities.AsNoTracking().Include(c => c.Country).ThenInclude(x => x.Continent);
                return cities.Select(x => Mapper.DbToModel(x)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(City value)
        {
            try
            {
                _context.Cities.Remove(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveRange(IEnumerable<City> values)
        {
            try
            {
                _context.Cities.RemoveRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(City value)
        {
            try
            {
                var x = Mapper.ModelToDb(value);
                _context.Cities.Update(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRange(IEnumerable<City> values)
        {
            try
            {
                _context.Cities.UpdateRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
