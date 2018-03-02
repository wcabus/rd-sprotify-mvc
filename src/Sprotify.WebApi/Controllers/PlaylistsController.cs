using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Domain.Services;
using Sprotify.WebApi.Models.Playlists;

namespace Sprotify.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class PlaylistsController : Controller
    {
        private readonly IPlaylistService _service;

        public PlaylistsController(IPlaylistService service)
        {
            _service = service;
        }

        [HttpGet("/users/{userId:guid}/playlists")]
        public async Task<IActionResult> GetPlaylistsForUser(Guid userId)
        {
            // TODO NotFound

            var currentUserId = Guid.Parse(
                User.FindFirst("sub").Value);

            var isCurrentUser = (currentUserId == userId);

            var playlists = await
                _service.GetPlaylistsForUser(userId, isCurrentUser);

            return Ok(Mapper.Map<IEnumerable<Playlist>>(playlists));
        }
    }
}