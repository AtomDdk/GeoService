using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Models.In
{
    public class CityApiIn
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public int CountryId { get; set; }
    }
}
