using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class RiverDb
    {
        public RiverDb() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public long Length { get; set; }
        public IList<CountryRiver> Countries { get; set; } = new List<CountryRiver>();
    }
}
