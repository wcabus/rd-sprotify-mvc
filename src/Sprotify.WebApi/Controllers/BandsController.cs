using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sprotify.Domain.Services;
using AutoMapper;
using Sprotify.WebApi.Models.Bands;

namespace Sprotify.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [Authorize]
    public class BandsController : Controller
    {
        private readonly IBandService _bandService;

        public BandsController(IBandService bandService)
        {
            _bandService = bandService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetBands([FromQuery]string filter = null)
        {
            return Ok(
                Mapper.Map<IEnumerable<Band>>(
                    await _bandService.GetBands(filter)));
        }

        [HttpGet("{id:guid}", Name = nameof(GetBandById)), AllowAnonymous]
        public async Task<IActionResult> GetBandById(Guid id)
        {
            var band = await _bandService.GetBandById(id);
            if (band == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Band>(band));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateBand([FromBody] BandToCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var band = await _bandService.CreateBand(model.Name);

            return CreatedAtRoute(nameof(GetBandById),
                new { band.Id },
                Mapper.Map<Band>(band));
        }
    }
}