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
        private readonly AlbumService _albumService;

        public HomeController(SubscriptionService service, AlbumService albumService)
        {
            _service = service;
            _albumService = albumService;
        }

        public async Task<IActionResult> Index()
        {
            var subscriptions = await _service.GetSubscriptions();
            return View(subscriptions.OrderBy(x => x.PricePerMonth));
        }

        public async Task<IActionResult> About()
        {
            var albums = await _albumService.GetAlbumsWithSongs();
            return View(albums);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
