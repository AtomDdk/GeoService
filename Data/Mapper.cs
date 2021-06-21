using Data.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public static class Mapper
    {
        public static ContinentDb ModelToDb(Continent continent)
        {
            return new ContinentDb
            {
                Id = continent.Id,
                Name = continent.Name,
                Population = continent.Population,
                Countries = continent.Countries.Select(x => ModelToDb(x)).ToList()
            };
        }

        public static Continent DbToModel(ContinentDb continent)
        {
            return new Continent
            (
                continent.Id,
                continent.Name,
                continent.Countries.Select(x => DbToModel(x)).ToList()
            );
        }

        public static CountryDb ModelToDb(Country country)
        {
            return new CountryDb
            {
                Id = country.Id,
                Name = country.Name,
                Population = country.Population,
                Surface = country.Surface,
                ContinentId = country.Continent.Id,
                Cities = country.Cities.Select(x => ModelToDb(x)).ToList(),
                Rivers = country.Rivers.Select(x => new CountryRiver
                {
                    CountryId = country.Id,
                    RiverId = x.Id
                }).ToList()
            };
        }

        public static Country DbToModel(CountryDb country)
        {
            return new Country
            (
                country.Id,
                country.Name,
                country.Population,
                country.Surface,
                new Continent
                {
                    Id = country.ContinentId,
                    Name = country.Continent.Name
                },
                country.Cities.Where(x => x.IsCapital).Select(x => DbToModel(x)).ToList(),
                country.Cities.Where(x => x.IsCapital == false).Select(x => DbToModel(x)).ToList(),
                country.Rivers.Select(x => new River
                {
                    Id = x.RiverId,
                    Length = x.River.Length,
                    Name = x.River.Name
                }).ToList()
            );
        }

        public static RiverDb ModelToDb(River river)
        {
            return new RiverDb
            {
                Id = river.Id,
                Length = river.Length,
                Name = river.Name,
                Countries = river.Countries.Select(x => new CountryRiver { CountryId = x.Id, RiverId = river.Id }).ToList()
            };
        }


        public static River DbToModel(RiverDb riverDb)
        {
            return new River(riverDb.Id, riverDb.Name, riverDb.Length, riverDb.Countries.Select(x => new Country
            {
                Id = x.Country.Id,
                Name = x.Country.Name,
                Population = x.Country.Population,
                Surface = x.Country.Surface
            }).ToList());
        }

        public static City DbToModel(CityDb city)
        {
            return new City
            {
                Id = city.Id,
                Name = city.Name,
                Population = city.Population,
                Country = new Country
                {
                    Id = city.Country.Id,
                    Name = city.Country.Name,
                    Population = city.Country.Population,
                    Surface = city.Country.Surface,
                    Continent = new Continent
                    {
                        Id = city.Country.Continent.Id,
                        Name = city.Country.Continent.Name
                    }
                }
            };
        }

        public static CityDb ModelToDb(City city)
        {
            return new CityDb
            {
                Id = city.Id,
                Name = city.Name,
                Population = city.Population,
                CountryId = city.Country.Id,
                IsCapital = city.Country.Capitals.Contains(city)
            };
        }
    }
}
