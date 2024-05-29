using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;
using System.Security.Claims;

namespace net_il_mio_fotoalbum.Controllers
{
    [Authorize]
    public class PhotoController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        //Index
        public IActionResult IndexPhoto(string filterName)
        {
            List<Photo> photos;

           // PhotoManager.Seed();

            if (!string.IsNullOrEmpty(filterName))
            {
                return View(PhotoManager.GetPhotoByName(filterName));
            }
            else
            {
                return View(PhotoManager.GetAllPhotos());
            }

           
            //return View(PhotoManager.GetAllPhotos());
        }

        [Authorize(Roles = "ADMIN")]
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
        [Authorize(Roles = "ADMIN")]
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
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(PhotoFormModel data)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Profile profile = PhotoManager.GetProfileByUserId(userId);
            data.Photo.ProfileId = profile.ProfileId;

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
        [Authorize(Roles = "ADMIN")]
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
        [Authorize(Roles = "ADMIN")]
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
        [Authorize(Roles = "ADMIN")]
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
