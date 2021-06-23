using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using GeoService.Models.In;
using GeoService.Models.Out;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {
        private IGeoServiceManager _geoServiceManager;
        public ContinentController(IGeoServiceManager geoServiceManager)
        {
            _geoServiceManager = geoServiceManager;
        }
        
        [HttpPost]
        public ActionResult<ContinentApiOut> PostContinent([FromBody] ContinentApiIn continentApiIn)
        {
            try
            {
                Continent continent = Mapper.ApiToDomain(continentApiIn);
                _geoServiceManager.AddContinent(continent);
                ContinentApiOut continentApiOut = Mapper.DomainToApi(_geoServiceManager.GetContinent(continentApiIn.Id));
                
                return CreatedAtAction(nameof(PostContinent), continentApiOut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ContinentApiOut> GetContinent(int id)
        {
            try
            {
                ContinentApiOut continentApiOut = Mapper.DomainToApi(_geoServiceManager.GetContinent(id));
                return Ok(continentApiOut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<ContinentApiOut> PutContinent(int id, [FromBody] ContinentApiIn continentApiIn)
        {
            try
            {
                if (id != continentApiIn.Id)
                    return BadRequest("The id's do not match.");

                Continent continent = Mapper.ApiToDomain(continentApiIn);
                _geoServiceManager.UpdateContinent(continent);

                return CreatedAtAction(nameof(PutContinent), _geoServiceManager.GetContinent(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ContinentApiOut> DeleteContinent(int id)
        {
            try
            {
                Continent continent = _geoServiceManager.GetContinent(id);
                _geoServiceManager.RemoveContinent(continent);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
