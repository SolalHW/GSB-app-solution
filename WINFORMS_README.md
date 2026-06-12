# GSB Frais - Application WinForms .NET 8

## 📋 Documentation Complète

### Structure de la Solution

```
GSB_Frais.Models/          # Modèles de données
├── Utilisateur.cs
├── TypeFrais.cs
├── FicheFrais.cs
├── LigneFraisForfait.cs
└── LigneFraisHorsForfait.cs

GSB_Frais.DAL/             # Data Access Layer
├── DatabaseConfig.cs
└── Repositories/
    ├── UtilisateurRepository.cs
    ├── TypeFraisRepository.cs
    ├── FicheFraisRepository.cs
    └── LigneFraisRepository.cs

GSB_Frais.Metier/          # Business Layer
└── Services/
    ├── AuthService.cs
    ├── FicheFraisService.cs
    ├── ValidationService.cs
    ├── UtilisateurService.cs
    └── TypeFraisService.cs

GSB_Frais.UI/              # WinForms UI
├── Program.cs
├── Utilitaires/
│   ├── ExceptionManager.cs
│   └── SessionManager.cs
└── Formulaires/
    ├── FrmLogin.cs (Authentification)
    ├── FrmMenuAdmin.cs (Menu Admin)
    ├── FrmGestionUtilisateurs.cs (Gestion Utilisateurs)
    ├── FrmEditionUtilisateur.cs (Édition Utilisateur)
    ├── FrmGestionTypesFrais.cs (Gestion Types)
    ├── FrmEditionTypeFrais.cs (Édition Type)
    ├── FrmMesFiches.cs (Liste fiches visiteur)
    ├── FrmEditionFiche.cs (Édition fiche)
    ├── FrmAddLigneHorsForfait.cs (Ajout ligne)
    ├── FrmRechercheFiches.cs (Recherche comptable)
    └── FrmValidationFiche.cs (Validation comptable)
```

---

## 🚀 Installation et Configuration

### 1. **Prérequis**
- **.NET 8 SDK** (ou plus récent)
- **Visual Studio 2022** (recommandé)
- **MariaDB/MySQL** (base de données existante)

### 2. **Configuration de la Base de Données**

Vérifiez que les tables suivantes existent dans votre base `GSB_FRAIS`:
- `UTILISATEUR`
- `TYPE_FRAIS`
- `FICHE_FRAIS`
- `LIGNE_FRAIS_FORFAIT`
- `LIGNE_FRAIS_HORS_FORFAIT`

Le script d'initialisation se trouve dans: `Docker/init.sql`

### 3. **Configuration de la Connexion**

Modifiez `DatabaseConfig` dans `GSB_Frais.DAL/DatabaseConfig.cs`:

```csharp
public static string ConnectionString { get; set; } = 
    "Server=localhost;Port=3306;Database=GSB_FRAIS;Uid=root;Pwd=votremotdepasse;";
```

### 4. **Restauration des Packages NuGet**

```bash
cd GSB-app-solution
dotnet restore
```

---

## 🔧 Compilation et Exécution

### Build la solution
```bash
dotnet build --configuration Release
```

### Exécuter l'application
```bash
cd GSB_Frais.UI
dotnet run
```

---

## 👥 Rôles et Accès

### **ADMIN**
- Gestion des utilisateurs (CRUD)
- Gestion des types de frais (CRUD)
- Accès: Menu Admin

### **COMPTABLE**
- Consultation des fiches en attente de validation
- Validation complète, refus complet, ou refus partiel des fiches
- Accès: Menu Comptable

### **VISITEUR**
- Création et modification de ses propres fiches
- Ajout de lignes de frais forfait et hors forfait
- Soumission des fiches au comptable
- Accès: Mes Fiches

---

## 🔐 Sécurité

### **Authentification**
- Login/Mot de passe avec hashage **BCrypt**
- Session managée via `SessionManager`

### **Contrôle d'Accès**
- Vérification du rôle avant accès aux formulaires
- Navigation restrictive selon le rôle

### **Gestion des Erreurs**
- `ExceptionManager` pour les messages d'erreur cohérents
- Logging centralisé des opérations

---

## 💾 Architecture et Patterns

### **Repository Pattern**
Tous les accès à la base de données passent par les Repositories:
- `UtilisateurRepository`
- `TypeFraisRepository`
- `FicheFraisRepository`
- `LigneFraisRepository`

### **Service Layer**
Les services métier encapsulent la logique:
- `AuthService` - Authentification
- `FicheFraisService` - Gestion des fiches
- `ValidationService` - Validation des fiches
- `UtilisateurService` - Gestion des utilisateurs
- `TypeFraisService` - Gestion des types

### **Partial Classes**
Les formulaires utilisent les partial classes pour séparer:
- `FormName.Designer.cs` - UI (générée automatiquement)
- `FormName.cs` - Logique (code-behind)

---

## 📊 Flux de Travail

### **Visiteur**
1. **Connexion** → Authentification
2. **Mes Fiches** → Liste des fiches
3. **Nouvelle Fiche** → Création fiche mensuelle
4. **Édition Fiche** →
   - Onglet Forfait: Modifier les quantités
   - Onglet Hors Forfait: Ajouter des lignes
5. **Soumettre** → Passer en EN_ATTENTE

### **Comptable**
1. **Connexion** → Authentification
2. **Recherche** → Fiches EN_ATTENTE
3. **Sélectionner une fiche** → Détails
4. **Actions** →
   - Valider (VALIDEE)
   - Refuser (REFUSEE)
   - Refus Partiel (REFUS_PARTIEL)

### **Admin**
1. **Connexion** → Authentification
2. **Menu Admin** →
   - Gestion Utilisateurs (CRUD)
   - Gestion Types de Frais (CRUD)

---

## 🛠️ Dependencies

```xml
<!-- GSB_Frais.DAL -->
<PackageReference Include="MySqlConnector" Version="2.3.7" />

<!-- GSB_Frais.Metier -->
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />

<!-- GSB_Frais.UI -->
<!-- Aucune dépendance externe - utilise WinForms natif -->
```

---

## 📝 Exemples d'Utilisation

### Ajouter un utilisateur
```csharp
var authService = new AuthService();
int idNew = await authService.CreateUserAsync(
    "Dupont", "Jean", "jdupont", "password123", "VISITEUR"
);
```

### Charger une fiche
```csharp
var ficheFraisService = new FicheFraisService();
var fiche = await ficheFraisService.GetOrCreateFicheAsync(1, "202401");
```

### Valider une fiche
```csharp
var validationService = new ValidationService();
bool success = await validationService.ValidateCompleteFicheAsync(1);
```

---

## ⚙️ Maintenance

### **Sauvegarde Base de Données**
```bash
mysqldump -u root -p GSB_FRAIS > backup.sql
```

### **Restauration**
```bash
mysql -u root -p GSB_FRAIS < backup.sql
```

---

## 🐛 Dépannage

### **Erreur de connexion BDD**
- Vérifier `DatabaseConfig.ConnectionString`
- Vérifier que MySQL/MariaDB est actif
- Vérifier les credentials

### **Erreur "Identifiants invalides"**
- Vérifier les utilisateurs dans la table `UTILISATEUR`
- Vérifier que le rôle est correct (ADMIN/COMPTABLE/VISITEUR)

### **Erreur lors du déploiement**
- Vérifier que .NET 8 est installé: `dotnet --version`
- Restaurer les packages: `dotnet restore`
- Nettoyer et rebâtir: `dotnet clean && dotnet build`

---

## 📞 Support

Pour toute question ou problème:
1. Consulter les logs d'application
2. Vérifier la configuration BDD
3. Contactez l'administrateur système

---

**Version**: 1.0  
**Dernière mise à jour**: 2026-06-11  
**Développé avec**: .NET 8 WinForms
