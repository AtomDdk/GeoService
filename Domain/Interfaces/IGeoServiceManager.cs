using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IGeoServiceManager
    {
        void AddContinent(Continent continent);
        void UpdateContinent(Continent continent);
        void RemoveContinent(Continent continent);
        Continent GetContinent(string name);
        void AddRiver(River river);
        void UpdateRiver(River river);
        void RemoveRiver(River river);
        River GetRiver(string name);
        void AddCity(City city);
        void UpdateCity(City city);
        void RemoveCity(City city);
        City GetCity(string name);
        void AddCountry(Country country);
        void UpdateCountry(Country country);
        void RemoveCountry(Country country);
        Country GetCountry(string name);
    }
}
