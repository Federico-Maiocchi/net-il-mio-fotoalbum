using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;

namespace net_il_mio_fotoalbum.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotoWebApiController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetAllPhotos()
        {
            return Ok(PhotoManager.GetAllPhotos());
        }
    }
}
