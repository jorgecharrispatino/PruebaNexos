using Microsoft.EntityFrameworkCore;
using PruebaNexos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNexos.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Autor> AUTOR { get; set; }

        public DbSet<Libro> LIBRO { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Autor>(entity =>
        //    {
        //        entity.HasKey(e => new { e.IDAUTOR });
        ////        entity.HasMany(c => c.Libro)
        ////             .WithOne(e => e.Autor)
        ////             .HasForeignKey(x => x.AUTOR)
        // //            .IsRequired();
        //    });

        //}
    }
}
