using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Country> countriesList = new List<Country>();
            Continent continent = new Continent(1, "Europe", new List<Country>());
            Country country = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            Country country1 = new Country(1, "Belgium", 100, 200, continent, new List<City>(), new List<City>(), new List<River>());
            HashSet<Country> countries = new HashSet<Country>();

            Console.WriteLine(countries.Add(country) == true);
            Console.WriteLine(countries.Add(country) == false);
            Console.WriteLine(countries.Add(country1) == false);
            Console.WriteLine(country.Equals(country1));
            Console.WriteLine(countries.Count());
            Console.WriteLine("----");

            countriesList.AddRange(new List<Country> { country, country1 });
            Console.WriteLine(countriesList.ToHashSet().Count == 1);

            //Console.WriteLine(country.Equals(country));
            //Console.WriteLine(country == country);


            //City city = new City(1, "Wetteren", 100, new Country());
            //City city1 = new City(1, "Wetteren", 100, new Country());

            //HashSet<City> cities = new HashSet<City>();
            //Console.WriteLine("----");

            //Console.WriteLine(city.Equals(city1) == true);
            //Console.WriteLine("---");
            //Console.WriteLine(cities.Add(city) == true);
            //Console.WriteLine(cities.Add(city) == false);
            //Console.WriteLine(cities.Add(city1) == false);
            //Console.WriteLine(cities.Count);

        }
    }
}
