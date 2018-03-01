using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Web.Models;
using Sprotify.Web.Services;

namespace Sprotify.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SubscriptionService _service;
        private readonly UserService _userService;
        private readonly SongService _songService;
        private readonly AlbumService _albumService;

        public HomeController(
            SubscriptionService service, 
            UserService userService, 
            SongService songService,
            AlbumService albumService)
        {
            _service = service;
            _userService = userService;
            _songService = songService;
            _albumService = albumService;
        }

        public async Task<IActionResult> Index()
        {
            var subscriptions = await _service.GetSubscriptions();
            return View(subscriptions.OrderBy(x => x.PricePerMonth));
        }

        public async Task<IActionResult> Albums()
        {
            var albums = await _albumService.GetAlbums();
            return View(albums);
        }

        public async Task<IActionResult> About()
        {
            var songs = await _songService.GetAllSongs();
            return View(songs.OrderBy(x => x.Band).ThenBy(x => x.Album).ThenBy(x => x.Position));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
