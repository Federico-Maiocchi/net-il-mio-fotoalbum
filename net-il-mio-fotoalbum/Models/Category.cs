using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column("category_name")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può avere più di 50 caratteri")]
        public string Name { get; set; }

        public List<Photo>? Photos { get; set; }

        //costruttore - vuoto
        public Category() { }

        public Category(string name)
        {
            Name = name;
        }

    }
}
