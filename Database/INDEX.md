📖 INDEX - Documentation GSB
================================

Ce fichier te guide dans toute la documentation disponible.

---

## 🚀 PAR OÙ COMMENCER ?

**Nouveau sur le projet ?** 
→ Commence par : **START_HERE.md**

**Besoin de faire la config maintenant ?**
→ Suis : **WAMP_CONFIG_GUIDE.md**

**Tu codes ?**
→ Regarde : **EF_CORE_INTEGRATION.md**

---

## 📂 FICHIERS DE CONFIGURATION

### ⭐ START_HERE.md (5 minutes)
- Guide express pour démarrer
- Checklist ultra-rapide
- Solutions rapides aux problèmes
- **➜ C'EST PAR LÀ QUE TU DOIS COMMENCER**

### 🔧 WAMP_CONFIG_GUIDE.md
- Installation et vérification WAMP
- Import du schéma SQL (2 méthodes)
- Vérification structure BDD
- Création utilisateur MariaDB sécurisé
- Configuration connection string .NET
- Troubleshooting complet

**À utiliser si :**
- Tu configures WAMP pour la première fois
- L'import échoue
- Tu as une erreur de connexion

### ✅ SETUP_CHECKLIST.md
- Checklist de configuration complète (6 phases)
- Test de chaque étape
- Commandes à exécuter
- Troubleshooting pour chaque erreur

**À utiliser si :**
- Tu veux être sûr que tout fonctionne
- Tu dois vérifier ta configuration
- Tu veux une vue d'ensemble

---

## 📊 FICHIERS DE MODÉLISATION

### 📐 MERISE_MODEL.md
- **MCD** : Modèle conceptuel avec diagrammes
- **MLD** : Modèle logique avec attributs détaillés
- **MPD** : Modèle physique SQL
- Règles métier intégrées (10 points vérifiés)
- Exemples de requêtes
- Cycle de vie fiche de frais
- Diagramme global

**À utiliser pour :**
- Comprendre la structure DB
- Développer les modèles C#
- Vérifier les relations
- Implémenter la logique métier

---

## 💾 FICHIERS SQL

### 🗄️ gsb_schema.sql (600+ lignes)
- Script SQL complet et prêt à l'emploi
- Création base `gsb_app`
- Création 6 tables avec :
  - Clés primaires et étrangères
  - Types ENUM appropriés
  - Indices pour performance
  - Timestamps automatiques
  - Contraintes d'unicité
- Données d'exemple (20+ enregistrements)
- Vérification finale avec statistiques

**À utiliser :**
1. Via phpMyAdmin (Importer)
2. Via command line (mysql < gsb_schema.sql)

### 📋 COMMON_QUERIES.sql
- **50+ requêtes SQL prêtes à l'emploi** dans 9 catégories :
  1. Gestion utilisateurs
  2. Gestion fiches
  3. Lignes forfait
  4. Lignes hors forfait
  5. Calculs montants
  6. Rapports et stats
  7. Traçabilité/historique
  8. Maintenance
  9. Export données

**À utiliser pour :**
- Faire des requêtes complexes
- Générer des rapports
- Copier-coller directement
- Apprendre la syntaxe SQL

---

## 🛠️ FICHIERS INTÉGRATION .NET

### 📝 EF_CORE_INTEGRATION.md
- Installation packages NuGet (Pomelo)
- Configuration appsettings.json
- Créer les 6 modèles (code complet) :
  - Utilisateur.cs
  - TypeFrais.cs
  - FicheFrais.cs
  - LigneFraisForfait.cs
  - LigneFraisHorsForfait.cs
  - HistoriqueEtat.cs
- DbContext configuration
- Program.cs setup
- Exemple Repository Pattern
- Tests de connexion
- Troubleshooting

**À utiliser :**
1. Pour créer les modèles EF Core
2. Pour configurer DbContext
3. Pour implémenter services

**Code prêt à copier-coller inclus ! ✓**

---

## 🧹 FICHIERS MAINTENANCE

### 🔄 MAINTENANCE.md
- Réinitialiser la base (2 méthodes)
- Nettoyer les données
- Vérifier l'intégrité
- Gérer les utilisateurs
- Statistiques et rapports
- Sauvegarde/restauration
- Automatiser les backups
- Modification de schéma
- Checklist mensuelle
- Problèmes courants + solutions

**À utiliser pour :**
- Nettoyer/réinitialiser
- Sauvegarder
- Vérifier la santé
- Troubleshooting avancé

---

## 📚 AUTRES FICHIERS

### README.md (racine projet)
- Vue d'ensemble GSB
- Technologies utilisées
- Structure du projet
- Démarrage rapide
- Modélisation données
- Rôles et droits
- Liens vers documentation
- Troubleshooting général
- Ressources externes

### README.md (Database/)
- Overview du dossier Database
- Structure des 7 fichiers
- Démarrage rapide en 3 étapes
- Descriptions courtes de chaque fichier
- Données de test
- Configuration .NET
- Vérification de santé

### SETUP_CHECKLIST.md
- Checklist détaillée (section ci-dessus)

---

## 🗺️ NAVIGATION RAPIDE

### Je cherche comment...

| Question | Fichier | Section |
|----------|---------|---------|
| Configurer WAMP ? | WAMP_CONFIG_GUIDE.md | Étape 1 |
| Importer la BDD ? | WAMP_CONFIG_GUIDE.md | Étape 2 |
| Créer les modèles C# ? | EF_CORE_INTEGRATION.md | Étape 3 |
| Faire une requête SQL ? | COMMON_QUERIES.sql | Toutes |
| Comprendre le schéma ? | MERISE_MODEL.md | MCD/MLD/MPD |
| Sauvegarder la BDD ? | MAINTENANCE.md | Sauvegarde |
| Supprimer la BDD ? | MAINTENANCE.md | Réinitialiser |
| Déboguer une erreur ? | SETUP_CHECKLIST.md | Phase 5 |
| Voir les données test ? | START_HERE.md | Données test |

---

## 📖 GUIDE DE LECTURE RECOMMANDÉ

### 1️⃣ Première découverte
1. START_HERE.md (5 min)
2. README.md racine (10 min)
3. Database/README.md (5 min)

### 2️⃣ Configuration
1. WAMP_CONFIG_GUIDE.md (15 min)
2. Importer gsb_schema.sql
3. SETUP_CHECKLIST.md (vérifier)

### 3️⃣ Développement
1. MERISE_MODEL.md (comprendre structure)
2. EF_CORE_INTEGRATION.md (créer modèles)
3. COMMON_QUERIES.sql (référence SQL)

### 4️⃣ Maintenance
1. MAINTENANCE.md (bookmarker pour plus tard)
2. SETUP_CHECKLIST.md (santé mensuelle)

---

## 🎯 FICHIERS PAR RÔLE

### Je suis débutant
- Commence par : START_HERE.md
- Puis : WAMP_CONFIG_GUIDE.md
- Ensuite : MERISE_MODEL.md
- Enfin : EF_CORE_INTEGRATION.md

### Je suis développeur backend
- Va voir : EF_CORE_INTEGRATION.md
- Consulte : COMMON_QUERIES.sql
- Réfère-toi à : MERISE_MODEL.md

### Je suis DBA/Admin
- Priorité : MAINTENANCE.md
- Reference : gsb_schema.sql
- Consulte : COMMON_QUERIES.sql

### Je suis architecte
- Vue d'ensemble : MERISE_MODEL.md
- Details : EF_CORE_INTEGRATION.md
- Standards : SETUP_CHECKLIST.md

---

## 📊 RÉSUMÉ DES 8 FICHIERS

```
Database/
│
├── 📄 START_HERE.md ..................... Guide 5 min (COMMENCE ICI)
├── 📄 README.md ......................... Overview du dossier Database
├── 📄 SETUP_CHECKLIST.md ................ Checklist configuration complète
│
├── 🔧 Configuration WAMP & Import
│   └── 📄 WAMP_CONFIG_GUIDE.md .......... Guide pas-à-pas WAMP + Import
│
├── 📊 Modélisation
│   └── 📄 MERISE_MODEL.md .............. MCD/MLD/MPD + règles métier
│
├── 💾 Fichiers SQL
│   ├── 📄 gsb_schema.sql ............... Script d'installation (600+ lignes)
│   └── 📄 COMMON_QUERIES.sql ........... 50+ requêtes prêtes à l'emploi
│
├── 🛠️ Intégration .NET
│   └── 📄 EF_CORE_INTEGRATION.md ....... Modèles + DbContext + code
│
└── 🧹 Maintenance
    └── 📄 MAINTENANCE.md ............... Sauvegardes + troubleshooting
```

---

## ✨ POINTS CLÉS À RETENIR

1. **START_HERE.md** = Ton point de départ (5 min)
2. **gsb_schema.sql** = À importer dans WAMP
3. **MERISE_MODEL.md** = Comprendre l'architecture
4. **EF_CORE_INTEGRATION.md** = Intégrer à .NET
5. **COMMON_QUERIES.sql** = Requêtes prêtes à l'emploi

---

## 🚀 TU ES PRÊT !

1. Ouvre : **START_HERE.md**
2. Suis les 5 étapes
3. Tu es prêt à coder !

---

**Bon courage ! 💪**

Questions ? → Checklist → README → Documentation
