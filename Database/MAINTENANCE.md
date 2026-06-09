# 🔄 Guide de Maintenance - Base de Données GSB

Ce document décrit les tâches courantes de maintenance de la base de données.

---

## 🆘 Réinitialiser la base de données (Complètement)

**⚠️ ATTENTION : Cette opération supprime TOUTES les données !**

### Via phpMyAdmin

1. Se connecter à http://localhost/phpmyadmin
2. Cliquer sur la base `gsb_app` dans la liste
3. Onglet **"Opérations"** en haut
4. Bouton **"Supprimer la base"**
5. Confirmer
6. Réimporter `gsb_schema.sql`

### Via Command Line

```bash
mysql -u root -p
DROP DATABASE gsb_app;
-- Puis ré-exécuter gsb_schema.sql
```

---

## 🧹 Nettoyer les données (Conserver la structure)

Supprimer tous les enregistrements tout en gardant les tables :

```sql
USE gsb_app;

-- Supprimer tous les enregistrements (en respectant les FK)
SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE historique_etat;
TRUNCATE TABLE ligne_frais_hors_forfait;
TRUNCATE TABLE ligne_frais_forfait;
TRUNCATE TABLE fiche_frais;
TRUNCATE TABLE type_frais;
TRUNCATE TABLE utilisateur;
SET FOREIGN_KEY_CHECKS = 1;

-- Réinitialiser les AUTO_INCREMENT
ALTER TABLE utilisateur AUTO_INCREMENT = 1;
ALTER TABLE type_frais AUTO_INCREMENT = 1;
ALTER TABLE fiche_frais AUTO_INCREMENT = 1;
ALTER TABLE ligne_frais_forfait AUTO_INCREMENT = 1;
ALTER TABLE ligne_frais_hors_forfait AUTO_INCREMENT = 1;
ALTER TABLE historique_etat AUTO_INCREMENT = 1;
```

---

## 📊 Vérifier l'intégrité de la base

### Vérification complète

```sql
-- Voir le nombre d'enregistrements par table
SELECT 
    'Utilisateurs' as 'Table', COUNT(*) as 'Nombre'
FROM utilisateur
UNION ALL
SELECT 'Types de Frais', COUNT(*) FROM type_frais
UNION ALL
SELECT 'Fiches de Frais', COUNT(*) FROM fiche_frais
UNION ALL
SELECT 'Lignes Forfait', COUNT(*) FROM ligne_frais_forfait
UNION ALL
SELECT 'Lignes Hors Forfait', COUNT(*) FROM ligne_frais_hors_forfait
UNION ALL
SELECT 'Historiques', COUNT(*) FROM historique_etat;
```

### Vérifier les orphelins (FK non correspondantes)

```sql
-- Fiches sans utilisateur (ne devrait jamais arriver)
SELECT ff.idFiche
FROM fiche_frais ff
LEFT JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
WHERE u.idUtilisateur IS NULL;

-- Lignes forfait avec type inexistant
SELECT lff.idLFF
FROM ligne_frais_forfait lff
LEFT JOIN type_frais tf ON lff.idTypeFrais = tf.idTypeFrais
WHERE tf.idTypeFrais IS NULL;
```

---

## 🔐 Gestion des utilisateurs

### Créer un nouvel utilisateur

```sql
INSERT INTO utilisateur (nom, prenom, login, mdpHash, role, actif)
VALUES ('Dupont', 'Jean', 'jdupont2', SHA2('password123', 256), 'VISITEUR', TRUE);
```

### Changer le mot de passe d'un utilisateur

```sql
UPDATE utilisateur
SET mdpHash = SHA2('nouveau_mot_de_passe', 256)
WHERE login = 'jdupont';
```

### Désactiver un utilisateur (au lieu de supprimer)

```sql
UPDATE utilisateur
SET actif = FALSE
WHERE idUtilisateur = 1;
```

### Afficher tous les utilisateurs

```sql
SELECT idUtilisateur, CONCAT(prenom, ' ', nom) as 'Nom Complet', 
       login, role, actif, dateCreation
FROM utilisateur
ORDER BY nom, prenom;
```

---

## 📈 Statistiques et Rapports

### Montant total par mois

```sql
SELECT 
    ff.mois,
    COUNT(DISTINCT ff.idUtilisateur) as 'Nombre d\'utilisateurs',
    SUM(
        (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait lff WHERE lff.idFiche = ff.idFiche) +
        (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait lfhf WHERE lfhf.idFiche = ff.idFiche)
    ) as 'Montant Total'
FROM fiche_frais ff
GROUP BY ff.mois
ORDER BY ff.mois DESC;
```

### Fiches par état

```sql
SELECT etat, COUNT(*) as 'Nombre', 
       COUNT(CASE WHEN etat = 'EN_COURS' THEN 1 END) as 'En Cours',
       COUNT(CASE WHEN etat = 'EN_ATTENTE' THEN 1 END) as 'En Attente',
       COUNT(CASE WHEN etat = 'VALIDEE' THEN 1 END) as 'Validée',
       COUNT(CASE WHEN etat = 'REFUSEE' THEN 1 END) as 'Refusée',
       COUNT(CASE WHEN etat = 'REMBOURSEE' THEN 1 END) as 'Remboursée'
FROM fiche_frais
GROUP BY etat;
```

### Utilisateur avec le plus de fiches

```sql
SELECT u.idUtilisateur, CONCAT(u.prenom, ' ', u.nom) as 'Utilisateur',
       COUNT(ff.idFiche) as 'Nombre de Fiches',
       SUM(
           (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait lff WHERE lff.idFiche = ff.idFiche) +
           (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait lfhf WHERE lfhf.idFiche = ff.idFiche)
       ) as 'Montant Total'
FROM utilisateur u
LEFT JOIN fiche_frais ff ON u.idUtilisateur = ff.idUtilisateur
GROUP BY u.idUtilisateur
ORDER BY COUNT(ff.idFiche) DESC
LIMIT 10;
```

---

## 💾 Sauvegarde et Restauration

### Sauvegarder la base

```bash
# Via mysqldump
mysqldump -u root -p gsb_app > backup_gsb_app.sql

# Via WAMP (Menu Outils)
# Ou via phpMyAdmin (Export)
```

### Restaurer à partir d'une sauvegarde

```bash
mysql -u root -p gsb_app < backup_gsb_app.sql
```

### Automatiser les sauvegardes (Script batch Windows)

Créer `backup_gsb.bat` :

```batch
@echo off
setlocal enabledelayedexpansion

REM Variables
set BACKUP_DIR=C:\Backups\GSB
set DATE=%date:~10,4%%date:~4,2%%date:~7,2%
set BACKUP_FILE=%BACKUP_DIR%\gsb_app_backup_%DATE%.sql

REM Créer le répertoire s'il n'existe pas
if not exist "%BACKUP_DIR%" mkdir "%BACKUP_DIR%"

REM Sauvegarder
"C:\wamp64\bin\mysql\mysql8.0.28\bin\mysqldump" -u root gsb_app > "%BACKUP_FILE%"

echo Sauvegarde créée : %BACKUP_FILE%
pause
```

---

## 🔄 Mise à jour de schéma

### Ajouter une nouvelle colonne

```sql
ALTER TABLE utilisateur
ADD COLUMN telephone VARCHAR(20) AFTER prenom;
```

### Supprimer une colonne

```sql
ALTER TABLE utilisateur
DROP COLUMN telephone;
```

### Modifier un type de colonne

```sql
ALTER TABLE fiche_frais
MODIFY COLUMN montantTotal DECIMAL(12,2);
```

### Ajouter une contrainte unique

```sql
ALTER TABLE utilisateur
ADD UNIQUE KEY `unique_email` (`email`);
```

---

## 📋 Checklist de maintenance mensuelle

- [ ] Exécuter la vérification d'intégrité
- [ ] Archiver les fiches anciennes (+ 1 an)
- [ ] Vérifier les orphelins (FK non correspondantes)
- [ ] Faire une sauvegarde
- [ ] Nettoyer les fichiers justificatifs supprimés
- [ ] Vérifier les performances (index, requêtes lentes)
- [ ] Mettre à jour les statistiques

---

## 🚨 Problèmes courants et solutions

### Problème : "Disk full"

```sql
-- Voir la taille des tables
SELECT 
    TABLE_NAME,
    ROUND(((DATA_LENGTH + INDEX_LENGTH) / 1024 / 1024), 2) AS 'Size (MB)'
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = 'gsb_app'
ORDER BY DATA_LENGTH DESC;

-- Optimiser les tables
OPTIMIZE TABLE utilisateur, fiche_frais, ligne_frais_forfait, ligne_frais_hors_forfait;
```

### Problème : "Slow queries"

```sql
-- Activer le slow query log
SET GLOBAL slow_query_log = 'ON';
SET GLOBAL long_query_time = 2; -- Requêtes > 2 secondes

-- Vérifier les index
SHOW INDEX FROM fiche_frais;

-- Ajouter un index si manquant
CREATE INDEX idx_utilisateur_mois ON fiche_frais(idUtilisateur, mois);
```

### Problème : "Lock tables"

```sql
-- Voir les tables verrouillées
SHOW OPEN TABLES WHERE In_use > 0;

-- Libérer les verrous
UNLOCK TABLES;
```

---

## 📞 Contact Support

- **WAMP Issues** : [wampserver.com/phorum](https://wampserver.com/phorum/)
- **MariaDB Support** : [mariadb.org/support](https://mariadb.org/support/)
- **phpMyAdmin Help** : Help inside phpMyAdmin

---

**Version** : 1.0
**Dernière mise à jour** : 2024
