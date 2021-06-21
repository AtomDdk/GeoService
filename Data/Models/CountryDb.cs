using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class CountryDb
    {
        public CountryDb() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public long Surface { get; set; }
        public int ContinentId { get; set; }
        public ContinentDb Continent { get; set; }
        public IList<CityDb> Cities { get; set; } = new List<CityDb>();
        public IList<CountryRiver> Rivers { get; set; } = new List<CountryRiver>();
    }
}
