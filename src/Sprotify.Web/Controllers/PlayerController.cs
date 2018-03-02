using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Web.Models.Player;
using Sprotify.Web.Services;

namespace Sprotify.Web.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly PlayerService _service;

        public PlayerController(PlayerService service)
        {
            _service = service;
        }

        [Route("/webplayer")]
        public async Task<IActionResult> Index()
        {
            return View(new List<Playlist>());
        }

        [Route("/my/playlists")]
        public async Task<IActionResult> Playlists()
        {
            return View(new List<Playlist>());
        }

        [Route("/search")]
        public async Task<IActionResult> Search()
        {
            return View();
        }



        [HttpPost]
        [Route("/search")]
        public async Task<IActionResult> Search([FromForm]string filter)
        {
            var results = await _service.Search(filter);
            return View(results);
        }
    }
}