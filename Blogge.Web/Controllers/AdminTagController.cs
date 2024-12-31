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
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };
            await bloggieDbContext.Tags.AddAsync(tag);
            await bloggieDbContext.SaveChangesAsync();
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
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //var tags = bloggieDbContext.Tags.Find(id);
            var tag = bloggieDbContext.Tags.FirstOrDefault(x => x.Id == id);
            if (tag != null) {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,
                };
                return View(editTagRequest);
            }
            return View(null);
        }
        [HttpPost]
        public IActionResult Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName,
            };
            var existingTag = bloggieDbContext.Tags.Find(tag.Id);
            if (existingTag != null) {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;
                bloggieDbContext.SaveChanges();
                return RedirectToAction("ListDataTag");
            }
            return RedirectToAction("Edit", new {id = editTagRequest.Id});

        }
        [HttpPost]
        public IActionResult Delete(EditTagRequest editTagRequest) 
        {
            var tag = bloggieDbContext.Tags.Find(editTagRequest.Id);
            if (tag != null) {
                bloggieDbContext.Tags.Remove(tag);
                bloggieDbContext.SaveChanges();
                return RedirectToAction("ListDataTag");
            }
            return RedirectToAction("Edit", new {id = editTagRequest.Id});
        }

            
    }
}
