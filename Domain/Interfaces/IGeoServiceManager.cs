using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IGeoServiceManager
    {
        //void AddContinent(Continent continent);
        //void UpdateContinent(Continent continent);
        //void RemoveContinent(Continent continent);
        void AddRiver(River river);
        void UpdateRiver(River river);
        void RemoveRiver(River river);
        void AddCity(City city);
        void UpdateCity(City city);
        void RemoveCity(City city);
        void AddCountry(Country country);
        void UpdateCountry(Country country);
        void RemoveCountry(Country country);
    }
}
