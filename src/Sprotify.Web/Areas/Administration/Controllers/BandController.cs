using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Web.Models;
using Sprotify.Web.Services;

namespace Sprotify.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "admin")]
    public class BandController : Controller
    {
        private readonly BandService _service;

        public BandController(BandService service)
        {
            _service = service;
        }

        // GET: Band
        public async Task<ActionResult> Index()
        {
            return View(await _service.GetBands());
        }

        // GET: Band/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var band = await _service.GetBandById(id);
            if (band == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var albums = await _service.GetAlbumsForBand(id);

            ViewBag.Band = band;
            return View(albums);
        }

        // GET: Band/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Band/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Band model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _service.CreateBand(model.Name);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Band/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var band = await _service.GetBandById(id);
            if (band == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(band);
        }

        // POST: Band/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Band model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _service.UpdateBand(id, model.Name);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
        }

        // GET: Band/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Band/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}