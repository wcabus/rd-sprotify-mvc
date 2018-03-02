using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Domain.Services;
using Sprotify.WebApi.Models;
using Sprotify.WebApi.Models.Songs;

namespace Sprotify.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [Authorize]
    public class SongsController : Controller
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery]string filter = null)
        {
            var songs = await _songService.GetSongs(filter);
            return Ok(Mapper.Map<IEnumerable<Song>>(songs));
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromQuery]string filter = null)
        {
            var songs = await _songService.GetSongs(filter);
            return Ok(Mapper.Map<IEnumerable<SearchItem>>(songs));
        }
    }
}