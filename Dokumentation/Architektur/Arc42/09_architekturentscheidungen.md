<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 09 – Architekturentscheidungen

Dieses Kapitel dokumentiert alle Architekturentscheidungen.

---

## Entscheidung 1: Nutzung von ASP.NET / Razor Pages / Blazor als Web-Framework

- **Datum**: 2026-01-14
- **Status**: angenommen

**Kontext / Problem**  
Für die Entwicklung der Webanwendung musste ein geeignetes Framework gewählt werden, das sowohl die Umsetzung einer modernen Benutzeroberfläche als auch eine effiziente Anbindung an das Backend ermöglicht. Zusätzlich standen begrenzte personelle Ressourcen sowie ein enger Zeitrahmen zur Verfügung, wodurch eine möglichst einheitliche Technologie bevorzugt wurde.

**Entscheidung**  
Es wird ASP.NET als Basisframework eingesetzt. Die Benutzeroberfläche wird mithilfe von Razor Pages und Blazor Components umgesetzt, sodass Frontend- und Backend-Logik innerhalb des .NET-Ökosystems realisiert werden.

**Begründung**  
Die gewählte Lösung ermöglicht eine schnelle Entwicklung durch die Nutzung einer gemeinsamen Programmiersprache (C#) für Frontend und Backend. Dadurch reduziert sich die technische Komplexität im Vergleich zu einer Architektur mit getrenntem .NET-Backend und einem zusätzlichen JavaScript-Frontend-Framework. Zudem bieten Razor Pages und Blazor integrierte Mechanismen für Sicherheit, Routing und State-Management.

**Alternativen**
- Trennung von Backend (ASP.NET Web API) und Frontend (z. B. Angular, React oder Vue)
- Verwendung eines vollständig clientseitigen JavaScript-Frameworks

**Auswirkungen**  
Die Anwendung ist eng an das .NET-Ökosystem gebunden, was einen späteren Technologiewechsel erschwert. Gleichzeitig wird der Entwicklungsaufwand reduziert und die Wartbarkeit verbessert.

---

## Entscheidung 2: Verwendung von SQLite als Datenbank

- **Datum**: 2026-01-15
- **Status**: angenommen

**Kontext / Problem**  
Für die Persistierung der Anwendungsdaten wurde eine Datenbanklösung benötigt, die einfach zu integrieren ist und keinen zusätzlichen Infrastrukturaufwand verursacht. Das Projekt ist zeitlich begrenzt und richtet sich nicht auf einen produktiven Hochlastbetrieb aus.

**Entscheidung**  
Es wird SQLite als relationale Datenbank eingesetzt.

**Begründung**  
SQLite ist leichtgewichtig, serverlos und erfordert keine separate Installation oder Administration. Dadurch eignet sich die Datenbank besonders gut für Entwicklungs-, Test- und Projektkontexte mit begrenzten Ressourcen. Die Integration in ASP.NET-Anwendungen ist unkompliziert und gut dokumentiert.

**Alternativen**
- PostgreSQL
- Microsoft SQL Server
- MySQL / MariaDB

**Auswirkungen**  
SQLite bietet nur eingeschränkte Möglichkeiten in Bezug auf Skalierbarkeit und Parallelzugriffe. Bei steigender Nutzerzahl oder wachsendem Datenvolumen wäre ein Wechsel zu einer serverbasierten Datenbank erforderlich.

---

## Entscheidung 3: Keine eigene Identity-Klasse

- **Datum**: 2026-01-17
- **Status**: angenommen

**Kontext / Problem**  
Für die Benutzerverwaltung und Authentifizierung musste entschieden werden, ob eine eigene Identity-Implementierung entwickelt oder auf bestehende Framework-Funktionalitäten zurückgegriffen wird. Eine Eigenimplementierung hätte zusätzlichen Entwicklungs- und Wartungsaufwand bedeutet.

**Entscheidung**  
Es wird **keine eigene Identity-Klasse** implementiert. Stattdessen werden die vorhandenen Authentifizierungs- und Autorisierungsmechanismen von ASP.NET genutzt.

**Begründung**  
Die Nutzung der bestehenden ASP.NET-Mechanismen reduziert Komplexität und potenzielle Sicherheitsrisiken. Standardlösungen sind erprobt, gut dokumentiert und bieten integrierte Sicherheitsfunktionen wie Passwort-Hashing, Rollenverwaltung und Schutz vor gängigen Angriffen.

**Alternativen**
- Eigene Benutzer- und Rollenverwaltung
- Einsatz externer Identity-Provider (z. B. OAuth2, Keycloak)

**Auswirkungen**  
Die Anwendung ist an die Standard-Identity-Strukturen von ASP.NET gebunden. Individuelle Anpassungen an der Benutzerverwaltung sind nur eingeschränkt möglich, dafür wird die Sicherheit erhöht und der Entwicklungsaufwand deutlich reduziert.

---
