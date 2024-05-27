﻿using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data
{
    public class PhotoContext : DbContext
    {
        //Foto
        public DbSet<Photo> Photos { get; set; }

        //Categorie
        public DbSet<Category> Categories { get; set; }

        public object PhotoContexts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=DbPhotos;");
        }
    }
}
