﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Web.Services;

namespace Sprotify.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly AlbumService _service;

        public AlbumsController(AlbumService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _service.GetAlbums();
            return View(albums);
        }
    }
}