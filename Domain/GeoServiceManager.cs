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
                if (_unitOfWork.CityRepo.Exists(city.Name))
                    throw new DomainException("This city already exists");
                _unitOfWork.CityRepo.Add(city);
                _unitOfWork.Complete();
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
                    throw new DomainException("This continent already exists");
                _unitOfWork.ContinentRepo.Add(continent);
                _unitOfWork.Complete();
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
                if (_unitOfWork.CountryRepo.Exists(country.Name))
                    throw new DomainException("This country already exists");
                _unitOfWork.CountryRepo.Add(country);
                _unitOfWork.Complete();
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
                if (_unitOfWork.RiverRepo.Exists(river.Name))
                    throw new DomainException("This river already exists");
                _unitOfWork.RiverRepo.Add(river);
                _unitOfWork.Complete();
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
                if (!_unitOfWork.CityRepo.Exists(name))
                    throw new DomainException("The city does not exist.");
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
                if (!_unitOfWork.ContinentRepo.Exists(name))
                    throw new DomainException("The continent does not exist.");
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
                if (!_unitOfWork.CountryRepo.Exists(name))
                    throw new DomainException("The country does not exist.");
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
                if (!_unitOfWork.RiverRepo.Exists(name))
                    throw new DomainException("The river does not exist.");
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
                if (!_unitOfWork.CityRepo.Exists(city.Name))
                    throw new DomainException("The city cannot be removed because it does not exist.");
                _unitOfWork.CityRepo.Remove(city);
                _unitOfWork.Complete();
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
                    throw new DomainException("A continent cannot be removed whilst it still has countries.");
                if (!_unitOfWork.ContinentRepo.Exists(continent.Name))
                    throw new DomainException("The continent cannot be removed because it does not exist.");
                _unitOfWork.ContinentRepo.Remove(continent);
                _unitOfWork.Complete();
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
                    throw new DomainException("A country cannot be removed whilst it still has cities.");
                if (!_unitOfWork.CountryRepo.Exists(country.Name))
                    throw new DomainException("The country cannot be removed because it does not exist.");
                _unitOfWork.CountryRepo.Remove(country);
                _unitOfWork.Complete();
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
                if (!_unitOfWork.RiverRepo.Exists(river.Name))
                    throw new DomainException("The river cannot be removed because it does not exist.");
                _unitOfWork.RiverRepo.Remove(river);
                _unitOfWork.Complete();
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
                _unitOfWork.Complete();
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
                _unitOfWork.Complete();
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
                _unitOfWork.Complete();
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
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
