#!/bin/bash

# Abbrechen bei Fehlern
set -e

echo "Inistalisiere Dotnet EF Tools..."
dotnet new tool-manifest --force
dotnet tool install dotnet-ef --version 10.*

echo "Erstelle Migrationen für AppDbContext..."
dotnet tool run dotnet-ef migrations add Initial --context AppDbContext --output-dir Migrations/App

echo "Erstelle Migrationen für AuthDbContext..."
dotnet tool run dotnet-ef migrations add Initial --context AuthDbContext --output-dir Migrations/Auth

echo "Wende Migrationen auf Datenbanken an..."
dotnet tool run dotnet-ef database update --context AppDbContext
dotnet tool run dotnet-ef database update --context AuthDbContext

echo "Datenbank-Initialisierung abgeschlossen!"