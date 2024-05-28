using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class CategoryController : Controller
    {
        //Index
        public IActionResult IndexCategory()
        {
            //PhotoManager.SeedCategories();

            var categories = PhotoManager.GetAllCategories();

            return View(categories);
        }


        //Create
        //get
        [HttpGet]
        public IActionResult CreateCategory()
        {
            Category category = new Category();

            return View(category);

        }


        //Create
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreateCategory(Category category) 
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCategory",category);
            }

            PhotoManager.AddNewCategory(category);
            return RedirectToAction("IndexCategory");
        }


        // Update
        // get
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = PhotoManager.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Update
        // post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            PhotoManager.UpdateCategory(category.Id, category.Name);
            return RedirectToAction("IndexCategory");
        }


        //Delete
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)                        
        {
            var categoryToDelete = PhotoManager.DeleteCategory(id);

            if (categoryToDelete != null)
            {
                return RedirectToAction("IndexCategory");

            }
            else
            {
                return NotFound();
            }
        }
    }

    

}
