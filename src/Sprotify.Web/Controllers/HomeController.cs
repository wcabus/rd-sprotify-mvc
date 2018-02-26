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

        public HomeController(SubscriptionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var subscriptions = await _service.GetSubscriptions();
            return View(subscriptions.OrderBy(x => x.PricePerMonth));
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
