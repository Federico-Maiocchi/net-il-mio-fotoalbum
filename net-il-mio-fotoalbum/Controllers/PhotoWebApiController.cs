﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;
using System.Reflection.Metadata.Ecma335;

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


        //cambiare la visibilità della foto in indexPhoto
        [HttpPost]
        public IActionResult ToggleVisibility(int id)
        {
            try
            {
                // Chiamata al PhotoManager per cambiare lo stato di visibilità dell'immagine
                var success = PhotoManager.TogglePhotoVisibility(id);

                if (success)
                {
                    return Ok();
                }
                else
                {
                    return NotFound(); // Immagine non trovata
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Gestione degli errori
            }
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] Message message)
        {
            try
            {
                using PhotoContext db = new PhotoContext();

                db.Messages.Add(message);

                db.SaveChanges();

                return Ok("Messaggio ricevuto con successo");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
