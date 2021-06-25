using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Models.Exit
{
    public class CountryApiOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public long Surface { get; set; }
        public string Continent { get; set; }
        public List<string> Capitals { get; set; } = new List<string>();
        public List<string> Cities { get; set; } = new List<string>();
        public List<string> Rivers { get; set; } = new List<string>();
    }
}
