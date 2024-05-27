using Microsoft.AspNetCore.Mvc.Rendering;
using net_il_mio_fotoalbum.Data;

namespace net_il_mio_fotoalbum.Models
{
    public class PhotoFormModel
    {
        //Foto
        public Photo Photo { get; set; }

        //Categorie
        //elenco categorie selezionabili
        public List<SelectListItem>? Catergories { get; set; }

        //elenco degli ID che appartiene alle categorie
        public List<string>? SelectedCategories { get; set; }

        //Costruttore
        public PhotoFormModel() { }

        public void CreateCategories()
        {
            this.Catergories = new List<SelectListItem>();
            this.SelectedCategories = new List<string>();

            var categoriesFromDb = PhotoManager.GetAllCategories();
            foreach (var category in categoriesFromDb)
            {
                bool isSelected = this.Photo.Categories?.Any(c => c.Id == category.Id) == true;

                this.Catergories.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString(),
                    Selected = isSelected
                });

                if(isSelected)
                {
                    this.SelectedCategories.Add(category.Id.ToString());
                }
            }

        }
    }
}
