using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Domain.Repositories;
using Sprotify.WebApi.Models.Albums;

namespace Sprotify.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class AlbumsController : Controller
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumsController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAlbums(
            [FromQuery]bool includeSongs = false)
        {
            if (includeSongs)
            {
                var albums2 = await _albumRepository.GetAlbumsWithBandsAndSongs();
                var mappedAlbums2 = Mapper.Map<IEnumerable<AlbumWithBandAndSongs>>(albums2);
            
                return Ok(mappedAlbums2);
            }

            var albums = await _albumRepository.GetAlbumsWithBands();
            var mappedAlbums = Mapper.Map<IEnumerable<AlbumWithBand>>(albums);
            
            return Ok(mappedAlbums);
        }
    }
}