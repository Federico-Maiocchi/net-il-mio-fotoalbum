using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data
{
    public class PhotoManager
    {
        //prendere tutte le foto 
        public static List<Photo> GetAllPhotos()
        {
            using PhotoContext db = new PhotoContext();

            return db.Photos.ToList();
        }

        //prendere una foto dal suo ID
        public static Photo GetPhotoById(int id)
        {
            using PhotoContext db = new PhotoContext();

            return db.Photos.FirstOrDefault(p => p.Id == id);
        }


        //Seeder
        public static void Seed()
        {
            using PhotoContext db = new PhotoContext();

            List<Photo> photos = new List<Photo>()
            {
                new Photo{Title = "Il lago", Description = "Foto di un lago", IsVisible = true  },
                new Photo{Title = "Bosco", Description = "Foto di un lago", IsVisible = true  },
                new Photo{Title = "Mare ", Description = "Foto di un lago", IsVisible = true  }
            };

            db.Photos.AddRange(photos);
            db.SaveChanges();
        }

    }
}
