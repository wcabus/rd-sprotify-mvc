using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Web.Models.Player;

namespace Sprotify.Web.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        [Route("/webplayer")]
        public async Task<IActionResult> Index()
        {
            return View(new List<Playlist>());
        }
    }
}