using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Data
{
    public class AppDbContext : IdentityDbContext<WebApp.Models.ApplicatonUser>
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=baza-app-db; Integrated Security = True;");
            optionsBuilder.LogTo(m => Debug.WriteLine(m))
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Glumac_Film>().HasKey(am => new
            {
                am.GlumacId,
                am.FilmId
            });

            modelBuilder.Entity<Glumac_Film>().HasOne(f => f.Film).WithMany(gf=>gf.Glumci_Filmovi).HasForeignKey(f=>f.FilmId);
            modelBuilder.Entity<Glumac_Film>().HasOne(f => f.Glumac).WithMany(gf => gf.Glumci_Filmovi).HasForeignKey(g => g.GlumacId);

            modelBuilder.Entity<Komentar_Film>().HasKey(am => new
            {
                am.KomentarId,
                am.FilmId
            });

            modelBuilder.Entity<Komentar_Film>().HasOne(f => f.Film).WithMany(gf => gf.Komentari_Filmovi).HasForeignKey(f => f.FilmId);
            modelBuilder.Entity<Komentar_Film>().HasOne(f => f.Komentar).WithMany(gf => gf.Komentar_Film).HasForeignKey(g => g.KomentarId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Glumac> Glumci { get; set; }
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Glumac_Film> Glumci_Filmovi { get; set; }
        public DbSet<Bioskop> Bioskopi { get; set; }
        public DbSet<Producent> Producenti { get; set; }
        public DbSet<Komentar> Komentari { get; set; }
        public DbSet<Komentar_Film> Komentari_Filmovi { get; set; }

    }
}
