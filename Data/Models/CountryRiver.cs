using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class CountryRiver
    {
        public int CountryId { get; set; }
        public CountryDb Country { get; set; }
        public int RiverId { get; set; }
        public RiverDb River { get; set; }
    }
}
