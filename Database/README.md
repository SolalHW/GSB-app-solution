# 📁 Dossier Database - GSB

Ce dossier contient tous les fichiers relatifs à la base de données MariaDB de l'application GSB (Gestion des Fiches de Frais).

---

## 📂 Structure du dossier

```
Database/
├── gsb_schema.sql              ← Script SQL complet (à importer)
├── WAMP_CONFIG_GUIDE.md        ← Guide pas-à-pas pour configurer WAMP
├── MERISE_MODEL.md             ← Documentation MERISE complète (MCD/MLD/MPD)
├── COMMON_QUERIES.sql          ← Requêtes SQL courantes et utiles
└── README.md                   ← Ce fichier
```

---

## 🚀 Démarrage rapide

### 1️⃣ Importer la base de données (5 minutes)

**Méthode A : phpMyAdmin (Recommandée)**

```
1. Ouvrir http://localhost/phpmyadmin
2. Onglet "Importer" en haut
3. Sélectionner gsb_schema.sql
4. Cliquer "Exécuter"
```

**Méthode B : Ligne de commande**

```bash
mysql -u root -p < gsb_schema.sql
```

### 2️⃣ Vérifier l'installation

```sql
USE gsb_app;
SHOW TABLES;
-- Résultat : 6 tables créées ✓
```

### 3️⃣ Explorer les données

```sql
SELECT * FROM utilisateur;
SELECT * FROM type_frais;
```

---

## 📋 Fichiers principaux

### **gsb_schema.sql** - Script de création complet
- ✅ Crée la base de données `gsb_app`
- ✅ Crée 6 tables principales
- ✅ Définit les clés primaires et étrangères
- ✅ Insère 20+ enregistrements d'exemple
- ✅ Inclut des indices pour performance

**À utiliser :** Premier import de la BDD

---

### **MERISE_MODEL.md** - Documentation de modélisation
- 📐 MCD (Modèle Conceptuel) avec associations
- 🧠 MLD (Modèle Logique) avec attributs
- 🗄️ MPD (Modèle Physique) avec types SQL
- 📊 Diagramme global
- ✅ 10 règles métier vérifiées
- 📚 Exemples de requêtes courantes

**À consulter :** Pour comprendre la structure, développer les modèles EF Core

---

### **WAMP_CONFIG_GUIDE.md** - Guide de configuration
- 🎯 Installation et vérification WAMP
- 📥 Étapes d'import (2 méthodes)
- ✅ Vérification de structure
- 🔐 Création utilisateur MariaDB sécurisé
- ⚙️ Configuration .NET (connection string)
- ❓ Troubleshooting

**À suivre :** Si besoin de configurer WAMP ou d'intégrer la BDD à l'application

---

### **COMMON_QUERIES.sql** - Recueil de requêtes
Requêtes prêtes à l'emploi dans 9 catégories :
1. **Gestion des utilisateurs** - CRUD utilisateur
2. **Gestion des fiches** - Création, soumission, validation
3. **Lignes forfait** - Ajout, modification, suppression
4. **Lignes hors forfait** - Montants libres avec justificatifs
5. **Calculs de montants** - Totaux, sous-totaux
6. **Rapports et statistiques** - Analyses, moyennes
7. **Traçabilité** - Historique des changements
8. **Maintenance** - Nettoyage, vérification d'intégrité
9. **Export données** - Sortie en CSV

**À utiliser :** Copier-coller pour développer rapidement

---

## 📊 Schéma relationnel simplifié

```
UTILISATEUR (1) ──→ (n) FICHE_FRAIS
                           ├──→ (n) LIGNE_FRAIS_FORFAIT
                           │          ├──→ TYPE_FRAIS
                           │
                           └──→ (n) LIGNE_FRAIS_HORS_FORFAIT
                           
HISTORIQUE_ETAT ←─ (traçabilité) ─→ FICHE_FRAIS
```

---

## 🔑 Données de test incluses

### Utilisateurs
- **jdupont** (Visiteur)
- **mmartin** (Visiteur)
- **pbernard** (Comptable)
- **admin** (Administrateur)
- **sdurand** (Visiteur)

### Types de frais forfaitaires
- Repas midi (16,50 €)
- Repas soir (25,00 €)
- Nuitée (50,00 €)
- Étapes/km (29,10 €)

### Fiches de frais
- 5 fiches de test avec états variés (EN_COURS, EN_ATTENTE, VALIDEE)
- ~15 lignes d'exemple (forfait et hors forfait)

**Action :** Libre de les modifier ou supprimer pour vos besoins

---

## ⚙️ Configuration pour l'Application .NET

### Connection String (appsettings.json)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=gsb_user;password=password_gsb_secure;database=gsb_app"
  }
}
```

### Entity Framework Core (Program.cs)

```csharp
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

services.AddDbContext<GsbContext>(options =>
    options.UseMySql(
        Configuration.GetConnectionString("DefaultConnection"),
        new MariaDbServerVersion(new Version(10, 5, 0))
    )
);
```

---

## 🎯 Prochaines étapes

### Phase 1 : Base de données ✅
- [x] Script SQL créé
- [x] Documentation complète
- [ ] Importer dans WAMP

### Phase 2 : Application C#
- [ ] Créer les modèles EF Core
- [ ] Implémenter les DbSet
- [ ] Configurer les relations

### Phase 3 : Service Layer
- [ ] Interfaces de service
- [ ] Logique métier
- [ ] Gestion des états

### Phase 4 : Présentation
- [ ] Contrôleurs MVC
- [ ] Vues et formulaires
- [ ] Authentification/Autorisation

---

## 📞 Support & Documentation

- **WAMP** : [wampserver.com](https://wampserver.com)
- **MariaDB** : [mariadb.org/documentation](https://mariadb.org/documentation)
- **phpMyAdmin** : Aide intégrée (? en haut à droite)
- **Entity Framework** : [docs.microsoft.com/ef](https://docs.microsoft.com/ef)

---

## ✨ Points clés à retenir

1. ✅ **6 tables créées** avec relations correctes
2. ✅ **Suppression en cascade** : Fiche supprimée → Lignes supprimées aussi
3. ✅ **Calcul automatique** : Montant total = quantité × tarif
4. ✅ **États contrôlés** : ENUM avec 5 valeurs (EN_COURS, EN_ATTENTE, etc.)
5. ✅ **Traçabilité complète** : Table historique + timestamps
6. ✅ **Données d'exemple** : 20+ enregistrements pour commencer

---

## 🔍 Vérification de santé

Exécuter périodiquement pour s'assurer que tout fonctionne :

```sql
-- Voir le résumé de la base
SELECT 
    (SELECT COUNT(*) FROM utilisateur) as 'Utilisateurs',
    (SELECT COUNT(*) FROM fiche_frais) as 'Fiches',
    (SELECT COUNT(*) FROM ligne_frais_forfait) as 'Lignes Forfait',
    (SELECT COUNT(*) FROM ligne_frais_hors_forfait) as 'Lignes Hors Forfait';
```

---

**Dernière mise à jour** : 2024
**Version schéma** : 1.0
**Statut** : ✅ Prêt pour développement
