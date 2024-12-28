using Blogge.Web.Data;
using Blogge.Web.Models.Domain;
using Blogge.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blogge.Web.Controllers
{
    public class AdminTagController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;

        public AdminTagController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };
            bloggieDbContext.Tags.Add(tag);
            bloggieDbContext.SaveChanges();
            return RedirectToAction("ListDataTag");
        }
        [HttpGet]
        public IActionResult List() 
        {
            var tags = bloggieDbContext.Tags.ToList();
            return View("List", tags);
        }
        [HttpGet]
        [ActionName("ListDataTag")]
        public IActionResult ListDataTag()
        {
            var tags = bloggieDbContext.Tags.ToList();
            return View(tags);
        }

        [HttpGet]
        public IActionResult TestAjah()
        {
            return View();
        }


    }
}
