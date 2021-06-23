using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class Continent
    {
        public Continent() { }
        public Continent(int id, string name, List<Country> countries)
        {
            Id = id;
            Name = name;
            AddCountries(countries);
        }
        public int Id { get; set; }
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) == false ? _name = value : throw new DomainException("The Continent must have a name.");
        }
        public long Population => Countries.Sum(x => x.Population);
        private HashSet<Country> CountriesPrivate { get; set; } = new HashSet<Country>();
        public IReadOnlyList<Country> Countries => CountriesPrivate.ToList().AsReadOnly();

        public void AddCountries(IEnumerable<Country> countries)
        {
            countries ??= new List<Country>();
            foreach (var country in countries)
                AddCountry(country);
        }

        public void AddCountry(Country country)
        {
            if (CountriesPrivate.Any(x => x.Name == country.Name))
                throw new DomainException($"The name of a country must be unique within a continent. {country.Name}");
            if (CountriesPrivate.Add(country) == false)
                throw new DomainException($"The country already exists in this continent. {country}");
        }

        public override bool Equals(object obj)
        {
            return obj is Continent continent &&
                   Id == continent.Id &&
                   Name == continent.Name &&
                   Population == continent.Population;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Population);
        }
    }
}
