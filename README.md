"# 📱 GSB - Gestion des Fiches de Frais

Application ASP.NET Core MVC pour la gestion complète des fiches de frais.

---

## 🎯 Vue d'ensemble

**GSB** est une application de gestion de fiches de frais destinée aux collaborateurs et comptables d'une entreprise. Elle permet :

- ✅ Créer et soumettre des fiches de frais
- ✅ Gérer des frais forfaitaires (repas, hôtel) et hors forfait
- ✅ Valider/refuser les fiches (rôle comptable)
- ✅ Tracker l'historique des changements d'état
- ✅ Générer des rapports et statistiques

---

## 📋 Technologies utilisées

| Component | Technology |
|-----------|-----------|
| **Backend** | ASP.NET Core 6+ |
| **Frontend** | ASP.NET MVC / Razor Views |
| **Database** | MariaDB / MySQL |
| **ORM** | Entity Framework Core + Pomelo |
| **Server** | WAMP Server (Apache + PHP) |
| **IDE** | Visual Studio 2022 / VS Code |

---

## 📁 Structure du projet

```
GSB/
├── 📁 Database/                    ← ⭐ Configuration BDD
│   ├── gsb_schema.sql              # Script SQL complet
│   ├── WAMP_CONFIG_GUIDE.md        # Guide WAMP setup
│   ├── MERISE_MODEL.md             # Documentation MERISE
│   ├── COMMON_QUERIES.sql          # Requêtes courantes
│   ├── EF_CORE_INTEGRATION.md      # Intégration .NET
│   ├── MAINTENANCE.md              # Maintenance BDD
│   └── README.md                   # Documentation Database
│
├── 📁 Manager/                     ← Gestionnaires métier
├── 📁 Models/                      ← Modèles de données
├── 📁 Views/                       ← Vues Razor
├── 📁 Properties/                  ← Configuration projet
├── 📁 Utils/                       ← Utilitaires
│
├── README.md                       ← Ce fichier
└── .gitignore
```

---

## 🚀 Démarrage rapide

### 1️⃣ Prérequis

- .NET 6.0+ installé
- WAMP Server + MariaDB
- Visual Studio 2022 ou VS Code

### 2️⃣ Configuration base de données

```bash
# 1. Ouvrir phpMyAdmin
http://localhost/phpmyadmin

# 2. Importer gsb_schema.sql
# 3. Créer utilisateur gsb_user

# 4. Vérifier la connexion
mysql -u gsb_user -p -h localhost gsb_app
```

### 3️⃣ Configuration application

```bash
# 1. Mettre à jour appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=gsb_user;password=password;database=gsb_app"
  }
}

# 2. Installer packages NuGet
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools

# 3. Appliquer migrations
dotnet ef database update

# 4. Lancer l'application
dotnet run
```

### 4️⃣ Accéder à l'application

```
http://localhost:5000
```

---

## 📊 Modélisation de données

La base de données suit le modèle **MERISE** avec :

- **6 tables** : Utilisateur, FicheFrais, TypeFrais, LigneFraisForfait, LigneFraisHorsForfait, HistoriqueEtat
- **Clés étrangères** avec suppression en cascade
- **Indices** pour performance
- **Enum** pour contrôle d'état

🔍 **Voir** : [Database/MERISE_MODEL.md](Database/MERISE_MODEL.md) pour le détail complet.

---

## 👥 Rôles et Droits

| Rôle | Permissions |
|------|-----------|
| **VISITEUR** | Créer/modifier ses fiches, soumettre |
| **COMPTABLE** | Valider/refuser les fiches, voir tous les rapports |
| **ADMIN** | Gestion utilisateurs, maintenance BDD |

---

## 📖 Documentation complète

| Document | Description |
|----------|-----------|
| [Database/README.md](Database/README.md) | Overview complet de la BDD |
| [Database/MERISE_MODEL.md](Database/MERISE_MODEL.md) | Modélisation MCD/MLD/MPD |
| [Database/WAMP_CONFIG_GUIDE.md](Database/WAMP_CONFIG_GUIDE.md) | Configuration WAMP pas-à-pas |
| [Database/COMMON_QUERIES.sql](Database/COMMON_QUERIES.sql) | Requêtes SQL prêtes à l'emploi |
| [Database/EF_CORE_INTEGRATION.md](Database/EF_CORE_INTEGRATION.md) | Intégration Entity Framework |
| [Database/MAINTENANCE.md](Database/MAINTENANCE.md) | Maintenance et troubleshooting |

---

## 🔧 Commandes utiles

```bash
# Créer une migration
dotnet ef migrations add NomMigration

# Appliquer les migrations
dotnet ef database update

# Voir les migrations
dotnet ef migrations list

# Annuler la dernière migration
dotnet ef migrations remove

# Générer les modèles à partir de la BDD
dotnet ef dbcontext scaffold "connection_string" Pomelo.EntityFrameworkCore.MySql
```

---

## 🆘 Troubleshooting

### ❌ Erreur : "Cannot connect to database"

```
✓ Vérifier que WAMP est démarré (icône verte)
✓ Vérifier que MariaDB est actif
✓ Vérifier la connection string dans appsettings.json
✓ Voir : Database/WAMP_CONFIG_GUIDE.md
```

### ❌ Erreur : "Access denied for user"

```
✓ Vérifier que l'utilisateur gsb_user existe
✓ Vérifier le mot de passe
✓ Exécuter GRANT ALL ON gsb_app.* TO 'gsb_user'@'localhost'
```

### ❌ Erreur : "EF Core Migration failed"

```
✓ Supprimer les migrations : dotnet ef migrations remove -f
✓ Recréer : dotnet ef migrations add InitialCreate
✓ Appliquer : dotnet ef database update
```

---

## 📝 Données de test

La base de données inclut des données d'exemple :

**Utilisateurs test** :
- jdupont (VISITEUR)
- mmartin (VISITEUR)
- pbernard (COMPTABLE)
- admin (ADMIN)

**Types de frais** :
- Repas midi (16,50 €)
- Repas soir (25,00 €)
- Nuitée (50,00 €)
- Étapes/km (29,10 €)

---

## 🔐 Sécurité

- ✅ Authentification par login/mot de passe
- ✅ Hachage des mots de passe (SHA2 / bcrypt)
- ✅ Contrôle d'accès par rôle (RBAC)
- ✅ Traçabilité complète (historique des changements)
- ✅ Validation côté client et serveur
- ✅ Protection contre SQL Injection (ORM + paramètres)

---

## 📞 Support

Pour des questions ou problèmes :

1. 📖 Consulter la documentation dans `Database/`
2. 🔍 Checker les logs dans `appsettings.json` (Logging)
3. 🐛 Voir le WAMP Console pour les erreurs MariaDB
4. 💬 Contacter l'administrateur

---

## 📚 Ressources

- [ASP.NET Core Docs](https://docs.microsoft.com/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [MariaDB Docs](https://mariadb.org/documentation/)
- [WAMP Help](https://wampserver.com/)

---

## 📄 Licence

Projet d'école - À usage pédagogique.

---

## ✨ Status

- ✅ Base de données : Prêt
- ⏳ Modèles EF Core : En cours
- ⏳ Controllers : À développer
- ⏳ Vues : À développer
- ⏳ Authentification : À implémenter

---

**Dernière mise à jour** : 2024
**Version** : 1.0" 
