<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 04 – Lösungsstrategie

Dieses Kapitel beschreibt die grundlegende Lösungsstrategie sowie die zentralen Architektur- und Technologieentscheidungen für die Implementierung der Anwendung.

## Architekturmodell

Die Anwendung basiert auf einer klassischen Mehrschichtenarchitektur, die eine klare Trennung von Verantwortlichkeiten sicherstellt:

1. Präsentationsschicht  
   Umsetzung der Benutzeroberfläche mit Razor Pages und Blazor Components.  
   Der Fokus liegt auf einer barrierearmen Gestaltung gemäß WCAG 2.2.

2. Applikations- und Geschäftslogikschicht  
   Realisierung mit ASP.NET in Form von Services, welche die Geschäftslogik kapseln und von der Darstellung trennen.

3. Datenhaltungsschicht  
   Persistierung der Daten in einer SQLite-Datenbank, angebunden über einen klar definierten Datenzugriff.

Diese Struktur ermöglicht eine gute Testbarkeit, Wartbarkeit und eine spätere Erweiterung, beispielsweise durch alternative Benutzeroberflächen oder zusätzliche Dienste.

---

## Technologiewahl

- Web-Framework: ASP.NET mit Razor Pages und Blazor
- Programmiersprache: C#
- Datenbank: SQLite (dateibasiert, leichtgewichtig, für kleine Deployments geeignet)
- Containerisierung: Docker zur Sicherstellung konsistenter Entwicklungs- und Laufzeitumgebungen
- Build- und Testprozesse: Automatisierte Abläufe im Rahmen des Build-Prozesses

---

## Barrierefreiheit (FULL RELEASE)

- Umsetzung der Benutzeroberfläche nach den Richtlinien der WCAG 2.2
- Vollständige Bedienbarkeit per Tastatur
- Unterstützung von Screenreadern durch semantisches HTML und geeignete ARIA-Attribute
- Sicherstellung ausreichender Farbkontraste und klarer Fokuszustände

---

## Sicherheit & Datenschutz

- Benutzerkonten werden nicht öffentlich registriert, sondern administrativ verwaltet
- Zugriff auf Funktionen erfolgt rollenbasiert
- Nutzung der integrierten Sicherheitsmechanismen von ASP.NET (z. B. Passwort-Hashing, Autorisierung)
- Validierung aller Eingaben auf Client- und Serverseite
- Einsatz von HTTPS in produktiven Umgebungen
- Berücksichtigung der geltenden Datenschutzanforderungen (DSGVO-konforme Datenverarbeitung)

---

## Erweiterbarkeit

- Modularer Aufbau durch klare Trennung von UI, Services und Datenzugriff
- Wiederverwendbare Blazor Components zur Erweiterung der Benutzeroberfläche
- Austauschbarkeit einzelner Komponenten (z. B. Datenbank) mit überschaubarem Aufwand

---

## Entwicklungsstrategie

- Versionsverwaltung über Git
- Regelmäßige Commits und nachvollziehbare Änderungshistorie
- Automatisierte Tests, die im Build-Prozess ausgeführt werden
- Nutzung von Docker für entwicklungsnahe Testumgebungen

---

Wenn du möchtest, kann ich den Abschnitt auch
- noch technischer (z. B. mit konkreten ASP.NET-Konzepten),
- kürzer und kompakter, oder
- konsequent nach arc42 ausrichten.