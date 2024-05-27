using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace net_il_mio_fotoalbum.Models
{
    [Table("Photo")]

    [Index(nameof(Title), IsUnique = true)]
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Column("photo_title")]
        public string Title { get; set; }

        [Column("photo_description")]
        public string Description { get; set; }

        public byte[]? ImageFile { get; set; }

        public string ImgSrc => ImageFile != null ? $"data:image/png;base64,{Convert.ToBase64String(ImageFile)}" : "";

        public bool IsVisible { get; set; } = true;

        //relazione N : N con CATEGORY
        public List<Category>? Categories { get; set; }

        //costruttore - vuoto
        public Photo() { }  

        public Photo(string title, string description, bool visible ) 
        {
            Title = title;  
            Description = description;
            IsVisible = visible;
            
        }


    }
}
