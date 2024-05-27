using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;
using System.Security.Claims;

namespace net_il_mio_fotoalbum.Data
{
    public class PhotoManager
    {

        //FOTO
        //prendere tutte le foto 
        public static List<Photo> GetAllPhotos()
        {
            using PhotoContext db = new PhotoContext();

            return db.Photos.ToList();
        }

        //prendere una foto dal suo ID
        public static Photo GetPhotoById(int id, bool includesReferences = true)
        {
            using PhotoContext db = new PhotoContext();

            if (includesReferences )
            {
                return db.Photos.Where(photo => photo.Id == id).Include(photo => photo.Categories).FirstOrDefault();
            }
            else
            {
                return db.Photos.FirstOrDefault(photo => photo.Id == id);
            }

           
        }

        //aggiungere una nuova foto
        public static void AddNewPhoto(Photo photo, List<string> SelectedCategories = null) 
        {
            using PhotoContext db = new PhotoContext();

            if (SelectedCategories != null)
            {
                photo.Categories = new List<Category>();

                foreach (var categoryId in SelectedCategories)
                {
                    int idInt = int.Parse(categoryId);
                    var category = db.Categories.FirstOrDefault(category => category.Id ==  idInt);
                    photo.Categories.Add(category);
                }
            }
           
            db.Photos.Add(photo);
            db.SaveChanges();
        }

        //modificare una immagine 
        //public static bool UpdatePhoto(int id, string title, string description, string? image, bool visibility, List<string> categories)
        public static bool UpdatePhoto(int id, string title, string description, bool visibility, List<string> categories, byte[]? imageFile)
        {
            using PhotoContext db = new PhotoContext();

            var photo = db.Photos.Where(photo => photo.Id == id).Include(photo => photo.Categories).FirstOrDefault();

            if (photo == null)
            {
                return false;
            }

            photo.Title = title;
            photo.Description = description;
            //photo.ImgSrc = image;
            photo.IsVisible = visibility;

            if (imageFile != null)
            {
                photo.ImageFile = imageFile;
            }

            photo.Categories.Clear();
            if (categories != null)
            {
                foreach (var category in categories)
                {
                    int categoryId = int.Parse(category);
                    var categoryFromDb = db.Categories.FirstOrDefault(category => category.Id == categoryId);
                    photo.Categories.Add(categoryFromDb);
                }
            }

            db.SaveChanges();

            return true;
        }

        //Elimina foto
        public static bool DeletePhoto(int id)
        {
            try
            {
                var idPhotoDelete = GetPhotoById(id, false);
                if (idPhotoDelete == null)
                {
                    return false;
                }
                else
                {
                    using PhotoContext db = new PhotoContext();
                    db.Remove(idPhotoDelete);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //CATEGORIE

        //prendere tutte le catergorie
        public static List<Category> GetAllCategories()
        {
            using PhotoContext db = new PhotoContext();

            return db.Categories.ToList();
        }

        //prendere la categoria in base al suo ID
        public static Category GetCategoryById(int id)
        {
            using PhotoContext db = new PhotoContext();

            return db.Categories.FirstOrDefault(category => category.Id == id);
        }

        //Aggiungere una nuova categoria
        public static bool AddNewCategory(Category category)
        {


            try
            {
                using PhotoContext db = new PhotoContext();

                db.Categories.Add(category);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

           
        }

        //modificare una categoria

        public static bool UpdateCategory(int id, string name)
        {

            try
            {
                using PhotoContext db = new PhotoContext();

                var category = db.Categories.FirstOrDefault(category => category.Id == id);

                category.Name = name;

                db.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //Eliman categoria

        public static bool DeleteCategory(int id)
        {
            try
            {
                using PhotoContext db = new PhotoContext();

                var IdCategoryDelete = GetCategoryById(id);

                db.Categories.Remove(IdCategoryDelete);
                db.SaveChanges();


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        //Seed foto
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

        //Seed categorie
        public static void SeedCategories()
        {
            using PhotoContext db = new PhotoContext();

            List<Category> categories = new List<Category>()
            {
                new Category{Name = "Pesaggio"},
                new Category{Name = "Famiglia"},
                new Category{Name = "Mare"},
                new Category{Name = "Montaglia"},
                new Category{Name = "Videogiochi"},
                new Category{Name = "Cibo"},
            };

            db.Categories.AddRange(categories);
            db.SaveChanges();
        }  


        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
