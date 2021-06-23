using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repos
{
    public class ContinentRepo : IRepository<Continent>
    {
        private GeoServiceContext _context;
        public ContinentRepo(GeoServiceContext context)
        {
            _context = context;
        }
        public void Add(Continent value)
        {
            try
            {
                _context.Continents.Add(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRange(IEnumerable<Continent> values)
        {
            try
            {
                _context.Continents.AddRange(values.Select(x => Mapper.ModelToDb(x)));
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
                return _context.Continents.AsNoTracking().Any(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(int id)
        {
            try
            {
                return _context.Continents.AsNoTracking().Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Continent Get(int id)
        {
            try
            {
                return Mapper.DbToModel(_context.Continents.AsNoTracking().Where(x => x.Id == id)
                    .Include(x => x.Countries).ThenInclude(x => x.Cities)
                    .Include(x => x.Countries).ThenInclude(x => x.Rivers).ThenInclude(x => x.River)
                    .Single());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Continent Get(string name)
        {
            try
            {
                return Mapper.DbToModel(_context.Continents.AsNoTracking().Where(x => x.Name == name)
                    .Include(x => x.Countries).ThenInclude(x => x.Cities)
                    .Include(x => x.Countries).ThenInclude(x => x.Rivers).ThenInclude(x => x.River)
                    .Single());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Continent> GetAll()
        {
            try
            {
                return _context.Continents.AsNoTracking()
                    .Include(x => x.Countries).ThenInclude(x => x.Cities)
                    .Include(x => x.Countries).ThenInclude(x => x.Rivers).ThenInclude(x => x.River)
                    .Select(x => Mapper.DbToModel(x)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(Continent value)
        {
            try
            {
                _context.Continents.Remove(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveRange(IEnumerable<Continent> values)
        {
            try
            {
                _context.Continents.RemoveRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Continent value)
        {
            try
            {
                _context.Continents.Update(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRange(IEnumerable<Continent> values)
        {
            try
            {
                _context.Continents.UpdateRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
