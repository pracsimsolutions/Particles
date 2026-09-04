@echo off
REM Thin wrapper so you don't have to type "powershell -File ...".
REM Usage:  scripts\update-module-version.bat 26.1.3
if "%~1"=="" (
    echo Usage: update-module-version.bat X.Y.Z
    echo   e.g. scripts\update-module-version.bat 26.1.3
    exit /b 1
)
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0update-module-version.ps1" -Version %1
if errorlevel 1 (
    pause
    exit /b 1
)
