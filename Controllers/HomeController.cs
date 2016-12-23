using Microsoft.AspNetCore.Mvc;

namespace IainPlimmerApi.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}