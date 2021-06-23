using Data.Models;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repos
{
    public class RiverRepo : IRepository<River>
    {
        private GeoServiceContext _context;
        public RiverRepo(GeoServiceContext context)
        {
            _context = context;
        }
        public void Add(River value)
        {
            try
            {
                _context.Rivers.Add(Mapper.ModelToDb(value));
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRange(IEnumerable<River> values)
        {
            try
            {
                _context.Rivers.AddRange(values.Select(x => Mapper.ModelToDb(x)));
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
                return _context.Rivers.AsNoTracking().Any(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public River Get(int id)
        {
            try
            {
                return Mapper.DbToModel(_context.Rivers.AsNoTracking().Where(x => x.Id == id).Include(x => x.Countries).ThenInclude(x => x.Country).Single());
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
                return _context.Rivers.AsNoTracking().Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public River Get(string name)
        {
            try
            {
                return Mapper.DbToModel(_context.Rivers.AsNoTracking().Where(x => x.Name == name).Include(x => x.Countries).ThenInclude(x => x.Country).Single());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<River> GetAll()
        {
            try
            {
                return _context.Rivers.AsNoTracking().Include(x => x.Countries).ThenInclude(x => x.Country).Select(x => Mapper.DbToModel(x)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(River value)
        {
            try
            {
                _context.Rivers.Remove(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveRange(IEnumerable<River> values)
        {
            try
            {
                _context.Rivers.RemoveRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(River value)
        {
            try
            {
                _context.Rivers.Update(Mapper.ModelToDb(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRange(IEnumerable<River> values)
        {
            try
            {
                _context.Rivers.UpdateRange(values.Select(x => Mapper.ModelToDb(x)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
