<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# Pflichtenheft für die Rezeptverwaltungsplattform „RecipeNow"
## 1. Einleitung
### 1.1 Ziel des Dokuments
Dieses Pflichtenheft beschreibt die konkrete technische Umsetzung der Anforderungen aus dem Lastenheft für die Rezeptverwaltungsplattform „RecipeNow".

**Ziel des Projekts „RecipeNow"** ist die Entwicklung einer benutzerfreundlichen, modernen Webanwendung zur Verwaltung von Rezepten, Zutaten und Lagerbereichen. Die Anwendung bietet umfassende Funktionen für Benutzer zur Organisation ihrer Rezeptsammlungen mit integrierter Authentifizierung und personalisierten Bereichen.

### 1.2 Verantwortlichkeiten

- Auftraggeber: Privatnutzer 
- Projektleitung: Projektverantwortliche/r
- Entwicklungsteam: Full-Stack-Entwickler

## 2. Systemübersicht
„RecipeNow" ist eine moderne Webanwendung, die mit dem ASP.NET Core Framework (.NET 10.0) und Blazor entwickelt wird.
Für das Frontend werden Blazor-Komponenten mit HTML, CSS und JavaScript eingesetzt. Die Datenhaltung erfolgt über SQLite mit Entity Framework Core.
Der Fokus liegt auf intuitiver Benutzerführung, responsivem Design und modularer Architektur.

## 3. Technische Umsetzung der Anforderungen
### 3.1 Funktionale Anforderungen und deren Umsetzung
| Modul | Beschreibung | Implementierung |
| --- | --- | --- |
| **Rezeptverwaltung** | Erstellen, Bearbeiten, Löschen und Anzeigen von Rezepten | RecipeService, RecipePages |
| **Zutatenverwaltung** | Verwaltung von Zutaten mit Preisen und Maßeinheiten | IngredientService, IngredientPages |
| **Lagerbereiche** | Organisation und Verwaltung von Lagerbereichen | StorageRoomService, StorageRoomPages |
| **BenutzerAuthentifizierung** | Login, Registrierung, Passwort-Management | ASP.NET Core Identity, AuthDbContext |
| **Datei-Upload** | Upload von Bildern für Rezepte | UploadSettings |


### 3.2 Nicht-funktionale Anforderungen und deren Umsetzung

| Anforderung | Umsetzung |
| --- | --- |
| **Modularität** | Trennung in Service-Layer, Data Layer und UI-Komponenten mit DI-Pattern |
| **Datenspeicherung** | SQLite für schnelle Entwicklung, EF Core für ORM und Migration |
| **Sicherheit** | ASP.NET Core Identity für Authentifizierung, Passwort-Hashing, Autorisierung |
| **Erweiterbarkeit** | Blazor-Komponenten, Service-Interfaces, modulare Architektur |
| **Responsive Design** | CSS-Grid und Flexbox für responsive Layouts |
| **Performance** | Entity Framework Core mit optimierten Datenbankqueries |

## 4. Architektur und Systemdesign

### 4.1 Systemkomponenten

* **Backend:** ASP.NET Core (.NET 10.0) mit Blazor Server
* **Datenbank:** SQLite mit Entity Framework Core
* **Frontend:** Blazor-Komponenten mit HTML5, CSS3, JavaScript
* **Authentifizierung:** ASP.NET Core Identity
* **Dateihandling:** Custom FileProviderService für Upload-Management

### 4.2 Beispielhafte Datenbankstruktur (Auszug)

#### Tabelle: Ingredient

| Id | Name  | PricePerUnit | Measurement |
|----|-------|--------------|-------------|
| 1  | Gurke | 1.50 | 0 |
| 2  | Tomate | 0.80 | 0 |

#### Tabelle: Recipe

| Id | Name  | Description | UserId |
|----|-------|-------------|--------|
| 1  | Salatmix | Ein frischer Salat | user123 |

## 5. Testfälle und Abnahme

### 5.1 Testfälle
Aus Zeitgründen nicht umgesetzt


### 5.2 Abnahmekriterien
Alle Features funktionieren Fehlerfrei und entsprechen den besprochenen Anforderungen.


## 6. Zeit- und Ressourcenplanung

### 6.1 Zeitplan

| Phase          | Zeitraum |
| -------------- |----------|
| Planung & Anforderungsanalyse | 1 Woche |
| Grundarchitektur & Authentifizierung | 1 Woche |
| Feature-Implementierung | 2 Wochen |
| Testing & Bug-Fixes | 1 Woche |

### 6.2 Ressourcen

* 1-2 Full-Stack-Entwickler (ASP.NET Core / Blazor)

---

Letzte Aktualisierung: 21. Februar 2025
Version: 2.0 (RecipeNow)
