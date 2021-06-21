using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class River
    {
        public River() { }
        public River(int id, string name, long length, ICollection<Country> countries)
        {
            Id = id;
            Name = name;
            Length = length;
            AddCountries(countries);
        }

        public River(string name, long length, IEnumerable<Country> countries)
        {
            Name = name;
            Length = length;
            AddCountries(countries);
        }

        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) == false ? _name = value : throw new RiverException("The River must have a name");
        }
        private long _length;
        public long Length
        {
            get => _length;
            set => _length = value > 0 ? _length = value : throw new RiverException("A River cannot be 0 km or less in length.");
        }
        private HashSet<Country> CountriesPrivate { get; set; } = new HashSet<Country>();
        public IReadOnlyList<Country> Countries => CountriesPrivate.ToList().AsReadOnly();
        public void AddCountries(IEnumerable<Country> countries)
        {
            if (countries == null || countries.Count() < 1)
                throw new RiverException("A river must belong to 1 or more countries");
            foreach (var country in countries)
                AddCountry(country);
        }

        public void AddCountry(Country country)
        {
            if (CountriesPrivate.Add(country) == false)
                throw new RiverException($"The river already exists within this country. {country}");
        }

        public override bool Equals(object obj)
        {
            return obj is River river &&
                   Id == river.Id &&
                   Name == river.Name &&
                   Length == river.Length;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Length);
        }
    }
}
