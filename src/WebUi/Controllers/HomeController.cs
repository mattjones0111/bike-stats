namespace WebUi.Controllers
{
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
        readonly IGetTheftCounts theftCountProvider;

        public HomeController(
            IProvideServiceLocations serviceLocationsProvider,
            IGetTheftCounts theftCountProvider)
        {
            this.serviceLocationsProvider = serviceLocationsProvider;
            this.theftCountProvider = theftCountProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string location = null)
        {
            await BindServiceLocations();

            IndexPageModel model = new IndexPageModel();

            if (string.IsNullOrWhiteSpace(location))
            {
                return View(model);
            }

            model.SelectedLocation = location;
            model.TheftCount = await theftCountProvider.GetTheftCountAsync(location);

            return View(model);
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
