# ✅ Checklist de Configuration Complète - GSB

Utilise cette checklist pour t'assurer que tout est bien configuré.

---

## 📦 Phase 1 : Installation des outils

- [ ] **WAMP Server** installé (version 3.2+)
  - [ ] Apache activé
  - [ ] MariaDB/MySQL activé
  - [ ] PHP activé

- [ ] **.NET 6.0+** installé
  - [ ] Vérifier : `dotnet --version`

- [ ] **Visual Studio 2022** ou **VS Code**

- [ ] **Git** installé

---

## 🗄️ Phase 2 : Configuration Base de Données

- [ ] **WAMP démarré**
  - Icône dans la barre des tâches = ✅ verte

- [ ] **phpMyAdmin accessible**
  - Navigateur : http://localhost/phpmyadmin
  - Connection : root / (vide)

- [ ] **Script SQL importé**
  - [ ] Fichier : `Database/gsb_schema.sql`
  - [ ] Méthode : phpMyAdmin ou command line
  - [ ] Base `gsb_app` créée

- [ ] **Tables créées correctement**
  ```sql
  USE gsb_app;
  SHOW TABLES;
  -- Résultat : 6 tables ✓
  ```

- [ ] **Données d'exemple présentes**
  ```sql
  SELECT COUNT(*) FROM utilisateur;  -- Résultat : 5
  SELECT COUNT(*) FROM type_frais;   -- Résultat : 4
  ```

- [ ] **Utilisateur MariaDB créé** (optionnel mais recommandé)
  ```sql
  CREATE USER 'gsb_user'@'localhost' IDENTIFIED BY 'password_secure';
  GRANT ALL PRIVILEGES ON gsb_app.* TO 'gsb_user'@'localhost';
  FLUSH PRIVILEGES;
  ```

---

## 📝 Phase 3 : Configuration Projet .NET

### Fichiers et Dossiers

- [ ] **Dossier `Database/` créé** avec :
  - [ ] `gsb_schema.sql`
  - [ ] `MERISE_MODEL.md`
  - [ ] `WAMP_CONFIG_GUIDE.md`
  - [ ] `COMMON_QUERIES.sql`
  - [ ] `EF_CORE_INTEGRATION.md`
  - [ ] `MAINTENANCE.md`
  - [ ] `README.md`

- [ ] **Dossier `Models/` créé** avec les entités :
  - [ ] `Utilisateur.cs`
  - [ ] `FicheFrais.cs`
  - [ ] `TypeFrais.cs`
  - [ ] `LigneFraisForfait.cs`
  - [ ] `LigneFraisHorsForfait.cs`
  - [ ] `HistoriqueEtat.cs`

- [ ] **Dossier `Data/` créé** avec :
  - [ ] `GsbContext.cs` (DbContext)
  - [ ] `Repositories/` (pattern Repository)

- [ ] **Fichier `appsettings.json` configuré**
  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "server=localhost;user=gsb_user;password=password;database=gsb_app"
    }
  }
  ```

### Packages NuGet

- [ ] **Pomelo.EntityFrameworkCore.MySql** installé
  ```bash
  dotnet add package Pomelo.EntityFrameworkCore.MySql
  ```

- [ ] **Microsoft.EntityFrameworkCore.Tools** installé
  ```bash
  dotnet add package Microsoft.EntityFrameworkCore.Tools
  ```

### DbContext et Migrations

- [ ] **GsbContext hérité de DbContext**
  ```csharp
  public DbSet<Utilisateur> Utilisateurs { get; set; }
  public DbSet<TypeFrais> TypesFrais { get; set; }
  // ... autres DbSets
  ```

- [ ] **DbContext enregistré dans Program.cs**
  ```csharp
  services.AddDbContext<GsbContext>(options =>
      options.UseMySql(connectionString, ...));
  ```

- [ ] **Migrations créées**
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```

---

## 🧪 Phase 4 : Tests de Connexion

### Test 1 : Connexion MariaDB

```bash
# Via command line
mysql -u gsb_user -p -h localhost

# Puis dans MySQL
USE gsb_app;
SELECT * FROM utilisateur;
```

- [ ] Retour : 5 utilisateurs

### Test 2 : Connexion EF Core

Dans `Program.cs` ou dans une action de contrôleur :

```csharp
using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<GsbContext>();
    var users = await context.Utilisateurs.ToListAsync();
    Console.WriteLine($"✓ Connexion OK ! {users.Count} utilisateurs trouvés.");
}
```

- [ ] Résultat : Message de succès

### Test 3 : Application lancée

```bash
dotnet run
```

- [ ] Application démarre sans erreur
- [ ] Navigateur : http://localhost:5000 accessible

---

## 📊 Phase 5 : Vérifications Finales

### Intégrité des Données

```sql
-- Vérifier qu'il n'y a pas d'orphelins
SELECT COUNT(*) FROM fiche_frais ff
LEFT JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
WHERE u.idUtilisateur IS NULL;
-- Résultat : 0
```

- [ ] Pas d'orphelins

### Index et Performance

```sql
-- Voir les index créés
SHOW INDEX FROM fiche_frais;
```

- [ ] Index présents (idUtilisateur, mois, etat)

### Permissions

```sql
-- Vérifier les permissions de gsb_user
SHOW GRANTS FOR 'gsb_user'@'localhost';
```

- [ ] Permissions OK sur gsb_app

---

## 📚 Phase 6 : Documentation

- [ ] **README.md** mis à jour avec la structure
- [ ] **Database/README.md** disponible et lisible
- [ ] **MERISE_MODEL.md** consulté et compris
- [ ] **WAMP_CONFIG_GUIDE.md** disponible
- [ ] **EF_CORE_INTEGRATION.md** suivi
- [ ] **COMMON_QUERIES.sql** accessible

---

## 🚨 Troubleshooting Rapide

Si tu as une erreur, cocher le point correspondant après correction :

### Erreur : "Cannot connect to MySQL server"
- [ ] WAMP démarré ?
- [ ] MariaDB vert ?
- [ ] Port 3306 libre ?
- [ ] Connection string correcte ?

### Erreur : "Access denied for user"
- [ ] Utilisateur gsb_user créé ?
- [ ] Mot de passe correct ?
- [ ] Permissions accordées ?

### Erreur : "EF Core: No database provider"
- [ ] Pomelo installé ?
- [ ] DbContext enregistré dans Program.cs ?
- [ ] Connexion string OK ?

### Erreur : "Migration failed"
- [ ] Tables créées dans la BDD ?
- [ ] Modèles correspondent à la structure ?
- [ ] Pas de conflits de colonne ?

---

## 🎯 Prochaines Étapes

Une fois tous les points cochés :

1. ✅ Créer les contrôleurs MVC
2. ✅ Développer les vues Razor
3. ✅ Implémenter les services métier
4. ✅ Ajouter l'authentification
5. ✅ Tests et déploiement

---

## 📞 Aide Rapide

| Problème | Solution |
|---------|----------|
| WAMP ne démarre pas | Relancer / Vérifier les ports |
| phpMyAdmin 404 | Vérifier que Apache est vert |
| BDD vide après import | Réimporter gsb_schema.sql |
| EF Migrations failed | Supprimer les migrations et recommencer |
| Application ne démarre | Vérifier appsettings.json |

---

## 📋 Résumé Fichiers Créés

```
Database/
├── ✅ gsb_schema.sql (600+ lignes)
├── ✅ WAMP_CONFIG_GUIDE.md (complet)
├── ✅ MERISE_MODEL.md (détaillé)
├── ✅ COMMON_QUERIES.sql (9 sections)
├── ✅ EF_CORE_INTEGRATION.md (code examples)
├── ✅ MAINTENANCE.md (scripts utiles)
└── ✅ README.md (overview)

Total : 7 fichiers documentés + schéma SQL
```

---

**Checklist version** : 1.0
**Status final** : 🟢 Prêt pour développement
