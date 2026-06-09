// Example: GsbContext.cs
// Localisation: Data/GsbContext.cs
// Ce fichier montre comment configurer Entity Framework Core avec MariaDB

using Microsoft.EntityFrameworkCore;
using GSBApp.Models;

namespace GSBApp.Data
{
    public class GsbContext : DbContext
    {
        public GsbContext(DbContextOptions<GsbContext> options) : base(options) { }

        // DbSets pour chaque entité
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<TypeFrais> TypesFrais { get; set; }
        public DbSet<FicheFrais> FichesFrais { get; set; }
        public DbSet<LigneFraisForfait> LignesFraisForfait { get; set; }
        public DbSet<LigneFraisHorsForfait> LignesHorsForfait { get; set; }
        public DbSet<HistoriqueEtat> Historiques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations et contraintes
            modelBuilder.Entity<FicheFrais>()
                .HasOne(f => f.Utilisateur)
                .WithMany(u => u.FicheFrais)
                .HasForeignKey(f => f.IdUtilisateur)
                .OnDelete(DeleteBehavior.Cascade);

            // Unicité utilisateur + mois
            modelBuilder.Entity<FicheFrais>()
                .HasIndex(f => new { f.IdUtilisateur, f.Mois })
                .IsUnique();
        }
    }
}
