-- ============================================================================
-- GSB - Gestion des Fiches de Frais
-- Schéma de Base de Données complet pour MariaDB/MySQL
-- ============================================================================

-- Créer la base de données
CREATE DATABASE IF NOT EXISTS `gsb_app` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `gsb_app`;

-- ============================================================================
-- TABLE 1: UTILISATEUR
-- ============================================================================
CREATE TABLE `utilisateur` (
  `idUtilisateur` INT AUTO_INCREMENT PRIMARY KEY,
  `nom` VARCHAR(50) NOT NULL,
  `prenom` VARCHAR(50) NOT NULL,
  `login` VARCHAR(50) UNIQUE NOT NULL,
  `mdpHash` VARCHAR(255) NOT NULL,
  `role` ENUM('ADMIN', 'VISITEUR', 'COMPTABLE') NOT NULL DEFAULT 'VISITEUR',
  `dateCreation` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `dateModification` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `actif` BOOLEAN DEFAULT TRUE,
  KEY `idx_login` (`login`),
  KEY `idx_role` (`role`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================================
-- TABLE 2: TYPE_FRAIS
-- ============================================================================
CREATE TABLE `type_frais` (
  `idTypeFrais` INT AUTO_INCREMENT PRIMARY KEY,
  `libelle` VARCHAR(100) NOT NULL,
  `tarif` DECIMAL(10,2) NOT NULL,
  `type` ENUM('FORFAIT', 'HORS_FORFAIT') NOT NULL,
  `description` TEXT,
  `actif` BOOLEAN DEFAULT TRUE,
  `dateCreation` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  KEY `idx_type` (`type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================================
-- TABLE 3: FICHE_FRAIS
-- ============================================================================
CREATE TABLE `fiche_frais` (
  `idFiche` INT AUTO_INCREMENT PRIMARY KEY,
  `mois` CHAR(6) NOT NULL COMMENT 'Format: YYYYMM',
  `etat` ENUM('EN_COURS', 'EN_ATTENTE', 'VALIDEE', 'REFUSEE', 'REMBOURSEE') NOT NULL DEFAULT 'EN_COURS',
  `idUtilisateur` INT NOT NULL,
  `dateCreation` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `dateModification` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `dateSoumission` DATETIME,
  `dateValidation` DATETIME,
  `montantTotal` DECIMAL(10,2) DEFAULT 0,
  `remarques` TEXT,
  FOREIGN KEY (`idUtilisateur`) REFERENCES `utilisateur`(`idUtilisateur`) ON DELETE CASCADE,
  UNIQUE KEY `unique_user_month` (`idUtilisateur`, `mois`),
  KEY `idx_etat` (`etat`),
  KEY `idx_mois` (`mois`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================================
-- TABLE 4: LIGNE_FRAIS_FORFAIT
-- ============================================================================
CREATE TABLE `ligne_frais_forfait` (
  `idLFF` INT AUTO_INCREMENT PRIMARY KEY,
  `quantite` INT NOT NULL DEFAULT 1,
  `montantUnitaire` DECIMAL(10,2) NOT NULL,
  `montantTotal` DECIMAL(10,2) GENERATED ALWAYS AS (quantite * montantUnitaire) STORED,
  `idFiche` INT NOT NULL,
  `idTypeFrais` INT NOT NULL,
  `dateCreation` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (`idFiche`) REFERENCES `fiche_frais`(`idFiche`) ON DELETE CASCADE,
  FOREIGN KEY (`idTypeFrais`) REFERENCES `type_frais`(`idTypeFrais`),
  KEY `idx_fiche` (`idFiche`),
  KEY `idx_type` (`idTypeFrais`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================================
-- TABLE 5: LIGNE_FRAIS_HORS_FORFAIT
-- ============================================================================
CREATE TABLE `ligne_frais_hors_forfait` (
  `idLHFF` INT AUTO_INCREMENT PRIMARY KEY,
  `libelle` VARCHAR(255) NOT NULL,
  `montant` DECIMAL(10,2) NOT NULL,
  `justificatif` VARCHAR(255) COMMENT 'Chemin du fichier jusificatif',
  `dateEngagement` DATE NOT NULL,
  `idFiche` INT NOT NULL,
  `dateCreation` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `dateModification` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (`idFiche`) REFERENCES `fiche_frais`(`idFiche`) ON DELETE CASCADE,
  KEY `idx_fiche` (`idFiche`),
  KEY `idx_date` (`dateEngagement`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================================
-- TABLE 6: HISTORIQUE_ETAT (Traçabilité des changements d'état)
-- ============================================================================
CREATE TABLE `historique_etat` (
  `idHistorique` INT AUTO_INCREMENT PRIMARY KEY,
  `idFiche` INT NOT NULL,
  `etatPrecedent` ENUM('EN_COURS', 'EN_ATTENTE', 'VALIDEE', 'REFUSEE', 'REMBOURSEE'),
  `etatNouveau` ENUM('EN_COURS', 'EN_ATTENTE', 'VALIDEE', 'REFUSEE', 'REMBOURSEE') NOT NULL,
  `idUtilisateurModification` INT NOT NULL,
  `dateModification` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `commentaire` TEXT,
  FOREIGN KEY (`idFiche`) REFERENCES `fiche_frais`(`idFiche`) ON DELETE CASCADE,
  FOREIGN KEY (`idUtilisateurModification`) REFERENCES `utilisateur`(`idUtilisateur`),
  KEY `idx_fiche` (`idFiche`),
  KEY `idx_date` (`dateModification`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================================
-- INSERTION DE DONNÉES D'EXEMPLE
-- ============================================================================

-- Utilisateurs de test
INSERT INTO `utilisateur` (`nom`, `prenom`, `login`, `mdpHash`, `role`, `actif`) VALUES
('Dupont', 'Jean', 'jdupont', '$2y$10$example1', 'VISITEUR', TRUE),
('Martin', 'Marie', 'mmartin', '$2y$10$example2', 'VISITEUR', TRUE),
('Bernard', 'Pierre', 'pbernard', '$2y$10$example3', 'COMPTABLE', TRUE),
('Laurent', 'Admin', 'admin', '$2y$10$example4', 'ADMIN', TRUE),
('Durand', 'Sophie', 'sdurand', '$2y$10$example5', 'VISITEUR', TRUE);

-- Types de frais (forfait)
INSERT INTO `type_frais` (`libelle`, `tarif`, `type`, `description`, `actif`) VALUES
('Repas midi', 16.50, 'FORFAIT', 'Forfait repas de midi', TRUE),
('Repas soir', 25.00, 'FORFAIT', 'Forfait repas du soir', TRUE),
('Nuitée', 50.00, 'FORFAIT', 'Forfait nuitée d\'hôtel', TRUE),
('Étapes', 29.10, 'FORFAIT', 'Forfait kilométrique', TRUE);

-- Fiches de frais exemples
INSERT INTO `fiche_frais` (`mois`, `etat`, `idUtilisateur`, `montantTotal`, `dateSoumission`) VALUES
('202401', 'EN_COURS', 1, 0.00, NULL),
('202401', 'VALIDEE', 2, 141.50, '2024-01-25'),
('202402', 'EN_ATTENTE', 1, 100.00, '2024-02-28'),
('202402', 'EN_COURS', 3, 0.00, NULL),
('202403', 'VALIDEE', 2, 200.00, '2024-03-20');

-- Lignes de frais forfait
INSERT INTO `ligne_frais_forfait` (`quantite`, `montantUnitaire`, `idFiche`, `idTypeFrais`) VALUES
(2, 16.50, 2, 1),
(1, 25.00, 2, 2),
(2, 50.00, 2, 3),
(3, 16.50, 3, 1),
(1, 25.00, 5, 2);

-- Lignes de frais hors forfait
INSERT INTO `ligne_frais_hors_forfait` (`libelle`, `montant`, `dateEngagement`, `idFiche`, `justificatif`) VALUES
('Carburant', 45.00, '2024-01-10', 3, 'justificatif_001.pdf'),
('Parking', 15.50, '2024-01-15', 3, 'justificatif_002.pdf'),
('Péage', 8.50, '2024-02-05', 5, 'justificatif_003.pdf');

-- ============================================================================
-- VÉRIFICATION ET INFORMATIONS
-- ============================================================================

-- Afficher les statistiques
SELECT 'UTILISATEURS' as 'Entité', COUNT(*) as 'Nombre' FROM utilisateur
UNION ALL
SELECT 'TYPES DE FRAIS', COUNT(*) FROM type_frais
UNION ALL
SELECT 'FICHES DE FRAIS', COUNT(*) FROM fiche_frais
UNION ALL
SELECT 'LIGNES FORFAIT', COUNT(*) FROM ligne_frais_forfait
UNION ALL
SELECT 'LIGNES HORS FORFAIT', COUNT(*) FROM ligne_frais_hors_forfait;
