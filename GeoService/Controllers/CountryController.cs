using Domain.Interfaces;
using Domain.Models;
using GeoService.Models.Exit;
using GeoService.Models.In;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Controllers
{
    [Route("api/continent/{continentId}/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private IGeoServiceManager _geoServiceManager;
        private string _hostUrl;
        public CountryController(IGeoServiceManager geoServiceManager, IConfiguration configuration)
        {
            _geoServiceManager = geoServiceManager;
            _hostUrl = configuration.GetValue<string>("profiles:GeoService:applicationUrl");
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CountryApiOut> GetCountry(int continentId, int id)
        {
            try
            {
                Country country = _geoServiceManager.GetCountry(id);

                if (country.Continent.Id != continentId)
                    return BadRequest($"The continentId in the url does not match the id in the country. url: {continentId}, country: {country.Continent.Id}");

                CountryApiOut countryApiOut = Mapper.DomainToApi(country, _hostUrl);
                return Ok(countryApiOut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<CountryApiOut> PostCountry(int continentId, [FromBody] CountryApiIn countryApiIn)
        {
            try
            {
                if (continentId != countryApiIn.ContinentId)
                    return BadRequest($"The continentId in the url does not match the id in the country. url: {continentId}, country: {countryApiIn.ContinentId}");

                Country country = Mapper.ApiToDomain(countryApiIn);
                
                Continent continent = _geoServiceManager.GetContinent(continentId);
                country.Continent = continent;
                continent.AddCountry(country);

                IEnumerable<River> rivers = countryApiIn.RiverIds.Select(x => _geoServiceManager.GetRiver(x));
                country.AddRivers(rivers);

                CountryApiOut countryApiOut = Mapper.DomainToApi(country, _hostUrl);
                return CreatedAtAction(nameof(PostCountry), countryApiOut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<CountryApiOut> PutCountry(int continentId, int id, [FromBody] CountryApiIn countryApiIn)
        {
            try
            {
                if (continentId != countryApiIn.ContinentId)
                    return BadRequest($"The continentId in the url does not match the id in the country. url: {continentId}, country: {countryApiIn.ContinentId}");
                if (id != countryApiIn.Id)
                    return BadRequest($"The Id in the url does not match the id in the country. url: {id}, country: {countryApiIn.Id}");

                //Country country = _geoServiceManager.GetCountry(id);
                //Country country = Mapper.ApiToDomain(countryApiIn);

                //Continent continent = _geoServiceManager.GetContinent(continentId);
                //continent.AddCountry(country);

                //IEnumerable<River> rivers = countryApiIn.RiverIds.Select(x => _geoServiceManager.GetRiver(x));
                //country.UpdateRivers(rivers);

                //_geoServiceManager.UpdateCountry(country);
                //CountryApiOut countryApiOut = Mapper.DomainToApi(country, _hostUrl);

                Country PutCountry = Mapper.ApiToDomain(countryApiIn);
                Country DataCountry = _geoServiceManager.GetCountry(id);

                DataCountry.Name = PutCountry.Name;
                DataCountry.Population = PutCountry.Population;
                DataCountry.Surface = PutCountry.Surface;

                IEnumerable<River> rivers = countryApiIn.RiverIds.Select(x => _geoServiceManager.GetRiver(x));
                DataCountry.UpdateRivers(rivers);

                Continent continent = _geoServiceManager.GetContinent(continentId);
                DataCountry.Continent = continent;
                //continent.UpdateCountry(DataCountry);

                _geoServiceManager.UpdateCountry(DataCountry);
                CountryApiOut countryApiOut = Mapper.DomainToApi(_geoServiceManager.GetCountry(id), _hostUrl);
                return CreatedAtAction(nameof(PutCountry), countryApiOut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
