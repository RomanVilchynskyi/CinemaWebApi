using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext() { }
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genre { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("workstation id=CinemaWebApi.mssql.somee.com;packet size=4096;user id=srv_SQLLogin_1;pwd=upxd4q5c5t;data source=CinemaWebApi.mssql.somee.com;persist security info=False;initial catalog=CinemaWebApi;TrustServerCertificate=True");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.SeedGenres();
            modelBuilder.SeedMovies();

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(m => m.Year)
                    .IsRequired();

                entity.Property(m => m.Rating)
                    .IsRequired();

                entity.Property(m => m.Favorite)
                    .IsRequired();

                entity.HasOne(m => m.Genre)
                    .WithMany(g => g.Movies)
                    .HasForeignKey(m => m.GenreId)
                    .OnDelete(DeleteBehavior.Cascade); // або Restrict, залежно від логіки
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });


        }
    }
}
