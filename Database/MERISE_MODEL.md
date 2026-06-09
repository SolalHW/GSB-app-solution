# 📐 Modélisation MERISE - GSB

## 🎯 Vue d'ensemble

Ce document représente le modèle de données complet pour l'application GSB (Gestion des Fiches de Frais) en suivant la démarche MERISE : **MCD → MLD → MPD**.

---

# 🧱 **1. MCD (Modèle Conceptuel de Données)**

Le MCD représente les **entités**, **associations** et **cardinalités** de manière conceptuelle, indépendante de toute technologie.

## 🧩 Entités principales

### **UTILISATEUR**
- Personne utilisant l'application
- Peut avoir un rôle : ADMIN, VISITEUR, COMPTABLE
- Propriétaire des fiches de frais

### **FICHE_FRAIS**
- Regroupe les frais d'une personne pour un mois
- États possibles : EN_COURS, EN_ATTENTE, VALIDEE, REFUSEE, REMBOURSEE

### **TYPE_FRAIS**
- Catégorie de frais (ex: repas, nuitée, transport)
- Peut être FORFAIT ou HORS_FORFAIT
- Associé à un tarif

### **LIGNE_FRAIS_FORFAIT**
- Détail d'un frais forfaitaire dans une fiche
- Comprend une quantité et un tarif unitaire

### **LIGNE_FRAIS_HORS_FORFAIT**
- Détail d'un frais hors forfait (libre)
- Comprend un montant, une description et optionnellement un justificatif

---

## 🔗 Associations et cardinalités

```
┌──────────────────┐                    ┌──────────────────┐
│   UTILISATEUR    │                    │   FICHE_FRAIS    │
│ (idUtilisateur)  │                    │  (idFiche)       │
└──────────────────┘                    └──────────────────┘
        │                                        │
        │ (1,n)                                  │
        │  possède                               │
        └────────────────────────────────────────┘
                          (1,1)
```
**Cardinalité :** 
- Un UTILISATEUR **possède** plusieurs FICHES_FRAIS (1,n)
- Une FICHE_FRAIS **appartient à** un seul UTILISATEUR (1,1)
- **Règle** : Un utilisateur ne peut avoir qu'une seule fiche par mois


```
┌──────────────────┐              ┌──────────────────────────────┐
│   FICHE_FRAIS    │              │  LIGNE_FRAIS_FORFAIT         │
│  (idFiche)       │              │  (idLFF)                     │
└──────────────────┘              └──────────────────────────────┘
        │                                     │
        │ (1,n)                               │
        │  contient                           │
        └─────────────────────────────────────┘
                      (1,1)
```
**Cardinalité :**
- Une FICHE_FRAIS **contient** 0 à n LIGNES_FRAIS_FORFAIT (1,n)
- Une LIGNE_FRAIS_FORFAIT **appartient à** une seule FICHE_FRAIS (1,1)


```
┌──────────────────┐              ┌──────────────────────────────┐
│   FICHE_FRAIS    │              │  LIGNE_FRAIS_HORS_FORFAIT    │
│  (idFiche)       │              │  (idLHFF)                    │
└──────────────────┘              └──────────────────────────────┘
        │                                     │
        │ (1,n)                               │
        │  contient                           │
        └─────────────────────────────────────┘
                      (1,1)
```
**Cardinalité :**
- Une FICHE_FRAIS **contient** 0 à n LIGNES_FRAIS_HORS_FORFAIT (1,n)
- Une LIGNE_FRAIS_HORS_FORFAIT **appartient à** une seule FICHE_FRAIS (1,1)


```
┌──────────────────┐              ┌──────────────────────────────┐
│   TYPE_FRAIS     │              │  LIGNE_FRAIS_FORFAIT         │
│ (idTypeFrais)    │              │  (idLFF)                     │
└──────────────────┘              └──────────────────────────────┘
        │                                     │
        │ (1,n)                               │
        │  définit                            │
        └─────────────────────────────────────┘
                      (0,n)
```
**Cardinalité :**
- Un TYPE_FRAIS **peut être utilisé** dans plusieurs LIGNES_FRAIS_FORFAIT (1,n)
- Une LIGNE_FRAIS_FORFAIT **correspond à** un seul TYPE_FRAIS (0,n)

---

# 🧠 **2. MLD (Modèle Logique de Données)**

Le MLD traduit le MCD en **tables relationnelles** avec clés primaires et étrangères.

## 📌 **Relation UTILISATEUR**

| Attribut | Type | Contrainte |
|----------|------|-----------|
| **idUtilisateur** | INT | PK, AUTO_INCREMENT |
| nom | VARCHAR(50) | NOT NULL |
| prenom | VARCHAR(50) | NOT NULL |
| login | VARCHAR(50) | UNIQUE, NOT NULL |
| mdpHash | VARCHAR(255) | NOT NULL |
| role | ENUM | NOT NULL, valeurs : ADMIN / VISITEUR / COMPTABLE |
| dateCreation | TIMESTAMP | NOT NULL, DEFAULT CURRENT_TIMESTAMP |
| actif | BOOLEAN | DEFAULT TRUE |

**Identifiant :** `idUtilisateur`

---

## 📌 **Relation FICHE_FRAIS**

| Attribut | Type | Contrainte |
|----------|------|-----------|
| **idFiche** | INT | PK, AUTO_INCREMENT |
| mois | CHAR(6) | NOT NULL, Format YYYYMM |
| etat | ENUM | NOT NULL, valeurs : EN_COURS / EN_ATTENTE / VALIDEE / REFUSEE / REMBOURSEE |
| **idUtilisateur** | INT | FK → UTILISATEUR.idUtilisateur |
| montantTotal | DECIMAL(10,2) | DEFAULT 0 |
| dateSoumission | DATETIME | Null par défaut |
| dateValidation | DATETIME | Null par défaut |
| remarques | TEXT | Null par défaut |
| dateCreation | TIMESTAMP | NOT NULL, DEFAULT CURRENT_TIMESTAMP |

**Identifiant :** `idFiche`
**Contrainte d'unicité :** (idUtilisateur, mois) - un utilisateur ne peut avoir qu'une fiche par mois

---

## 📌 **Relation TYPE_FRAIS**

| Attribut | Type | Contrainte |
|----------|------|-----------|
| **idTypeFrais** | INT | PK, AUTO_INCREMENT |
| libelle | VARCHAR(100) | NOT NULL |
| tarif | DECIMAL(10,2) | NOT NULL |
| type | ENUM | NOT NULL, valeurs : FORFAIT / HORS_FORFAIT |
| description | TEXT | Null par défaut |
| actif | BOOLEAN | DEFAULT TRUE |
| dateCreation | TIMESTAMP | NOT NULL |

**Identifiant :** `idTypeFrais`

---

## 📌 **Relation LIGNE_FRAIS_FORFAIT**

| Attribut | Type | Contrainte |
|----------|------|-----------|
| **idLFF** | INT | PK, AUTO_INCREMENT |
| quantite | INT | NOT NULL, DEFAULT 1 |
| montantUnitaire | DECIMAL(10,2) | NOT NULL |
| montantTotal | DECIMAL(10,2) | GENERATED (quantite × montantUnitaire) |
| **idFiche** | INT | FK → FICHE_FRAIS.idFiche (CASCADE DELETE) |
| **idTypeFrais** | INT | FK → TYPE_FRAIS.idTypeFrais |
| dateCreation | TIMESTAMP | NOT NULL |

**Identifiant :** `idLFF`
**Identifiant composé possible :** (idFiche, idTypeFrais)

---

## 📌 **Relation LIGNE_FRAIS_HORS_FORFAIT**

| Attribut | Type | Contrainte |
|----------|------|-----------|
| **idLHFF** | INT | PK, AUTO_INCREMENT |
| libelle | VARCHAR(255) | NOT NULL |
| montant | DECIMAL(10,2) | NOT NULL |
| justificatif | VARCHAR(255) | Null par défaut (chemin fichier) |
| dateEngagement | DATE | NOT NULL |
| **idFiche** | INT | FK → FICHE_FRAIS.idFiche (CASCADE DELETE) |
| dateCreation | TIMESTAMP | NOT NULL |

**Identifiant :** `idLHFF`

---

## 📌 **Relation HISTORIQUE_ETAT** (Table de traçabilité)

| Attribut | Type | Contrainte |
|----------|------|-----------|
| **idHistorique** | INT | PK, AUTO_INCREMENT |
| **idFiche** | INT | FK → FICHE_FRAIS.idFiche (CASCADE DELETE) |
| etatPrecedent | ENUM | Null possible (première création) |
| etatNouveau | ENUM | NOT NULL |
| **idUtilisateurModification** | INT | FK → UTILISATEUR.idUtilisateur |
| dateModification | TIMESTAMP | NOT NULL, DEFAULT CURRENT_TIMESTAMP |
| commentaire | TEXT | Null par défaut |

**Identifiant :** `idHistorique`

---

# 🗄️ **3. MPD (Modèle Physique de Données – SQL)**

Le MPD est l'implémentation physique en MariaDB/MySQL.

Voir le fichier **`gsb_schema.sql`** pour le script SQL complet et exécutable.

---

# 🎯 **4. Règles Métier Intégrées**

✅ **Règle 1** : Un visiteur peut créer plusieurs fiches de frais
- Implémenté : Clé étrangère `idUtilisateur` dans FICHE_FRAIS avec cardinalité (1,n)

✅ **Règle 2** : Une fiche appartient toujours à un seul utilisateur
- Implémenté : Unicité de la combinaison (idUtilisateur, mois)

✅ **Règle 3** : Une fiche peut contenir plusieurs lignes forfaitaires ou hors forfait
- Implémenté : Tables LIGNE_FRAIS_FORFAIT et LIGNE_FRAIS_HORS_FORFAIT avec clé étrangère vers FICHE_FRAIS

✅ **Règle 4** : Les tarifs des frais forfaitaires sont définis dans TYPE_FRAIS
- Implémenté : Référence à idTypeFrais dans LIGNE_FRAIS_FORFAIT

✅ **Règle 5** : Les frais hors forfait sont libres en montant
- Implémenté : Champ `montant` libre dans LIGNE_FRAIS_HORS_FORFAIT

✅ **Règle 6** : Les justificatifs ne s'appliquent qu'aux frais hors forfait
- Implémenté : Seule LIGNE_FRAIS_HORS_FORFAIT a le champ `justificatif`

✅ **Règle 7** : Les états de fiche sont strictement contrôlés
- Implémenté : Utilisation d'ENUM avec valeurs limitées

✅ **Règle 8** : Historique des changements d'état
- Implémenté : Table HISTORIQUE_ETAT

✅ **Règle 9** : Suppression en cascade
- Implémenté : Suppression d'une fiche supprime ses lignes associées

✅ **Règle 10** : Montant total calculé automatiquement
- Implémenté : Colonne GENERATED pour LIGNE_FRAIS_FORFAIT

---

# 📊 Diagramme Global

```
            ┌────────────────────┐
            │   UTILISATEUR      │
            │ (Gère les fiches)  │
            └────────┬───────────┘
                     │ (1,n)
                     │ possède
                     │
            ┌────────▼───────────┐
            │  FICHE_FRAIS       │
            │ (Mois, Etat)       │
            └────┬────────────┬──┘
            (1,n)│            │(1,n)
    contient     │            │    contient
                 │            │
        ┌────────▼──┐   ┌─────▼──────────────┐
        │LIGNE_FRAIS│   │LIGNE_FRAIS_        │
        │_FORFAIT   │   │HORS_FORFAIT        │
        │(Quantité) │   │(Montant libre)     │
        └─────┬─────┘   └────────────────────┘
              │ (n,1)
              │ de type
              │
        ┌─────▼────────────┐
        │  TYPE_FRAIS      │
        │ (Repas, Nuitée)  │
        └──────────────────┘
```

---

# 📝 Exemples de Requêtes Courantes

### Obtenir toutes les fiches d'un utilisateur pour un mois
```sql
SELECT ff.*, u.nom, u.prenom
FROM fiche_frais ff
JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
WHERE u.idUtilisateur = ? AND ff.mois = ?;
```

### Calculer le montant total d'une fiche (forfait + hors forfait)
```sql
SELECT 
  (SELECT COALESCE(SUM(montantTotal), 0) 
   FROM ligne_frais_forfait 
   WHERE idFiche = ?) +
  (SELECT COALESCE(SUM(montant), 0) 
   FROM ligne_frais_hors_forfait 
   WHERE idFiche = ?) as total;
```

### Lister les fiches en attente de validation
```sql
SELECT ff.*, u.nom, u.prenom, COUNT(lff.idLFF) as nb_forfait, COUNT(lfhf.idLHFF) as nb_hors_forfait
FROM fiche_frais ff
JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
LEFT JOIN ligne_frais_forfait lff ON ff.idFiche = lff.idFiche
LEFT JOIN ligne_frais_hors_forfait lfhf ON ff.idFiche = lfhf.idFiche
WHERE ff.etat = 'EN_ATTENTE'
GROUP BY ff.idFiche;
```

---

# 🔄 Cycle de Vie d'une Fiche de Frais

```
EN_COURS (création)
    ↓
    ├─→ EN_ATTENTE (soumission)
    │       ↓
    │       ├─→ VALIDEE (approbation comptable)
    │       │       ↓
    │       │    REMBOURSEE (paiement)
    │       │
    │       └─→ REFUSEE (rejet)
    │
    └─→ [Modification et résoumission possible]
```

---

# 📋 Résumé des Tables

| Table | Enregistrements | Clé Primaire | Clés Étrangères |
|-------|-----------------|--------------|-----------------|
| UTILISATEUR | ~ 5-1000 | idUtilisateur | Aucune |
| TYPE_FRAIS | ~ 4-10 | idTypeFrais | Aucune |
| FICHE_FRAIS | ~ 100-10000 | idFiche | idUtilisateur |
| LIGNE_FRAIS_FORFAIT | ~ 1000-100000 | idLFF | idFiche, idTypeFrais |
| LIGNE_FRAIS_HORS_FORFAIT | ~ 500-50000 | idLHFF | idFiche |
| HISTORIQUE_ETAT | ~ 500-100000 | idHistorique | idFiche, idUtilisateurModification |

---

# 🔒 Considérations de Sécurité

- ✅ Validation des rôles (ENUM)
- ✅ Hachage des mots de passe (mdpHash)
- ✅ Traçabilité via HISTORIQUE_ETAT
- ✅ Timestamps automatiques (dateCreation, dateModification)
- ✅ Suppression en cascade sécurisée
- ✅ Indices pour performance (idx_login, idx_role, idx_etat, idx_mois)

---

# 📚 Prochaines Étapes

1. ✅ Importer le schéma SQL (voir `WAMP_CONFIG_GUIDE.md`)
2. ⏳ Créer les modèles Entity Framework Core en C#
3. ⏳ Implémenter les services de gestion des fiches
4. ⏳ Développer les contrôleurs et vues
5. ⏳ Mettre en place les authentifications et autorisations

---

Modélisation complète et valide selon la méthode MERISE. ✨
