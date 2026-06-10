@echo off
:: Script d'arrêt - GSB Frais Docker MySQL

echo.
echo Arrêt de l'environnement MySQL Docker...
echo.

cd /d "%~dp0"
docker-compose down

if errorlevel 1 (
    echo [ERREUR] Impossible d'arrêter docker-compose.
    pause
    exit /b 1
)

echo.
echo [OK] Environnement arrêté.
echo Les données persistent dans le volume Docker.
echo.

pause
