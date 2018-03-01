using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sprotify.Domain.Services;
using Sprotify.WebApi.Models.Songs;

namespace Sprotify.WebApi.Models
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
        public async Task<IActionResult> Get()
        {
            var songs = await _songService.GetSongs();
            return Ok(Mapper.Map<IEnumerable<Song>>(songs));
        }
    }
}