using Domain.Models;
using GeoService.Models.In;
using GeoService.Models.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public static ContinentApiOut DomainToApi(Continent continent)
        {
            return new ContinentApiOut
            {
                Id = continent.Id,
                Name = continent.Name,
                Population = continent.Population,
                CountryIds = continent.Countries.Select(x => $"TODO {x.Id}").ToList()
            };
        }
    }
}
