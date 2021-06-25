using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Models.In
{
    public class CountryApiIn
    {
        public int Id { get; set; }
        public int ContinentId { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public long Surface { get; set; }
        public List<int> RiverIds { get; set; } = new List<int>();
    }
}
