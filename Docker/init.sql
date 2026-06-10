-- ============================================================
-- INITIALISATION BASE DE DONNÉES GSB FRAIS
-- MySQL 8.0 | UTF-8 | Docker
-- ============================================================

USE GSB_FRAIS;

-- ============================================================
-- TABLE: UTILISATEUR
-- ============================================================
CREATE TABLE IF NOT EXISTS UTILISATEUR (
    idUtilisateur INT AUTO_INCREMENT PRIMARY KEY COMMENT 'ID unique de l''utilisateur',
    nom VARCHAR(50) NOT NULL COMMENT 'Nom de famille',
    prenom VARCHAR(50) NOT NULL COMMENT 'Prénom',
    login VARCHAR(50) NOT NULL UNIQUE COMMENT 'Identifiant unique de connexion',
    mdpHash VARCHAR(255) NOT NULL COMMENT 'Mot de passe hashé (bcrypt)',
    role ENUM('ADMIN', 'VISITEUR', 'COMPTABLE') NOT NULL DEFAULT 'VISITEUR' COMMENT 'Rôle de l''utilisateur',
    dateCreation TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Date de création du compte',
    dateModification TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Date de dernière modification',
    actif BOOLEAN DEFAULT TRUE COMMENT 'Statut du compte'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Table des utilisateurs de l''application';

-- ============================================================
-- TABLE: TYPE_FRAIS
-- ============================================================
CREATE TABLE IF NOT EXISTS TYPE_FRAIS (
    idTypeFrais INT AUTO_INCREMENT PRIMARY KEY COMMENT 'ID unique du type de frais',
    libelle VARCHAR(100) NOT NULL COMMENT 'Libellé du type de frais',
    tarif DECIMAL(8, 2) NOT NULL DEFAULT 0.00 COMMENT 'Tarif forfaitaire (si applicable)',
    type ENUM('FORFAIT', 'HORS_FORFAIT') NOT NULL COMMENT 'Nature du frais',
    dateCreation TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Date de création',
    dateModification TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Date de modification'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Table des types de frais (Nuitée, Repas, Kilométrique, etc.)';

-- ============================================================
-- TABLE: FICHE_FRAIS
-- ============================================================
CREATE TABLE IF NOT EXISTS FICHE_FRAIS (
    idFiche INT AUTO_INCREMENT PRIMARY KEY COMMENT 'ID unique de la fiche',
    mois CHAR(6) NOT NULL COMMENT 'Mois au format AAAAMM',
    etat ENUM('EN_COURS', 'EN_ATTENTE', 'VALIDEE', 'REFUSEE', 'REFUS_PARTIEL') NOT NULL DEFAULT 'EN_COURS' COMMENT 'État de la fiche',
    idUtilisateur INT NOT NULL COMMENT 'ID de l''utilisateur propriétaire',
    dateSaisie TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Date de saisie initiale',
    dateModification TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Date de dernière modification',
    montantTotal DECIMAL(10, 2) DEFAULT 0.00 COMMENT 'Montant total des frais',
    observations TEXT COMMENT 'Observations ou justifications',
    UNIQUE KEY uk_utilisateur_mois (idUtilisateur, mois),
    CONSTRAINT fk_fiche_utilisateur FOREIGN KEY (idUtilisateur) 
        REFERENCES UTILISATEUR(idUtilisateur) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Table des fiches de frais mensuelles';

-- ============================================================
-- TABLE: LIGNE_FRAIS_FORFAIT
-- ============================================================
CREATE TABLE IF NOT EXISTS LIGNE_FRAIS_FORFAIT (
    idLFF INT AUTO_INCREMENT PRIMARY KEY COMMENT 'ID unique de la ligne',
    quantite INT NOT NULL DEFAULT 0 COMMENT 'Nombre d''unités',
    idFiche INT NOT NULL COMMENT 'ID de la fiche de frais',
    idTypeFrais INT NOT NULL COMMENT 'ID du type de frais',
    dateCreation TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Date de création',
    dateModification TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Date de modification',
    UNIQUE KEY uk_fiche_typefrais (idFiche, idTypeFrais),
    CONSTRAINT fk_lff_fiche FOREIGN KEY (idFiche) 
        REFERENCES FICHE_FRAIS(idFiche) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE,
    CONSTRAINT fk_lff_typefrais FOREIGN KEY (idTypeFrais) 
        REFERENCES TYPE_FRAIS(idTypeFrais) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Table des lignes de frais forfaitisés';

-- ============================================================
-- TABLE: LIGNE_FRAIS_HORS_FORFAIT
-- ============================================================
CREATE TABLE IF NOT EXISTS LIGNE_FRAIS_HORS_FORFAIT (
    idLHFF INT AUTO_INCREMENT PRIMARY KEY COMMENT 'ID unique de la ligne',
    libelle VARCHAR(255) NOT NULL COMMENT 'Description du frais',
    montant DECIMAL(10, 2) NOT NULL COMMENT 'Montant du frais',
    justificatif VARCHAR(255) COMMENT 'Chemin ou référence du justificatif',
    idFiche INT NOT NULL COMMENT 'ID de la fiche de frais',
    dateCreation TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Date de création',
    dateModification TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Date de modification',
    CONSTRAINT fk_lhff_fiche FOREIGN KEY (idFiche) 
        REFERENCES FICHE_FRAIS(idFiche) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Table des lignes de frais hors forfait';

-- ============================================================
-- DONNÉES D'INITIALISATION
-- ============================================================

-- Types de frais forfaitisés
INSERT IGNORE INTO TYPE_FRAIS (libelle, tarif, type) VALUES
('Nuitée', 110.00, 'FORFAIT'),
('Repas', 25.00, 'FORFAIT'),
('Kilométrique', 0.58, 'FORFAIT');

-- Utilisateurs de test (WARNING: Les mots de passe sont hashés en bcrypt)
-- Pour la production, générer avec bcrypt: https://bcrypt-generator.com/
-- Ici: 'password123' en bcrypt
INSERT IGNORE INTO UTILISATEUR (nom, prenom, login, mdpHash, role) VALUES
('Dupont', 'Jean', 'jdupont', '$2y$10$Z9nSSJJvVWqJ5aM3e5K7KuU5T2o0R9D5H5L3M4N5O6P7Q8R9S0T1U2', 'VISITEUR'),
('Martin', 'Marie', 'mmartin', '$2y$10$Z9nSSJJvVWqJ5aM3e5K7KuU5T2o0R9D5H5L3M4N5O6P7Q8R9S0T1U2', 'COMPTABLE'),
('Bernard', 'Pierre', 'pbernard', '$2y$10$Z9nSSJJvVWqJ5aM3e5K7KuU5T2o0R9D5H5L3M4N5O6P7Q8R9S0T1U2', 'ADMIN');

-- ============================================================
-- VIEWS OPTIONNELLES (pour faciliter les requêtes)
-- ============================================================

-- Vue: Fiches avec détails utilisateur
CREATE OR REPLACE VIEW VUE_FICHES_DETAIL AS
SELECT 
    f.idFiche,
    f.mois,
    f.etat,
    u.idUtilisateur,
    u.nom,
    u.prenom,
    u.login,
    f.montantTotal,
    f.dateSaisie,
    f.dateModification
FROM FICHE_FRAIS f
INNER JOIN UTILISATEUR u ON f.idUtilisateur = u.idUtilisateur
ORDER BY f.dateModification DESC;

-- Vue: Total des frais forfaitisés par fiche
CREATE OR REPLACE VIEW VUE_TOTAL_FORFAIT AS
SELECT 
    lff.idFiche,
    SUM(lff.quantite * tf.tarif) AS totalForfait
FROM LIGNE_FRAIS_FORFAIT lff
INNER JOIN TYPE_FRAIS tf ON lff.idTypeFrais = tf.idTypeFrais
GROUP BY lff.idFiche;

-- Vue: Total des frais hors forfait par fiche
CREATE OR REPLACE VIEW VUE_TOTAL_HORS_FORFAIT AS
SELECT 
    idFiche,
    SUM(montant) AS totalHorsForfait
FROM LIGNE_FRAIS_HORS_FORFAIT
GROUP BY idFiche;

-- ============================================================
-- FIN D'INITIALISATION
-- ============================================================
