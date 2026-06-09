-- ============================================================================
-- REQUÊTES COURANTES - GSB
-- Exemples de requêtes SQL pour manipuler les données
-- ============================================================================

USE `gsb_app`;

-- ============================================================================
-- 1. GESTION DES UTILISATEURS
-- ============================================================================

-- Voir tous les utilisateurs actifs
SELECT idUtilisateur, CONCAT(prenom, ' ', nom) as 'Nom', login, role, actif
FROM utilisateur
WHERE actif = TRUE
ORDER BY nom, prenom;

-- Désactiver un utilisateur (au lieu de supprimer)
UPDATE utilisateur
SET actif = FALSE, dateModification = NOW()
WHERE idUtilisateur = 1;

-- Changer le rôle d'un utilisateur
UPDATE utilisateur
SET role = 'COMPTABLE', dateModification = NOW()
WHERE idUtilisateur = 3;

-- Compter les utilisateurs par rôle
SELECT role, COUNT(*) as 'Nombre'
FROM utilisateur
WHERE actif = TRUE
GROUP BY role;

-- ============================================================================
-- 2. GESTION DES FICHES DE FRAIS
-- ============================================================================

-- Voir toutes les fiches d'un utilisateur
SELECT ff.idFiche, ff.mois, ff.etat, ff.montantTotal, ff.dateSoumission
FROM fiche_frais ff
WHERE ff.idUtilisateur = 1
ORDER BY ff.mois DESC;

-- Voir les fiches en cours de validation (EN_ATTENTE)
SELECT ff.idFiche, CONCAT(u.prenom, ' ', u.nom) as 'Utilisateur', 
       ff.mois, ff.montantTotal, ff.dateSoumission
FROM fiche_frais ff
JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
WHERE ff.etat = 'EN_ATTENTE'
ORDER BY ff.dateSoumission ASC;

-- Compter les fiches par état
SELECT etat, COUNT(*) as 'Nombre'
FROM fiche_frais
GROUP BY etat;

-- Voir les fiches d'un mois spécifique
SELECT ff.idFiche, CONCAT(u.prenom, ' ', u.nom) as 'Utilisateur', 
       ff.etat, ff.montantTotal
FROM fiche_frais ff
JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
WHERE ff.mois = '202401'
ORDER BY u.nom;

-- Créer une nouvelle fiche (EN_COURS)
INSERT INTO fiche_frais (mois, etat, idUtilisateur, montantTotal)
VALUES ('202406', 'EN_COURS', 1, 0.00);

-- Soumettre une fiche (passer à EN_ATTENTE)
UPDATE fiche_frais
SET etat = 'EN_ATTENTE', dateSoumission = NOW(), dateModification = NOW()
WHERE idFiche = 1 AND etat = 'EN_COURS';

-- Valider une fiche
UPDATE fiche_frais
SET etat = 'VALIDEE', dateValidation = NOW(), dateModification = NOW()
WHERE idFiche = 1 AND etat = 'EN_ATTENTE';

-- Ajouter un historique lors du changement d'état
INSERT INTO historique_etat (idFiche, etatPrecedent, etatNouveau, idUtilisateurModification, commentaire)
VALUES (1, 'EN_ATTENTE', 'VALIDEE', 3, 'Fiche validée par le comptable');

-- ============================================================================
-- 3. GESTION DES LIGNES DE FRAIS FORFAITAIRES
-- ============================================================================

-- Ajouter une ligne de frais forfait
INSERT INTO ligne_frais_forfait (quantite, montantUnitaire, idFiche, idTypeFrais)
SELECT 2, tf.tarif, 1, tf.idTypeFrais
FROM type_frais tf
WHERE tf.libelle = 'Repas midi' AND tf.type = 'FORFAIT';

-- Voir toutes les lignes forfait d'une fiche
SELECT lff.idLFF, tf.libelle, lff.quantite, lff.montantUnitaire, lff.montantTotal
FROM ligne_frais_forfait lff
JOIN type_frais tf ON lff.idTypeFrais = tf.idTypeFrais
WHERE lff.idFiche = 1
ORDER BY tf.libelle;

-- Récapitulatif forfait par type de frais (pour une fiche)
SELECT tf.libelle, 
       SUM(lff.quantite) as 'Total Quantité',
       tf.tarif as 'Tarif Unitaire',
       SUM(lff.montantTotal) as 'Montant Total'
FROM ligne_frais_forfait lff
JOIN type_frais tf ON lff.idTypeFrais = tf.idTypeFrais
WHERE lff.idFiche = 1
GROUP BY lff.idTypeFrais, tf.libelle, tf.tarif
ORDER BY tf.libelle;

-- Supprimer une ligne de frais forfait
DELETE FROM ligne_frais_forfait
WHERE idLFF = 1;

-- Modifier la quantité d'une ligne
UPDATE ligne_frais_forfait
SET quantite = 3
WHERE idLFF = 1;

-- ============================================================================
-- 4. GESTION DES LIGNES DE FRAIS HORS FORFAIT
-- ============================================================================

-- Ajouter une ligne de frais hors forfait
INSERT INTO ligne_frais_hors_forfait (libelle, montant, dateEngagement, idFiche, justificatif)
VALUES ('Carburant - Déplacement Paris', 50.00, '2024-01-15', 1, 'justificatif_carburant.pdf');

-- Voir toutes les lignes hors forfait d'une fiche
SELECT idLHFF, libelle, montant, dateEngagement, justificatif
FROM ligne_frais_hors_forfait
WHERE idFiche = 1
ORDER BY dateEngagement DESC;

-- Montant total des frais hors forfait (par fiche)
SELECT SUM(montant) as 'Montant Total Hors Forfait'
FROM ligne_frais_hors_forfait
WHERE idFiche = 1;

-- Lister les frais hors forfait sans justificatif
SELECT idLHFF, libelle, montant, dateEngagement
FROM ligne_frais_hors_forfait
WHERE idFiche = 1 AND justificatif IS NULL;

-- Supprimer une ligne hors forfait
DELETE FROM ligne_frais_hors_forfait
WHERE idLHFF = 1;

-- Modifier un frais hors forfait
UPDATE ligne_frais_hors_forfait
SET libelle = 'Carburant (modifié)', montant = 45.50, dateModification = NOW()
WHERE idLHFF = 1;

-- ============================================================================
-- 5. CALCULS DE MONTANTS
-- ============================================================================

-- Montant total forfait d'une fiche
SELECT 
    COALESCE(SUM(lff.montantTotal), 0) as 'Montant Forfait'
FROM ligne_frais_forfait lff
WHERE lff.idFiche = 1;

-- Montant total hors forfait d'une fiche
SELECT 
    COALESCE(SUM(lfhf.montant), 0) as 'Montant Hors Forfait'
FROM ligne_frais_hors_forfait lfhf
WHERE lfhf.idFiche = 1;

-- Montant TOTAL d'une fiche (forfait + hors forfait)
SELECT 
    (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait WHERE idFiche = 1) +
    (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait WHERE idFiche = 1)
    as 'Montant Total Fiche';

-- Détail complet avec sous-totaux
SELECT 
    (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait WHERE idFiche = 1) as 'Sous-Total Forfait',
    (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait WHERE idFiche = 1) as 'Sous-Total Hors Forfait',
    (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait WHERE idFiche = 1) +
    (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait WHERE idFiche = 1) as 'Montant Total';

-- ============================================================================
-- 6. RAPPORTS ET STATISTIQUES
-- ============================================================================

-- Rapport mensuel : Montant par utilisateur et mois
SELECT 
    u.idUtilisateur,
    CONCAT(u.prenom, ' ', u.nom) as 'Utilisateur',
    ff.mois,
    ff.etat,
    (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait WHERE idFiche = ff.idFiche) as 'Forfait',
    (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait WHERE idFiche = ff.idFiche) as 'Hors Forfait',
    (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait WHERE idFiche = ff.idFiche) +
    (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait WHERE idFiche = ff.idFiche) as 'Total'
FROM fiche_frais ff
JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
ORDER BY u.nom, ff.mois DESC;

-- Total frais par type (tous les utilisateurs, tous les mois)
SELECT 
    tf.libelle,
    tf.type,
    SUM(lff.quantite) as 'Quantité Totale',
    SUM(lff.montantTotal) as 'Montant Total'
FROM ligne_frais_forfait lff
JOIN type_frais tf ON lff.idTypeFrais = tf.idTypeFrais
GROUP BY lff.idTypeFrais, tf.libelle, tf.type
ORDER BY tf.type, tf.libelle;

-- Montant moyen par fiche
SELECT 
    AVG(montant_total) as 'Montant Moyen',
    MIN(montant_total) as 'Montant Min',
    MAX(montant_total) as 'Montant Max'
FROM (
    SELECT 
        (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait lff WHERE lff.idFiche = ff.idFiche) +
        (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait lfhf WHERE lfhf.idFiche = ff.idFiche) as montant_total
    FROM fiche_frais ff
    WHERE ff.etat = 'VALIDEE'
) totals;

-- Utilisateurs avec plus de 10 fiches soumises
SELECT 
    u.idUtilisateur,
    CONCAT(u.prenom, ' ', u.nom) as 'Utilisateur',
    COUNT(ff.idFiche) as 'Nombre de Fiches'
FROM utilisateur u
JOIN fiche_frais ff ON u.idUtilisateur = ff.idUtilisateur
WHERE ff.etat IN ('EN_ATTENTE', 'VALIDEE', 'REMBOURSEE', 'REFUSEE')
GROUP BY u.idUtilisateur
HAVING COUNT(ff.idFiche) > 10
ORDER BY COUNT(ff.idFiche) DESC;

-- ============================================================================
-- 7. TRAÇABILITÉ - HISTORIQUE
-- ============================================================================

-- Voir l'historique complet d'une fiche
SELECT 
    he.idHistorique,
    he.etatPrecedent,
    he.etatNouveau,
    CONCAT(u.prenom, ' ', u.nom) as 'Modifié par',
    he.dateModification,
    he.commentaire
FROM historique_etat he
LEFT JOIN utilisateur u ON he.idUtilisateurModification = u.idUtilisateur
WHERE he.idFiche = 1
ORDER BY he.dateModification DESC;

-- Voir qui a validé/refusé les fiches
SELECT 
    he.idFiche,
    CONCAT(u.prenom, ' ', u.nom) as 'Validé/Refusé par',
    he.etatNouveau,
    he.dateModification,
    he.commentaire
FROM historique_etat he
JOIN utilisateur u ON he.idUtilisateurModification = u.idUtilisateur
WHERE he.etatNouveau IN ('VALIDEE', 'REFUSEE')
ORDER BY he.dateModification DESC;

-- ============================================================================
-- 8. MAINTENANCE ET NETTOYAGE
-- ============================================================================

-- Voir les fiches modifiées aujourd'hui
SELECT idFiche, mois, etat, dateModification
FROM fiche_frais
WHERE DATE(dateModification) = CURDATE()
ORDER BY dateModification DESC;

-- Compter les enregistrements
SELECT 
    (SELECT COUNT(*) FROM utilisateur) as 'Utilisateurs',
    (SELECT COUNT(*) FROM fiche_frais) as 'Fiches',
    (SELECT COUNT(*) FROM type_frais) as 'Types de Frais',
    (SELECT COUNT(*) FROM ligne_frais_forfait) as 'Lignes Forfait',
    (SELECT COUNT(*) FROM ligne_frais_hors_forfait) as 'Lignes Hors Forfait',
    (SELECT COUNT(*) FROM historique_etat) as 'Historiques';

-- Vérifier l'intégrité (orphelins - inutile normalement avec CASCADE DELETE)
SELECT ff.idFiche, ff.idUtilisateur
FROM fiche_frais ff
LEFT JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
WHERE u.idUtilisateur IS NULL;

-- ============================================================================
-- 9. EXPORT DONNÉES
-- ============================================================================

-- Exporter les fiches validées en CSV
SELECT 
    ff.idFiche,
    CONCAT(u.prenom, ' ', u.nom) as 'Utilisateur',
    ff.mois,
    ff.etat,
    (SELECT COALESCE(SUM(montantTotal), 0) FROM ligne_frais_forfait WHERE idFiche = ff.idFiche) as 'Forfait',
    (SELECT COALESCE(SUM(montant), 0) FROM ligne_frais_hors_forfait WHERE idFiche = ff.idFiche) as 'Hors Forfait',
    ff.montantTotal,
    ff.dateValidation
FROM fiche_frais ff
JOIN utilisateur u ON ff.idUtilisateur = u.idUtilisateur
WHERE ff.etat = 'VALIDEE'
INTO OUTFILE '/tmp/export_fiches_validees.csv'
FIELDS TERMINATED BY ';'
ENCLOSED BY '"'
LINES TERMINATED BY '\n';

-- ============================================================================
-- NOTES IMPORTANTES
-- ============================================================================
/*
- ATTENTION : Les montants sont automatiquement calculés pour les forfaits
- Les montants hors forfait doivent être saisis manuellement
- La suppression d'une fiche supprime automatiquement ses lignes (CASCADE)
- L'historique conserve la traçabilité complète des changements d'état
- Toujours vérifier l'existence d'utilisateur avant de créer une fiche
- Les dates sont au format : YYYY-MM-DD HH:MM:SS (pour DATETIME) ou YYYY-MM-DD (pour DATE)
*/
