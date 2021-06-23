using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Models.Out
{
    public class ContinentApiOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public List<string> CountryIds { get; set; } = new List<string>();
    }
}
