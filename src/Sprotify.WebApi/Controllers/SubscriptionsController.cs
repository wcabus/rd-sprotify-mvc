using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Domain.Services;
using Sprotify.WebApi.Models.Subscriptions;

namespace Sprotify.WebApi.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin")]
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionService _service;

        public SubscriptionsController(ISubscriptionService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSubscriptions()
        {
            var subscriptions = await _service.GetSubscriptions();
            return Ok(Mapper.Map<IEnumerable<Subscription>>(subscriptions));
        }

        [HttpGet("{id:guid}", Name = Routes.GetSubscriptionById)]
        [AllowAnonymous]
        public async Task<IActionResult> GetSubscription(Guid id)
        {
            var subscription = await _service.GetSubscriptionById(id);
            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Subscription>(subscription));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody]SubscriptionToCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscription = await _service.CreateSubscription(model.Title, model.Description, model.PricePerMonth,
                model.HasAdvertisements, model.CanOnlyShuffle, model.CanPlayOffline, model.HasHighQualityStreams);

            return CreatedAtRoute(Routes.GetSubscriptionById, new { id = subscription.Id }, Mapper.Map<Subscription>(subscription));
        }

        private static class Routes
        {
            public const string GetSubscriptionById = nameof(GetSubscriptionById);
        }
    }
}