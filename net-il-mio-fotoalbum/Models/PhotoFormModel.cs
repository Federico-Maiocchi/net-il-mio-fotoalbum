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
        public List<SelectListItem>? Categories { get; set; }

        //elenco degli ID che appartiene alle categorie
        public List<string>? SelectedCategories { get; set; }

        //Costruttore
        public PhotoFormModel() { }

        public PhotoFormModel(Photo photo, List<SelectListItem>? categories, List<string>? selectedCategories)
        {
            Photo = photo;
            Categories = categories;
            SelectedCategories = selectedCategories;
        }

        public void CreateCategories(List<Category> InputCategories)
        {
            this.Categories = new List<SelectListItem>();
            this.SelectedCategories = new List<string>();

            
            foreach (var category in InputCategories)
            {
                bool isSelected = this.Photo.Categories?.Any(c => c.Id == category.Id) == true;

                this.Categories.Add(new SelectListItem()
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
