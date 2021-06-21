using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class GeoServiceManager : IGeoServiceManager
    {
        private IUnitOfWork _unitOfWork;
        public GeoServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddCity(City city)
        {
            try
            {
                _unitOfWork.CityRepo.Add(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddContinent(Continent continent)
        {
            try
            {
                if (_unitOfWork.ContinentRepo.Exists(continent.Name))
                    throw new DomainException("The name of a continent must be unique");
                _unitOfWork.ContinentRepo.Add(continent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddCountry(Country country)
        {
            try
            {
                _unitOfWork.CountryRepo.Add(country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRiver(River river)
        {
            try
            {
                _unitOfWork.RiverRepo.Add(river);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public City GetCity(string name)
        {
            try
            {
                return _unitOfWork.CityRepo.Get(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Continent GetContinent(string name)
        {
            try
            {
                return _unitOfWork.ContinentRepo.Get(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Country GetCountry(string name)
        {
            try
            {
                return _unitOfWork.CountryRepo.Get(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public River GetRiver(string name)
        {
            try
            {
                return _unitOfWork.RiverRepo.Get(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveCity(City city)
        {
            try
            {
                _unitOfWork.CityRepo.Remove(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveContinent(Continent continent)
        {
            try
            {
                if (continent.Countries.Count != 0)
                    throw new DomainException("A continent can only be removed when it no longes has any countries");
                _unitOfWork.ContinentRepo.Remove(continent);
            }
            catch (DomainException domainEx)
            {
                throw domainEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveCountry(Country country)
        {
            try
            {
                if (country.Cities.Count != 0)
                    throw new DomainException("A Country can only be removed when it no longer has any cities.");
                _unitOfWork.CountryRepo.Remove(country);
            }
            catch (DomainException domainEx)
            {
                throw domainEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveRiver(River river)
        {
            try
            {
                _unitOfWork.RiverRepo.Remove(river);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCity(City city)
        {
            try
            {
                _unitOfWork.CityRepo.Update(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateContinent(Continent continent)
        {
            try
            {
                _unitOfWork.ContinentRepo.Update(continent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCountry(Country country)
        {
            try
            {
                _unitOfWork.CountryRepo.Update(country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRiver(River river)
        {
            try
            {
                _unitOfWork.RiverRepo.Update(river);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
