<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 11 – Risiken und technische Schulden

Das Kapitel 11 behandelt bekannte Projektrisiken dient ebensfalls als zentrale Dokumentation für technische Schulden.

---

## Technische Schulden

### 1. Wahl von Razor Pages / Blazor für das Frontend

**Auswirkung:**  
Die Verwendung von Razor Pages und Blazor bindet das Frontend stark an das .NET-Ökosystem.
Dies kann die Wiederverwendbarkeit der Benutzeroberfläche einschränken
und einen späteren Wechsel zu anderen Frontend-Technologien erschweren.

**Begründung:**  
- schnelle Entwicklung
- reduzierte Komplexität

**Risiko:**  
- Die UI wirkt weniger „modern“ 
- Bei einen späteren Wechsel wäre ein großer Refactoring Aufwand erforderlich
- Starke einschränkung bei UI Design

---

### 2. Verwendung von SQLite statt PostgreSQL

**Auswirkung:**  
SQLite ist in Bezug auf Skalierbarkeit, Parallelzugriffe und erweiterte Datenbankfunktionen eingeschränkt.
Dies kann bei wachsender Nutzerzahl oder zunehmender Datenmenge zu Performance-Engpässen führen.

**Begründung:**  
- leichtgewichtig
- Standard DB
- Kein seperater DB-Server notwendig

**Risiko:**  
- Paralleler Zugriff erschwert
- Datenbank wechsel erfordert großen Aufwand
---

## Weitere potenzielle Risiken

| Risiko                     | Beschreibung                                                                                                        | Mögliche Gegenmaßnahme                                                                            |
| -------------------------- | ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| Kein großes Entwicklerteam | Entwicklung und Wartung werden von wenigen Personen übernommen, wodurch Aufgaben nicht parallelisiert werden können | Klare Aufgabenverteilung, Einsatz bewährter Frameworks, Vermeidung unnötiger Komplexität          |
| Fehlende C#-Kenntnisse     | Begrenzte Erfahrung mit C# und dem .NET-Ökosystem kann zu längeren Entwicklungszeiten führen                        | Nutzung offizieller Dokumentationen, einfache Architektur, gezieltes Lernen während der Umsetzung |
| Starke zeitliche Grenzen   | Feste Abgabefristen schränken die Möglichkeit für umfangreiche Tests und Optimierungen ein                          | Fokus auf Kernfunktionalitäten, iterative Entwicklung, bewusste Priorisierung von Anforderungen   |
