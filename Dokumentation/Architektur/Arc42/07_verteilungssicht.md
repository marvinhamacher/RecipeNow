<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 07 – Verteilungssicht

Dieses Kapitel beschreibt die physische Verteilung und Deploymentstruktur der **Studurizer**-Anwendung.

## Übersicht

RecipeNow wird durch den Einsatz von Docker containerisiert ausgeliefert. 
Die App wird Modular in einen lokalen Dockernetzwerk bereitgestellt.

Für eine Entwicklungsumgebung ist eine Single-Host-Lösung vorgesehen. 
In einer produktiven Umgebung kann das System auf einem Linux-Server betrieben und über einen Reverse-Proxy erreichbar gemacht werden.

## Laufzeitumgebung (Entwicklung)

| Container              | Funktion                                                                 |
|------------------------|--------------------------------------------------------------------------|
| **web**                | ASP.NET-Anwendung mit Razor Pages und Blazor Components                  |
| **db**                 | SQLite-Datenbank (Datei, persistiert über Docker Volume)                 |
| **nginx** (optional)   | Reverse Proxy für HTTPS und Port-Routing                                 |

---

## Verteilungssicht (Mermaid-Diagramm)

```mermaid
graph TD
    subgraph Docker Host
        A[ASP.NET Web App] --> B[SQLite DB]
        D[Nginx Reverse Proxy] --> A
    end

    E[Browser / Nutzer:in] -->|HTTPS| D
