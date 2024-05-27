using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult IndexPhoto()
        {
            //PhotoManager.Seed();
            return View(PhotoManager.GetAllPhotos());
        }
    }
}
