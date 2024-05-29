using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data
{
    public class PhotoContext : IdentityDbContext<User>
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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    //builder.Entity<Category>().HasData(
        //    //    new Category { Name = "Pesaggio" },
        //    //    new Category { Name = "Famiglia" },
        //    //    new Category { Name = "Mare" },
        //    //    new Category { Name = "Montaglia" },
        //    //    new Category { Name = "Videogiochi" },
        //    //    new Category { Name = "Cibo" }
        //    //    );

        //    base.OnModelCreating(builder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Profile)
                .WithMany(b => b.Photos)
                .HasForeignKey(p => p.ProfileId);
        }
    }
}
