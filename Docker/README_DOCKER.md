# 🐳 GSB Frais – Configuration Docker MySQL

## 📋 Vue d'ensemble

Ce dossier contient la configuration complète pour lancer une base de données **MySQL 8.0** via **Docker Compose**.

### Fichiers inclus:
- **docker-compose.yml** – Configuration du service MySQL
- **init.sql** – Script d'initialisation de la base de données
- **README_DOCKER.md** – Ce fichier (instructions)

---

## 🚀 Prérequis

1. **Docker Desktop** installé et en cours d'exécution
   - [Télécharger Docker Desktop](https://www.docker.com/products/docker-desktop)

2. **Docker Compose** (inclus dans Docker Desktop)

3. **Terminal** (PowerShell, CMD, ou Git Bash)

---

## ⚡ Démarrage rapide

### 1️⃣ Lancer l'environnement Docker

```powershell
cd c:\Users\frus90002988\Documents\ecole\GSB\Docker
docker-compose up -d
```

✅ Le conteneur démarre en arrière-plan (`-d` = detached mode)

---

### 2️⃣ Vérifier que MySQL tourne

```powershell
docker ps
```

Vous devriez voir:
```
CONTAINER ID   IMAGE     COMMAND                  CREATED         STATUS
abc123def456   mysql:8   "docker-entrypoint..."   2 minutes ago   Up 2 minutes (healthy)
```

---

### 3️⃣ Vérifier les logs du conteneur

```powershell
    docker logs gsb_mysql_db
```

Cherchez: `port: 3306  MySQL Community Server - GPL`

---

### 4️⃣ Accéder à MySQL (optionnel)

#### Depuis le terminal:
```powershell
docker exec -it gsb_mysql_db mysql -u root -p
```
Puis entrez le mot de passe: `root_secure_password`

#### Avec une GUI (DBeaver, MySQL Workbench, etc.):
```
Host: localhost
Port: 3306
User: gsb_user
Password: gsb_secure_password
Database: GSB_FRAIS
```

---

## 🛑 Arrêter l'environnement

```powershell
docker-compose down
```

⚠️ Les données persistent dans le volume `gsb_mysql_data`

---

## 🗑️ Supprimer tout (y compris les données)

```powershell
docker-compose down -v
```

`-v` supprime les volumes (données MySQL = supprimées)

---

## 📊 Configuration détaillée

### Service MySQL
- **Image**: `mysql:8.0`
- **Conteneur**: `gsb_mysql_db`
- **Port**: `3306`
- **Restart**: Automatique sauf arrêt manuel

### Variables d'environnement
```
MYSQL_ROOT_PASSWORD: root_secure_password
MYSQL_DATABASE: GSB_FRAIS
MYSQL_USER: gsb_user
MYSQL_PASSWORD: gsb_secure_password
```

### Volumes
- **gsb_mysql_data** → Persistence des données MySQL
- **init.sql** → Exécuté automatiquement au démarrage

### Réseau
- **gsb_network** → Bridge network (pour futurs services PHP/Node.js)

### Caractéristiques MySQL
- **Charset**: UTF-8 (utf8mb4)
- **Collation**: utf8mb4_unicode_ci
- **Plugin d'authentification**: mysql_native_password (compatible legacy)

---

## 🔍 Vérifications post-démarrage

### ✅ Vérifier la création de la base
```powershell
docker exec gsb_mysql_db mysql -u root -proot_secure_password -e "SHOW DATABASES;"
```

### ✅ Vérifier les tables créées
```powershell
docker exec gsb_mysql_db mysql -u gsb_user -pgsb_secure_password GSB_FRAIS -e "SHOW TABLES;"
```

Vous devriez voir:
```
UTILISATEUR
TYPE_FRAIS
FICHE_FRAIS
LIGNE_FRAIS_FORFAIT
LIGNE_FRAIS_HORS_FORFAIT
```

### ✅ Vérifier les données de test
```powershell
docker exec gsb_mysql_db mysql -u gsb_user -pgsb_secure_password GSB_FRAIS -e "SELECT * FROM UTILISATEUR;"
```

---

## 🔗 Connexion depuis ton application C#

Dans ta chaîne de connexion .NET 8:

```csharp
string connectionString = "Server=localhost;Port=3306;Database=GSB_FRAIS;Uid=gsb_user;Pwd=gsb_secure_password;";
```

Ou en app.config/appsettings.json:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=GSB_FRAIS;Uid=gsb_user;Pwd=gsb_secure_password;"
  }
}
```

---

## ⚙️ Commandes utiles

### Redémarrer le conteneur
```powershell
docker-compose restart
```

### Voir tous les conteneurs (y compris arrêtés)
```powershell
docker ps -a
```

### Consulter les logs en live
```powershell
docker logs -f gsb_mysql_db
```

### Nettoyer Docker (images/conteneurs inutilisés)
```powershell
docker system prune -a
```

---

## 🚨 Dépannage

### ❌ Port 3306 déjà utilisé
```powershell
# Chercher ce qui utilise le port
netstat -ano | findstr :3306

# Ou modifier le port dans docker-compose.yml:
# ports:
#   - "3307:3306"  # Extérieur:Intérieur
```

### ❌ Conteneur démarre mais n'est pas healthy
```powershell
docker logs gsb_mysql_db
```

### ❌ Impossible de se connecter avec gsb_user
Attendre ~30 secondes (temps d'initialisation). Vérifier les logs:
```powershell
docker logs gsb_mysql_db | Select-String "ERROR"
```

### ❌ Les données disparaissent après `down`
Vous avez probablement lancé `docker-compose down -v`. Pour relancer sans perdre:
```powershell
docker-compose up -d
```

---

## 📌 Notes de sécurité

⚠️ **POUR LE DÉVELOPPEMENT UNIQUEMENT**

Les mots de passe dans `docker-compose.yml` sont publiques. Pour la **production**:
- Utiliser des **variables d'environnement**
- Ou **Docker Secrets**
- Ou un fichier `.env` non commité

Exemple avec `.env`:
```
MYSQL_ROOT_PASSWORD=secure_production_password_here
MYSQL_PASSWORD=secure_user_password_here
```

Dans `docker-compose.yml`:
```yaml
environment:
  MYSQL_ROOT_PASSWORD: ${MYSQL_ROOT_PASSWORD}
  MYSQL_PASSWORD: ${MYSQL_PASSWORD}
```

Lancer avec:
```powershell
docker-compose --env-file .env up -d
```

---

## 📞 Support

Si vous rencontrez des problèmes:
1. Vérifier les **logs**: `docker logs gsb_mysql_db`
2. Vérifier que **Docker Desktop tourne**
3. Vérifier le **port 3306** n'est pas en conflit
4. **Redémarrer Docker Desktop**

---

**✨ Bon développement! ✨**
