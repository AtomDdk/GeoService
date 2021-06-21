using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Domain.Models
{
    public class City 
    {
        public City() { }
        public City(int id, string name, long population, Country country)
        {
            Id = id;
            Name = name;
            Population = population;
            Country = country;
        }
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) == false ? _name = value : throw new CityException("The City must have a name");
        }
        public long Population { get; set; }
        private Country _country;
        public Country Country
        {
            get => _country;
            set => _country = value ?? throw new CityException("A City must be part of a Country");
        }

        public override bool Equals(object obj)
        {
            return obj is City city &&
                   Id == city.Id &&
                   Name == city.Name &&
                   Population == city.Population &&
                   EqualityComparer<Country>.Default.Equals(Country, city.Country);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Population, Country);
        }
    }
}
