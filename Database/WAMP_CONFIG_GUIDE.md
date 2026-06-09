# 📚 Guide Configuration - GSB MariaDB + WAMP Server

## 🎯 Objectif
Configurer une base de données MariaDB pour l'application GSB (Gestion des Fiches de Frais) sur WAMP Server.

---

## 📋 Prérequis

- ✅ WAMP Server installé (version 3.2.0+)
- ✅ MariaDB activé dans WAMP
- ✅ phpMyAdmin accessible
- ✅ Fichier `gsb_schema.sql` disponible

---

## 🚀 Étape 1 : Vérifier que WAMP est correctement configuré

### 1.1 Démarrer WAMP
- Double-cliquer sur l'icône WAMP dans la barre des tâches
- Attendre que tous les services soient **verts** (Apache, MySQL/MariaDB, PHP)

### 1.2 Accéder à phpMyAdmin
- Ouvrir un navigateur → [http://localhost/phpmyadmin](http://localhost/phpmyadmin)
- **Username** : `root`
- **Mot de passe** : (vide par défaut)

---

## 🗄️ Étape 2 : Importer le schéma de base de données

### Méthode 1 : Via phpMyAdmin (Recommandée pour les débutants)

1. **Accéder à phpMyAdmin**
   - URL: [http://localhost/phpmyadmin](http://localhost/phpmyadmin)
   - Se connecter avec les identifiants

2. **Importer le fichier SQL**
   - Cliquer sur l'onglet **"Importer"** en haut
   - Cliquer sur **"Choisir un fichier"**
   - Sélectionner `gsb_schema.sql`
   - Laisser les options par défaut
   - Cliquer sur **"Exécuter"**

3. **Vérifier la création**
   - La base `gsb_app` doit apparaître dans la liste à gauche
   - Cliquer dessus pour voir les tables créées

### Méthode 2 : Via ligne de commande (Pour utilisateurs avancés)

```bash
# Ouvrir CMD
cd "C:\wamp64\bin\mysql\mysql8.0.28\bin"  # Adapter le chemin selon votre version

# Se connecter à MariaDB
mysql -u root -p

# (Appuyer sur Entrée si pas de mot de passe)
```

Puis dans le client MySQL :
```sql
SOURCE C:/path/to/gsb_schema.sql;
```

---

## ✅ Étape 3 : Vérifier la structure de la base

Après l'import, exécuter les commandes suivantes dans phpMyAdmin :

```sql
-- Afficher toutes les tables créées
SHOW TABLES;

-- Voir la structure de chaque table
DESCRIBE utilisateur;
DESCRIBE type_frais;
DESCRIBE fiche_frais;
DESCRIBE ligne_frais_forfait;
DESCRIBE ligne_frais_hors_forfait;
DESCRIBE historique_etat;

-- Compter les enregistrements
SELECT COUNT(*) as 'Utilisateurs' FROM utilisateur;
SELECT COUNT(*) as 'Types de frais' FROM type_frais;
SELECT COUNT(*) as 'Fiches' FROM fiche_frais;
```

---

## 🔐 Étape 4 : Créer un utilisateur MariaDB dédié (Recommandé)

Pour plus de sécurité, créer un utilisateur spécifique pour l'application :

```sql
-- Créer un nouvel utilisateur
CREATE USER 'gsb_user'@'localhost' IDENTIFIED BY 'password_gsb_secure';

-- Accorder les permissions sur la base gsb_app
GRANT ALL PRIVILEGES ON gsb_app.* TO 'gsb_user'@'localhost';

-- Appliquer les modifications
FLUSH PRIVILEGES;
```

**Utiliser ces identifiants dans la configuration de l'application :**
- **Serveur** : `localhost`
- **Utilisateur** : `gsb_user`
- **Mot de passe** : `password_gsb_secure`
- **Base de données** : `gsb_app`

---

## 📁 Configuration dans l'Application .NET

### Pour Entity Framework Core

Ajouter la connection string dans `appsettings.json` :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=gsb_user;password=password_gsb_secure;database=gsb_app"
  }
}
```

### Pour Pomelo (MySQL pour .NET Core)

Dans `Program.cs` ou `Startup.cs` :

```csharp
services.AddDbContext<GsbContext>(options =>
    options.UseMySql(
        Configuration.GetConnectionString("DefaultConnection"),
        new MariaDbServerVersion(new Version(10, 5, 0))
    )
);
```

---

## 🧪 Données de Test

Des données d'exemple ont été importées :

### Utilisateurs Test
| Login | Mot de passe | Rôle |
|-------|--------------|------|
| jdupont | * | VISITEUR |
| mmartin | * | VISITEUR |
| pbernard | * | COMPTABLE |
| admin | * | ADMIN |
| sdurand | * | VISITEUR |

*Note : Les mots de passe sont hashés. À adapter selon votre système d'authentification.*

### Types de Frais
- **Repas midi** : 16,50 €
- **Repas soir** : 25,00 €
- **Nuitée** : 50,00 €
- **Étapes (km)** : 29,10 €

---

## 🔄 Restauration / Réinitialisation

### Supprimer et recréer la base (Attention ⚠️)

```sql
DROP DATABASE IF EXISTS gsb_app;
-- Puis ré-exécuter le script gsb_schema.sql
```

---

## 📊 Schéma de la Base de Données

```
┌─────────────────────────────────────────┐
│          UTILISATEUR                    │
│ • idUtilisateur (PK)                   │
│ • nom, prenom, login (UNIQUE)          │
│ • mdpHash, role (ENUM)                 │
└──────────────────┬──────────────────────┘
                   │ (1,n)
                   │
┌──────────────────▼──────────────────────┐
│          FICHE_FRAIS                    │
│ • idFiche (PK)                         │
│ • mois (YYYYMM), etat (ENUM)          │
│ • idUtilisateur (FK)                   │
│ • montantTotal, remarks                │
└──────┬───────────────────────┬──────────┘
       │ (1,n)                 │ (1,n)
       │                       │
   ┌───▼───────────┐      ┌────▼──────────────┐
   │LIGNE_FRAIS_   │      │LIGNE_FRAIS_       │
   │FORFAIT        │      │HORS_FORFAIT       │
   │ • idLFF (PK)  │      │ • idLHFF (PK)     │
   │ • quantite    │      │ • libelle         │
   │ • idFiche(FK) │      │ • montant         │
   │ • idTypeFrais │      │ • justificatif    │
   │               │      │ • idFiche (FK)    │
   └───┬───────────┘      └───────────────────┘
       │ (n,1)
       │
   ┌───▼──────────────┐
   │  TYPE_FRAIS      │
   │ • idTypeFrais(PK)│
   │ • libelle        │
   │ • tarif          │
   │ • type (ENUM)    │
   └──────────────────┘
```

---

## ❓ Troubleshooting

### Erreur : "Access denied for user 'root'@'localhost'"
- Vérifier que WAMP est bien en vert
- Vérifier le mot de passe (vide par défaut)
- Redémarrer les services WAMP

### Erreur : "Can't connect to MySQL server"
- Vérifier que MariaDB/MySQL est coché dans WAMP
- Relancer les services
- Vérifier le port (3306 par défaut)

### Les tables ne s'affichent pas
- F5 pour rafraîchir phpMyAdmin
- Vérifier que la base `gsb_app` existe
- Réimporter le fichier `gsb_schema.sql`

---

## 📞 Support

Pour plus d'informations :
- Documentation WAMP : [wampserver.com](https://wampserver.com)
- Documentation MariaDB : [mariadb.org](https://mariadb.org)
- phpMyAdmin Help : Cliquer sur le **?** dans phpMyAdmin
