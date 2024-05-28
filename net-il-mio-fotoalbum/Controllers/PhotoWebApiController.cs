using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotoWebApiController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetAllPhotos(string? filterName )
        {
            List<Photo> photos;

            if (!string.IsNullOrEmpty(filterName))
            {
                photos = PhotoManager.GetPhotoByName(filterName);
            }
            else
            {
                photos = PhotoManager.GetAllPhotos();
            }

            return Ok(photos);
        }

        
    }
}
