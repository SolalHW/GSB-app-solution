# 🛠️ Guide d'Intégration - GSB + Entity Framework Core

Ce document explique comment intégrer la base de données MariaDB à l'application .NET avec Entity Framework Core.

---

## 📋 Prérequis

- ✅ Visual Studio 2022 ou VS Code
- ✅ .NET 6.0+ installé
- ✅ Package `Pomelo.EntityFrameworkCore.MySql` installé
- ✅ Base de données `gsb_app` créée dans MariaDB

---

## 🚀 Étape 1 : Installer les packages NuGet

### Via Package Manager Console

```powershell
PM> Install-Package Pomelo.EntityFrameworkCore.MySql
PM> Install-Package Microsoft.EntityFrameworkCore.Tools
```

### Via .NET CLI

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Fichier .csproj

```xml
<ItemGroup>
  <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="7.0.0" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.0" />
</ItemGroup>
```

---

## 📝 Étape 2 : Configuration - appsettings.json

Modifier ou créer `appsettings.json` dans la racine du projet :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;user=gsb_user;password=password_gsb_secure;database=gsb_app;CharacterSet=utf8mb4"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

**Paramètres importants :**
- `server` : Adresse du serveur (localhost pour WAMP)
- `port` : Port MySQL (3306 par défaut)
- `user` : Utilisateur MariaDB
- `password` : Mot de passe
- `database` : Nom de la base (gsb_app)
- `CharacterSet=utf8mb4` : Support complet UTF-8

---

## 🏗️ Étape 3 : Créer les modèles Entity

### Dossier Models

Créer un dossier `Models` dans le projet et y ajouter les entités :

#### **Utilisateur.cs**

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSBApp.Models
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(255)]
        public string MdpHash { get; set; }

        [Required]
        public string Role { get; set; } // ADMIN, VISITEUR, COMPTABLE

        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public bool Actif { get; set; } = true;

        // Navigation properties
        public ICollection<FicheFrais> FicheFrais { get; set; } = new List<FicheFrais>();
        public ICollection<HistoriqueEtat> Historiques { get; set; } = new List<HistoriqueEtat>();
    }
}
```

#### **TypeFrais.cs**

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSBApp.Models
{
    [Table("type_frais")]
    public class TypeFrais
    {
        [Key]
        public int IdTypeFrais { get; set; }

        [Required]
        [StringLength(100)]
        public string Libelle { get; set; }

        [Required]
        public decimal Tarif { get; set; }

        [Required]
        public string Type { get; set; } // FORFAIT, HORS_FORFAIT

        public string Description { get; set; }
        public bool Actif { get; set; } = true;
        public DateTime DateCreation { get; set; }

        // Navigation properties
        public ICollection<LigneFraisForfait> LignesFraisForfait { get; set; } = new List<LigneFraisForfait>();
    }
}
```

#### **FicheFrais.cs**

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSBApp.Models
{
    [Table("fiche_frais")]
    public class FicheFrais
    {
        [Key]
        public int IdFiche { get; set; }

        [Required]
        [StringLength(6)]
        public string Mois { get; set; } // Format YYYYMM

        [Required]
        public string Etat { get; set; } // EN_COURS, EN_ATTENTE, VALIDEE, REFUSEE, REMBOURSEE

        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }

        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public DateTime? DateSoumission { get; set; }
        public DateTime? DateValidation { get; set; }
        public decimal MontantTotal { get; set; }
        public string Remarques { get; set; }

        // Navigation properties
        public Utilisateur Utilisateur { get; set; }
        public ICollection<LigneFraisForfait> LignesFraisForfait { get; set; } = new List<LigneFraisForfait>();
        public ICollection<LigneFraisHorsForfait> LignesHorsForfait { get; set; } = new List<LigneFraisHorsForfait>();
    }
}
```

#### **LigneFraisForfait.cs**

```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSBApp.Models
{
    [Table("ligne_frais_forfait")]
    public class LigneFraisForfait
    {
        [Key]
        public int IdLFF { get; set; }

        [Required]
        public int Quantite { get; set; }

        [Required]
        public decimal MontantUnitaire { get; set; }

        public decimal MontantTotal => Quantite * MontantUnitaire;

        [ForeignKey("FicheFrais")]
        public int IdFiche { get; set; }

        [ForeignKey("TypeFrais")]
        public int IdTypeFrais { get; set; }

        public DateTime DateCreation { get; set; }

        // Navigation properties
        public FicheFrais FicheFrais { get; set; }
        public TypeFrais TypeFrais { get; set; }
    }
}
```

#### **LigneFraisHorsForfait.cs**

```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSBApp.Models
{
    [Table("ligne_frais_hors_forfait")]
    public class LigneFraisHorsForfait
    {
        [Key]
        public int IdLHFF { get; set; }

        [Required]
        [StringLength(255)]
        public string Libelle { get; set; }

        [Required]
        public decimal Montant { get; set; }

        [StringLength(255)]
        public string Justificatif { get; set; }

        [Required]
        public DateTime DateEngagement { get; set; }

        [ForeignKey("FicheFrais")]
        public int IdFiche { get; set; }

        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        // Navigation properties
        public FicheFrais FicheFrais { get; set; }
    }
}
```

#### **HistoriqueEtat.cs**

```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSBApp.Models
{
    [Table("historique_etat")]
    public class HistoriqueEtat
    {
        [Key]
        public int IdHistorique { get; set; }

        [ForeignKey("FicheFrais")]
        public int IdFiche { get; set; }

        public string EtatPrecedent { get; set; }

        [Required]
        public string EtatNouveau { get; set; }

        [ForeignKey("UtilisateurModification")]
        public int IdUtilisateurModification { get; set; }

        public DateTime DateModification { get; set; }
        public string Commentaire { get; set; }

        // Navigation properties
        public FicheFrais FicheFrais { get; set; }
        public Utilisateur UtilisateurModification { get; set; }
    }
}
```

---

## 🗄️ Étape 4 : Créer le DbContext

Créer `GsbContext.cs` dans le dossier `Models` ou `Data` :

```csharp
using Microsoft.EntityFrameworkCore;
using GSBApp.Models;

namespace GSBApp.Data
{
    public class GsbContext : DbContext
    {
        public GsbContext(DbContextOptions<GsbContext> options) : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<TypeFrais> TypesFrais { get; set; }
        public DbSet<FicheFrais> FichesFrais { get; set; }
        public DbSet<LigneFraisForfait> LignesFraisForfait { get; set; }
        public DbSet<LigneFraisHorsForfait> LignesHorsForfait { get; set; }
        public DbSet<HistoriqueEtat> Historiques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des relations
            modelBuilder.Entity<FicheFrais>()
                .HasOne(f => f.Utilisateur)
                .WithMany(u => u.FicheFrais)
                .HasForeignKey(f => f.IdUtilisateur)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LigneFraisForfait>()
                .HasOne(l => l.FicheFrais)
                .WithMany(f => f.LignesFraisForfait)
                .HasForeignKey(l => l.IdFiche)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LigneFraisHorsForfait>()
                .HasOne(l => l.FicheFrais)
                .WithMany(f => f.LignesHorsForfait)
                .HasForeignKey(l => l.IdFiche)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HistoriqueEtat>()
                .HasOne(h => h.FicheFrais)
                .WithMany()
                .HasForeignKey(h => h.IdFiche)
                .OnDelete(DeleteBehavior.Cascade);

            // Constraint unique (utilisateur + mois = unique)
            modelBuilder.Entity<FicheFrais>()
                .HasIndex(f => new { f.IdUtilisateur, f.Mois })
                .IsUnique();
        }
    }
}
```

---

## ⚙️ Étape 5 : Configurer dans Program.cs

Pour .NET 6+ (minimal hosting) :

```csharp
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using GSBApp.Data;

var builder = WebApplicationBuilder.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<GsbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MariaDbServerVersion(new Version(10, 5, 0))
    )
);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFicheFraisRepository, FicheFraisRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

---

## ✅ Étape 6 : Tester la connexion

### Via Package Manager Console

```powershell
PM> Add-Migration InitialCreate
PM> Update-Database
```

### Vérifier la création

Dans `Program.cs`, ajouter un test simple :

```csharp
using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<GsbContext>();
    var utilisateurs = context.Utilisateurs.ToList();
    Console.WriteLine($"✓ Connecté ! {utilisateurs.Count} utilisateurs trouvés.");
}
```

---

## 💡 Exemple d'utilisation - Repository Pattern

### **IFicheFraisRepository.cs**

```csharp
using GSBApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSBApp.Data.Repositories
{
    public interface IFicheFraisRepository
    {
        Task<FicheFrais> GetByIdAsync(int id);
        Task<IEnumerable<FicheFrais>> GetByUserAsync(int idUtilisateur);
        Task<FicheFrais> CreateAsync(FicheFrais fiche);
        Task<FicheFrais> UpdateAsync(FicheFrais fiche);
        Task DeleteAsync(int id);
        Task<IEnumerable<FicheFrais>> GetByEtatAsync(string etat);
    }
}
```

### **FicheFraisRepository.cs**

```csharp
using Microsoft.EntityFrameworkCore;
using GSBApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSBApp.Data.Repositories
{
    public class FicheFraisRepository : IFicheFraisRepository
    {
        private readonly GsbContext _context;

        public FicheFraisRepository(GsbContext context)
        {
            _context = context;
        }

        public async Task<FicheFrais> GetByIdAsync(int id)
        {
            return await _context.FichesFrais
                .Include(f => f.Utilisateur)
                .Include(f => f.LignesFraisForfait)
                    .ThenInclude(l => l.TypeFrais)
                .Include(f => f.LignesHorsForfait)
                .FirstOrDefaultAsync(f => f.IdFiche == id);
        }

        public async Task<IEnumerable<FicheFrais>> GetByUserAsync(int idUtilisateur)
        {
            return await _context.FichesFrais
                .Where(f => f.IdUtilisateur == idUtilisateur)
                .OrderByDescending(f => f.Mois)
                .ToListAsync();
        }

        public async Task<FicheFrais> CreateAsync(FicheFrais fiche)
        {
            _context.FichesFrais.Add(fiche);
            await _context.SaveChangesAsync();
            return fiche;
        }

        public async Task<FicheFrais> UpdateAsync(FicheFrais fiche)
        {
            _context.FichesFrais.Update(fiche);
            await _context.SaveChangesAsync();
            return fiche;
        }

        public async Task DeleteAsync(int id)
        {
            var fiche = await GetByIdAsync(id);
            if (fiche != null)
            {
                _context.FichesFrais.Remove(fiche);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FicheFrais>> GetByEtatAsync(string etat)
        {
            return await _context.FichesFrais
                .Include(f => f.Utilisateur)
                .Where(f => f.Etat == etat)
                .OrderBy(f => f.DateSoumission)
                .ToListAsync();
        }
    }
}
```

---

## 📞 Troubleshooting

### Erreur : "Unable to connect to server"

```
Vérifier :
1. WAMP est démarré (icône verte)
2. MariaDB est actif
3. Connection string est correcte
4. Port 3306 n'est pas bloqué par firewall
```

### Erreur : "Access denied"

```
Vérifier :
1. Utilisateur gsb_user existe
2. Mot de passe est correct
3. Permissions sont accordées : GRANT ALL ON gsb_app.*
```

### Migration échoue

```powershell
# Supprimer les migrations et recommencer
PM> Remove-Migration -Force
PM> Add-Migration InitialCreate
PM> Update-Database
```

---

## 📚 Ressources supplémentaires

- [Entity Framework Core - MySQL](https://docs.microsoft.com/ef/core/providers/mysql/)
- [Pomelo Documentation](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [Repository Pattern](https://martinfowler.com/eaaCatalog/repository.html)

---

**Status** : ✅ Prêt pour développement
