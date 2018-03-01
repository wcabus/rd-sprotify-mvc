using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Domain.Services;
using Sprotify.WebApi.Models.Albums;

namespace Sprotify.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [Authorize]
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _service;

        public AlbumsController(IAlbumService service)
        {
            _service = service;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAlbums([FromQuery]string filter = null) 
        {
            var albums = await _service.GetAlbums(filter);
	        return Ok(Mapper.Map<IEnumerable<Album>>(albums));
        }

        [HttpGet("{id:guid}", Name = nameof(GetAlbumById))]
        public async Task<IActionResult> GetAlbumById(Guid id, 
            [FromQuery]bool includeSongs = false)
        {
            if (!await _service.AlbumExists(id))
            {
                return NotFound();
            }

            var album = await _service.GetAlbumById(id, includeSongs);

            // TODO Refactor: includeSongs == true => Map to album with songs
            return Ok(Mapper.Map<Album>(album));
        }

        [HttpGet("/bands/{bandId:guid}/albums")]
        public async Task<IActionResult> GetAlbumsForBand(Guid bandId)
        {
            if (!await _service.BandExists(bandId))
            {
                return NotFound();
            }

            var albums = await _service.GetAlbumsForBand(bandId);
            return Ok(Mapper.Map<IEnumerable<Album>>(albums));
        }

        [HttpGet("/bands/{bandId:guid}/albums/{id:guid}", Name = nameof(GetAlbumForBandById))]
        public async Task<IActionResult> GetAlbumForBandById(
            Guid bandId, 
            Guid id, 
            [FromQuery]bool includeSongs = false)
        {
            if (!await _service.BandExists(bandId))
            {
                return NotFound();
            }

            var album = await _service.GetAlbumById(id, includeSongs);
            if (album == null)
            {
                return NotFound();
            }

            // TODO Refactor: includeSongs == true => Map to album with songs
            return Ok(Mapper.Map<Album>(album));
        }

        [HttpPost("/bands/{bandId:guid}/albums")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateAlbumForBand
            (Guid bandId, [FromBody] AlbumToCreate model)
        {
            if (!await _service.BandExists(bandId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var album =
            await _service.CreateAlbum(bandId,
                model.Title, model.ReleaseDate, model.Art);

            //return CreatedAtRoute(nameof(GetAlbumById),
            //    new { album.Id },
            //    Mapper.Map<Album>(album));

            return CreatedAtRoute(nameof(GetAlbumForBandById),
                new { BandId = bandId, Id = album.Id },
                Mapper.Map<Album>(album));
        }
    }
}