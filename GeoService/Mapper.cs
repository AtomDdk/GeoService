using Domain.Models;
using GeoService.Models.In;
using GeoService.Models.Exit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoService.Models.Out;

namespace GeoService
{
    public static class Mapper
    {
        public static Continent ApiToDomain(ContinentApiIn continent)
        {
            return new Continent
            {
                Id = continent.Id,
                Name = continent.Name
            };
        }
        public static ContinentApiOut DomainToApi(Continent continent, string hostUrl)
        {
            return new ContinentApiOut
            {
                Id = continent.Id,
                Name = continent.Name,
                Population = continent.Population,
                CountryIds = continent.Countries.Select(x => $"{hostUrl}/api/continent/{continent.Id}/country/{x.Id}").ToList()
            };
        }

        public static Country ApiToDomain(CountryApiIn country)
        {
            return new Country
            {
                Name = country.Name,
                Population = country.Population,
                Surface = country.Surface
            };
        }
        public static CountryApiOut DomainToApi(Country country, string hostUrl)
        {
            return new CountryApiOut
            {
                Id = country.Id,
                Name = country.Name,
                Population = country.Population,
                Surface = country.Surface,
                Capitals = country.Capitals.Select(x => $"{hostUrl}/api/continent/{country.Continent.Id}/country/{country.Id}/cities/{x.Id}").ToList(),
                Cities = country.Cities.Select(x => $"{hostUrl}/api/continent/{country.Continent.Id}/country/{country.Id}/cities/{x.Id}").ToList(),
                Continent = $"{hostUrl}/api/continent/{country.Continent.Id}",
                Rivers = country.Rivers.Select(x => $"{hostUrl}/api/rivers/{x.Id}").ToList()
            };
        }
    }
}
