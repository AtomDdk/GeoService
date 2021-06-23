using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class Country
    {
        public Country() { }

        public Country(int id, string name, long population, long surface, Continent continent, List<City> capitals, List<City> cities, List<River> rivers)
        {
            Id = id;
            Name = name;
            Population = population;
            Surface = surface;
            Continent = continent;
            AddCapitals(capitals);
            AddCities(cities);
            AddRivers(rivers);
        }

        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) == false ? _name = value : throw new DomainException("The Country must have a name");
        }
        private long _population;
        public long Population
        {
            get => _population;
            set => _population = value > 0 ? _population = value : throw new DomainException("The population of a Country must be higher then 0.");
        }
        private long _surface;
        public long Surface
        {
            get => _surface;
            set => _surface = value > 0 ? _surface = value : throw new DomainException("The Surface of a Country must be higher then 0.");
        }
        private Continent _continent;
        public Continent Continent
        {
            get => _continent;
            set => _continent = value ?? throw new DomainException("The Country must be part of a Continent");
        }

        private HashSet<City> CitiesPrivate { get; set; } = new HashSet<City>();
        public IReadOnlyList<City> Cities => CitiesPrivate.ToList().AsReadOnly();
        public void AddCity(City city)
        {
            if (CitiesPrivate.Add(city) == false)
                throw new DomainException("The list of cities must be unique");
            if (CitiesPrivate.Sum(x => x.Population) > Population)
                throw new DomainException("The total population of cities cannot be higher than the population of a country");
        }

        public void AddCities(IEnumerable<City> cities)
        {
            cities ??= new List<City>();
            foreach (var city in cities)
                AddCity(city);
        }

        private HashSet<City> CapitalsPrivate { get; set; } = new HashSet<City>();
        public void AddCapital(City capital)
        {
            if (CapitalsPrivate.Add(capital) == false)
                throw new DomainException("The list of capitals must be unique");
            else
                CitiesPrivate.Add(capital);
        }

        public void AddCapitals(IEnumerable<City> capitals)
        {
            capitals ??= new List<City>();
            foreach (var capital in capitals)
                AddCapital(capital);
        }
        public IReadOnlyList<City> Capitals => CapitalsPrivate.ToList().AsReadOnly();
        private HashSet<River> RiversPrivate { get; set; } = new HashSet<River>();
        public void AddRiver(River river)
        {
            if (RiversPrivate.Add(river) == false)
                throw new DomainException("The List of rivers must be unique");
        }
        public void AddRivers(IEnumerable<River> rivers)
        {
            rivers ??= new List<River>();
            foreach (var river in rivers)
                AddRiver(river);
        }
        public IReadOnlyList<River> Rivers => RiversPrivate.ToList().AsReadOnly();

        public override bool Equals(object obj)
        {
            return obj is Country country &&
                   Id == country.Id &&
                   Name == country.Name &&
                   Population == country.Population &&
                   Surface == country.Surface;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Population, Surface);
        }

    }
}
