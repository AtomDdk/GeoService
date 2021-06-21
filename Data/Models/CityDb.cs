using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class CityDb
    {
        public CityDb() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public int CountryId { get; set; }
        public CountryDb Country { get; set; }
        public bool IsCapital { get; set; }
    }
}
