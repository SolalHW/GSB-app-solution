@echo off
:: Script de démarrage - GSB Frais Docker MySQL
:: Ce script lance l'environnement MySQL via Docker Compose

setlocal enabledelayedexpansion

echo.
echo ========================================
echo     GSB Frais - Initialisation Docker
echo ========================================
echo.

:: Vérifier si Docker est installé
docker --version >nul 2>&1
if errorlevel 1 (
    echo [ERREUR] Docker n'est pas installé ou n'est pas dans le PATH.
    echo Téléchargez Docker Desktop: https://www.docker.com/products/docker-desktop
    pause
    exit /b 1
)

:: Vérifier si Docker Desktop tourne
docker ps >nul 2>&1
if errorlevel 1 (
    echo [ERREUR] Docker Desktop n'est pas en cours d'exécution.
    echo Démarrez Docker Desktop et réessayez.
    pause
    exit /b 1
)

echo [OK] Docker détecté

:: Changer de répertoire
cd /d "%~dp0"

echo.
echo [INFO] Démarrage de l'environnement MySQL...
echo.

:: Lancer docker-compose
docker-compose up -d

if errorlevel 1 (
    echo [ERREUR] Impossible de lancer docker-compose.
    pause
    exit /b 1
)

echo.
echo [OK] Conteneur MySQL en cours de démarrage...
echo.

:: Attendre que MySQL soit prêt (max 30 secondes)
set /a timeout=30
:wait_loop
docker exec gsb_mysql_db mysqladmin ping -u root -proot_secure_password >nul 2>&1
if errorlevel 1 (
    if %timeout% gtr 0 (
        echo [INFO] Attente de MySQL... (%timeout%s restantes)
        timeout /t 1 /nobreak
        set /a timeout=%timeout%-1
        goto wait_loop
    ) else (
        echo [AVERTISSEMENT] MySQL ne répond pas encore. Vérifiez les logs:
        echo   docker logs gsb_mysql_db
    )
)

echo.
echo ========================================
echo     [OK] Initialisation Terminée!
echo ========================================
echo.
echo Détails de connexion:
echo   Host: localhost
echo   Port: 3306
echo   Database: GSB_FRAIS
echo   User: gsb_user
echo   Password: gsb_secure_password
echo.
echo Commandes utiles:
echo   - Voir les logs: docker logs gsb_mysql_db
echo   - Arrêter: docker-compose down
echo   - Redémarrer: docker-compose restart
echo.

pause
