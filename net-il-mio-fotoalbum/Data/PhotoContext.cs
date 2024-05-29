using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data
{
    public class PhotoContext : IdentityDbContext<IdentityUser>
    {
        //Foto
        public DbSet<Photo> Photos { get; set; }

        //Categorie
        public DbSet<Category> Categories { get; set; }

        //Messaggi
        public DbSet<Message> Messages { get; set; }

        //Profili
        public DbSet<Profile> Profiles { get; set; }

        public object PhotoContexts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=DbPhotos;");
        }
    }
}
