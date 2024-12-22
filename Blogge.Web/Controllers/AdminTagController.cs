using Microsoft.AspNetCore.Mvc;

namespace Blogge.Web.Controllers
{
    public class AdminTagController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

    }
}
