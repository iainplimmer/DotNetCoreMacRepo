using Microsoft.AspNetCore.Mvc;

namespace IainPlimmerApi.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}