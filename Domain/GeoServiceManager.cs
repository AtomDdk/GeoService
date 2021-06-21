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

        public void AddCountry(Country country)
        {
            throw new NotImplementedException();
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

        public void RemoveCountry(Country country)
        {
            throw new NotImplementedException();
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

        public void UpdateCountry(Country country)
        {
            throw new NotImplementedException();
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
