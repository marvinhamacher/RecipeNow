<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 05 – Bausteinsicht

Diese Bausteinsicht beschreibt die statische Struktur der Anwendung.
Das System ist in mehrere logisch und fachlich getrennte Module unterteilt, die auf **ASP.NET mit Razor Pages und Blazor Components** basieren.

## Übersicht über Systembausteine

Die Anwendung folgt einer modularen, schichtenorientierten Struktur innerhalb einer ASP.NET-Lösung.  
Die fachliche Ausrichtung liegt auf einer **Rezepte- und Vorratsverwaltungsanwendung**. Die wichtigsten Systembausteine sind:

| Modul              | Beschreibung                                                                 |
|--------------------|------------------------------------------------------------------------------|
| **Authentication** | Authentifizierung und Autorisierung von Benutzer:innen (Login, Rollen)      |
| **Ingredient**     | Verwaltung einzelner Zutaten mit grundlegenden Eigenschaften                 |
| **Recipe**         | Erstellung, Bearbeitung und Anzeige von Rezepten                             |
| **Stock**          | Verwaltung des Vorratsbestands (Zutaten, Mengen, Verfügbarkeit)              |
| **UI**             | Razor Pages und Blazor Components zur Darstellung der Benutzeroberfläche     |
| **Services**       | Kapselung der Geschäftslogik und domänenübergreifender Funktionen             |
| **Persistence**    | Datenzugriff und Persistierung über SQLite                                   |
| **Infrastructure** | Konfiguration, Logging, Sicherheit und Anwendungsstart                       |

---

## Strukturdiagramm (Mermaid)

```mermaid
graph TD
    A[ASP.NET Web App] --> B[Authentication]
    A --> C[Recipe]
    A --> D[Ingredient]
    A --> E[Stock]

    C --> D
    E --> D

    A --> F[Services]
    F --> C[Recipe]
    F --> D[Ingredient]
    F --> E[Stock]
    F --> G[Persistence]