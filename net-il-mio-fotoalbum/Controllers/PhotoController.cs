using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;

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
            var photo = PhotoManager.GetPhotoById(id);
            if (photo != null)
            {
                return View(photo);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
