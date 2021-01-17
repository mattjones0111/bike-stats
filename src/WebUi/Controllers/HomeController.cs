namespace WebUi.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
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