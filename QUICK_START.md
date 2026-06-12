## 🎯 Guide de Démarrage Rapide - GSB Frais WinForms

### 1️⃣ **Premier Démarrage**

#### Avant de lancer l'app:
1. ✅ MariaDB/MySQL en cours d'exécution
2. ✅ Base `GSB_FRAIS` créée avec les tables (voir `Docker/init.sql`)
3. ✅ Vérifier la chaîne de connexion dans `DatabaseConfig.cs`

#### Lancer l'app:
```bash
cd GSB_Frais.UI
dotnet run
```

---

### 2️⃣ **Comptes de Test**

Créez dans la table `UTILISATEUR`:

```sql
-- Admin
INSERT INTO UTILISATEUR (nom, prenom, login, mdpHash, role, actif) 
VALUES ('Admin', 'Système', 'admin', '$2a$11$...bcrypthash', 'ADMIN', TRUE);

-- Comptable
INSERT INTO UTILISATEUR (nom, prenom, login, mdpHash, role, actif) 
VALUES ('Comptable', 'Test', 'comptable', '$2a$11$...bcrypthash', 'COMPTABLE', TRUE);

-- Visiteur
INSERT INTO UTILISATEUR (nom, prenom, login, mdpHash, role, actif) 
VALUES ('Visiteur', 'Test', 'visiteur', '$2a$11$...bcrypthash', 'VISITEUR', TRUE);
```

**Générer un hash BCrypt** (avec mot de passe `password123`):
```csharp
using BCrypt.Net;
string hash = BCrypt.HashPassword("password123");
Console.WriteLine(hash);
```

---

### 3️⃣ **Workflow Typique**

#### **As Visiteur:**
1. Login avec `visiteur` / `password123`
2. Cliquer "Nouvelle" pour créer une fiche du mois courant
3. Onglet **Forfait**: 
   - Modifier les quantités (repas, hôtel, etc.)
   - Les montants se calculent automatiquement
4. Onglet **Hors Forfait**: 
   - Cliquer "Ajouter"
   - Saisir la description et le montant
5. Cliquer "Soumettre" → Fiche passe en `EN_ATTENTE`

#### **As Comptable:**
1. Login avec `comptable` / `password123`
2. État par défaut = `EN_ATTENTE`
3. Cliquer "Rechercher" 
4. Sélectionner une fiche
5. Cliquer "Valider" pour voir les détails
6. Actions:
   - ✅ **Valider**: Fiche → `VALIDEE`
   - ❌ **Refuser**: Fiche → `REFUSEE`
   - ⚠️ **Refus Partiel**: Fiche → `REFUS_PARTIEL`

#### **As Admin:**
1. Login avec `admin` / `password123`
2. Voir "Menu Administration"
3. **Gestion Utilisateurs**:
   - Ajouter/Modifier/Supprimer utilisateurs
   - Changer les rôles
4. **Gestion Types de Frais**:
   - Créer les types (Repas, Hôtel, Kilométrique, etc.)
   - Tarifs forfaitaires pour les forfaits

---

### 4️⃣ **Commandes Utiles**

```bash
# Compiler
dotnet build

# Lancer tests
dotnet test

# Nettoyer
dotnet clean

# Restaurer packages
dotnet restore

# Publier en Release
dotnet publish -c Release -o ./publish
```

---

### 5️⃣ **Erreurs Courantes**

| Erreur | Cause | Solution |
|--------|-------|----------|
| "Identifiants invalides" | Hash BCrypt incorrect | Utiliser `BCrypt.HashPassword()` |
| "Connexion BDD échouée" | Mauvaise chaîne de connexion | Vérifier `DatabaseConfig.ConnectionString` |
| "Table UTILISATEUR non trouvée" | SQL d'initialisation non exécuté | Lancer `Docker/init.sql` |
| "Port 3306 occupé" | MariaDB pas accessible | Redémarrer MySQL/MariaDB |

---

### 6️⃣ **Architecture en 30 secondes**

```
┌─────────────────────────────────────────┐
│          GSB_Frais.UI (WinForms)        │
│  - FrmLogin, FrmMenuAdmin, FrmMesFiches │
│  - ExceptionManager, SessionManager      │
└──────────────────┬──────────────────────┘
                   │ utilise
┌──────────────────▼──────────────────────┐
│      GSB_Frais.Metier (Services)        │
│  - AuthService, FicheFraisService, etc. │
└──────────────────┬──────────────────────┘
                   │ utilise
┌──────────────────▼──────────────────────┐
│        GSB_Frais.DAL (Repositories)     │
│  - UtilisateurRepository, etc.          │
│  - Utilise MySqlConnector               │
└──────────────────┬──────────────────────┘
                   │ utilise
┌──────────────────▼──────────────────────┐
│     GSB_Frais.Models (Data Models)      │
│  - Utilisateur, FicheFrais, etc.        │
└──────────────────────────────────────────┘
```

---

### 7️⃣ **Support Rapide**

- 📘 Consulter: `WINFORMS_README.md`
- 🗄️ Vérifier logs BDD
- 🔍 Utiliser le débogueur VS Code
- 💬 Messages via `ExceptionManager.ShowWarning()`

---

**Ready to go! 🚀 Bonne utilisation!**
