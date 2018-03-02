using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Domain.Services;
using Sprotify.WebApi.Models.Playlists;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Sprotify.WebApi.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("[controller]")]
    public class PlaylistsController : Controller
    {
        private readonly IPlaylistService _service;

        public PlaylistsController(IPlaylistService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaylists()
        {
            // retrieve all public playlists AND your private playlists
            var playlists = await _service.GetPlaylists(GetCurrentUserId());
            return Ok(Mapper.Map<IEnumerable<Playlist>>(playlists));
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> of <see cref="Playlist"/> for the user
        /// identified by <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        [HttpGet("/users/{userId:guid}/playlists")]
        [SwaggerResponse(200, typeof(IEnumerable<Playlist>))]
        [SwaggerResponse(404, description:"User not found")]
        public async Task<IActionResult> GetPlaylistsForUser(Guid userId)
        {
            // TODO NotFound

            Guid currentUserId = GetCurrentUserId();

            var isCurrentUser = (currentUserId == userId);

            var playlists = await
                _service.GetPlaylistsForUser(userId, isCurrentUser);

            return Ok(Mapper.Map<IEnumerable<Playlist>>(playlists));
        }

        private Guid GetCurrentUserId()
        {
            return Guid.Parse(User.FindFirst("sub").Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist([FromBody]PlaylistToCreate model)
        {
            // TODO !ModelState.IsValid => BadRequest

            var playlist = await _service.CreatePlaylist(GetCurrentUserId(),
                model.Title, model.IsPrivate, model.IsCollaborative);

            // TODO CreatedAtRoute
            return Ok(Mapper.Map<Playlist>(playlist));
        }
    }
}