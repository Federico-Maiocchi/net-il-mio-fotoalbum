using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column("category_name")]
        public string Name { get; set; }

        public List<Photo> Photos { get; set; }

        //costruttore - vuoto
        public Category() { }

    }
}
