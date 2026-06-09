# 🎯 GUIDE DE DÉMARRAGE RAPIDE - GSB

**Bienvenue! Voici comment configurer GSB en 5 minutes.**

---

## ⚡ ÉTAPE 1 : Vérifier WAMP (30 secondes)

1. Lancer WAMP Server (double-clic sur l'icône)
2. Attendre que tous les carrés soient **VERTS** ✓

→ Succès : WAMP est prêt !

---

## ⚡ ÉTAPE 2 : Importer la base de données (2 minutes)

1. Ouvrir navigateur → **http://localhost/phpmyadmin**
2. Entrer : `root` / (vide)
3. Cliquer sur onglet **"Importer"** en haut
4. Cliquer **"Choisir un fichier"** → `Database/gsb_schema.sql`
5. Cliquer **"Exécuter"** en bas

→ Succès : Base `gsb_app` créée avec 6 tables !

---

## ⚡ ÉTAPE 3 : Vérifier les données (1 minute)

Dans phpMyAdmin, exécuter :

```sql
USE gsb_app;
SHOW TABLES;
```

Résultat expected :
```
✓ utilisateur
✓ type_frais
✓ fiche_frais
✓ ligne_frais_forfait
✓ ligne_frais_hors_forfait
✓ historique_etat
```

→ Succès : Tout est créé !

---

## ⚡ ÉTAPE 4 : Configurer le projet .NET (1 minute)

### 4.1 Mettre à jour `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=root;database=gsb_app"
  }
}
```

### 4.2 Installer packages NuGet

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

## ⚡ ÉTAPE 5 : Lancer l'application (1 minute)

```bash
cd votre_projet
dotnet run
```

Ouvrir navigateur :

```
http://localhost:5000
```

→ Succès : Application lancée !

---

## ✅ Checklist Ultra-Rapide

- [ ] WAMP démarré (carrés verts)
- [ ] phpMyAdmin accessible (http://localhost/phpmyadmin)
- [ ] gsb_schema.sql importé
- [ ] Base gsb_app créée avec 6 tables
- [ ] appsettings.json configuré
- [ ] Packages NuGet installés
- [ ] Application lancée

Si tout est coché → **Tu es prêt ! 🎉**

---

## 📚 Documentation Complète

Si tu as besoin de plus de détails :

| Document | Contenu |
|----------|---------|
| **WAMP_CONFIG_GUIDE.md** | Guide détaillé pour WAMP |
| **MERISE_MODEL.md** | Modélisation de la base (MCD/MLD/MPD) |
| **COMMON_QUERIES.sql** | 50+ requêtes SQL prêtes à l'emploi |
| **EF_CORE_INTEGRATION.md** | Intégrer à l'app .NET |
| **MAINTENANCE.md** | Sauvegardes, nettoyage, troubleshooting |
| **SETUP_CHECKLIST.md** | Checklist complète détaillée |

---

## 🆘 Besoin d'aide ? (3 solutions)

### ❌ WAMP ne démarre pas
→ Voir : `WAMP_CONFIG_GUIDE.md` section "Troubleshooting"

### ❌ Import échoue
→ Voir : `WAMP_CONFIG_GUIDE.md` section "Importer le schéma"

### ❌ App ne démarre pas
→ Voir : `EF_CORE_INTEGRATION.md` section "Troubleshooting"

---

## 🎯 Prochaines étapes

1. Comprendre la structure : Lire `MERISE_MODEL.md`
2. Créer les modèles EF Core : Suivre `EF_CORE_INTEGRATION.md`
3. Développer les contrôleurs et vues
4. Ajouter l'authentification

---

## 📊 Données de test incluses

**Utilisateurs** (login / mot de passe) :
- jdupont
- mmartin
- pbernard (comptable)
- admin

**Types de frais** :
- Repas midi (16,50 €)
- Repas soir (25,00 €)
- Nuitée (50,00 €)
- Étapes/km (29,10 €)

---

**Prêt ? C'est parti ! 🚀**

```
1. Lancer WAMP → http://localhost/phpmyadmin
2. Importer Database/gsb_schema.sql
3. Configurer appsettings.json
4. dotnet run
5. Ouvrir http://localhost:5000
```

**C'est tout ! Enjoy ! ✨**
