using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotoController : Controller
    {
        //Index
        public IActionResult IndexPhoto()
        {
            //PhotoManager.Seed();
            return View(PhotoManager.GetAllPhotos());
        }

        //Show
        public IActionResult Show(int id)
        {
            var photo = PhotoManager.GetPhotoById(id, true);
            if (photo != null)
            {
                return View(photo);
            }
            else
            {
                return NotFound();
            }
        }

        //Create
        //get
        [HttpGet]
        public IActionResult Create() 
        {
            PhotoFormModel model = new PhotoFormModel();
            model.Photo = new Photo();
            model.CreateCategories(PhotoManager.GetAllCategories());

            return View(model);
        }



        //Create
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(PhotoFormModel data)
        {
            if (!ModelState.IsValid)
            {
                
                data.CreateCategories(PhotoManager.GetAllCategories());

                return View("Create", data);
            }

            data.SetImageFileFromFormFile();

            PhotoManager.AddNewPhoto(data.Photo, data.SelectedCategories);
            return RedirectToAction("IndexPhoto");
        }

        //Update
        //get
        [HttpGet]
        public IActionResult Update(int id)
        {
            Photo photoToEdit = PhotoManager.GetPhotoById(id);

            if (photoToEdit == null)
            {
                return NotFound();
            }
            else
            {
                PhotoFormModel model = new PhotoFormModel();
                model.Photo = photoToEdit;
                model.CreateCategories(PhotoManager.GetAllCategories());

                return View(model);
            }

        }

        //Update
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PhotoFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.CreateCategories(PhotoManager.GetAllCategories());

                return View("Update", data);
            }

            var imageFile = data.SetImageFileFromFormFile();

            if (PhotoManager.UpdatePhoto(id, data.Photo.Title, data.Photo.Description, data.Photo.IsVisible, data.SelectedCategories, imageFile))
            {
                return RedirectToAction("IndexPhoto");
            }
            else
            {
                return NotFound();
            }
        }

        //Delete
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {
            var photoToDelete = PhotoManager.DeletePhoto(id);

            if (photoToDelete != null)
            {
                return RedirectToAction("IndexPhoto");

            }
            else
            {
                return NotFound();
            }
        }

    }
}
