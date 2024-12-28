using Microsoft.AspNetCore.Mvc;

namespace Blogge.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
