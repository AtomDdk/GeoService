using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repos
{
    public class CountryRepo : IRepository<Country>
    {
        private GeoServiceContext _context;
        public CountryRepo(GeoServiceContext context)
        {
            _context = context;
        }

        public bool Exists(string name)
        {
            try
            {
                return _context.Countries.AsNoTracking().Any(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Country Get(int id)
        {
            try
            {
                return Mapper.DbToModel(_context.Countries.AsNoTracking().Where(x => x.Id == id)
                    .Include(x => x.Cities)
                    .Include(x => x.Continent)
                    .Include(x => x.Rivers).ThenInclude(x => x.River).Single());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Country Get(string name)
        {

            try
            {
                return Mapper.DbToModel(_context.Countries.AsNoTracking().Where(x => x.Name == name)
                    .Include(x => x.Cities)
                    .Include(x => x.Continent)
                    .Include(x => x.Rivers).ThenInclude(x => x.River).Single());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Country> GetAll()
        {
            try
            {
                return _context.Countries.AsNoTracking()
                    .Include(x => x.Cities)
                    .Include(x => x.Continent)
                    .Include(x => x.Rivers).ThenInclude(x => x.River)
                    .Select(x => Mapper.DbToModel(x)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(Country value)
        {
            try
            {
                _context.Countries.Add(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRange(IEnumerable<Country> values)
        {
            try
            {
                _context.AddRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(Country value)
        {
            try
            {
                _context.Countries.Remove(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveRange(IEnumerable<Country> values)
        {
            try
            {
                _context.RemoveRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Country value)
        {
            try
            {
                _context.Countries.Update(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRange(IEnumerable<Country> values)
        {
            try
            {
                _context.UpdateRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
