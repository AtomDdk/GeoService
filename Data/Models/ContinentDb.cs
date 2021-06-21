using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ContinentDb
    {
        public ContinentDb() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public IList<CountryDb> Countries { get; set; } = new List<CountryDb>();
    }
}
