namespace WebUi.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;
    using Ports;

    [Route("")]
    public class HomeController : Controller
    {
        readonly IProvideServiceLocations serviceLocationsProvider;

        public HomeController(IProvideServiceLocations serviceLocationsProvider)
        {
            this.serviceLocationsProvider = serviceLocationsProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await BindServiceLocations();

            return View();
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ErrorViewModel response = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(response);
        }

        async Task BindServiceLocations()
        {
            string[] serviceLocations =
                await serviceLocationsProvider.GetServiceLocationsAsync();

            ViewBag.ServiceLocations = serviceLocations
                .Select(x => new SelectListItem(x, x))
                .ToList();
        }
    }
}