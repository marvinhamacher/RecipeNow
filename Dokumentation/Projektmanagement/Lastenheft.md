<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# Lastenheft für das Projekt „RecipeNow“

## 1. Einleitung

### 1.1 Ziel des Projekts
Das Projekt „RecipeNow“ soll es Nutzern ermöglichen die Verwaltung von Rezepten und Vorräten durchzuführen.

### 1.2 Ausgangssituation
Es gibt viele vergleichbare Produkte doch diese spezialisieren sich auf eine bestimmte Aufgabe. 
Beispielsweise sie setzen ausschließlich die Verwaltung von Rezepten aber keine Vorratsverwaltung um.

### 1.3 Zielgruppe
- Köche
- Haushalter
---

## 2. Anforderungen

### 2.1 Funktionale Anforderungen
- Benutzer:innen können Accounts erstellen und verwalten.
- Benutzer:innen können Rezepte erstellen, bearbeiten, löschen und teilen.
- Benutzer:innen können Rezepte exportieren (z. B. als Textdatei) und drucken.
- Benutzer:innen können Rezepte suchen oder auf Basis ihrer Vorräte Vorschläge erhalten, inkl. Berücksichtigung von Kosten, Mengen und Haltbarkeit.
- Benutzer:innen können Vorräte verwalten, Lagerort und Menge pflegen sowie Haltbarkeit überwachen.
- Benutzer:innen erhalten Hinweise auf ablaufende oder bereits abgelaufene Vorräte.
- Jede:r Benutzer:in verwaltet eigene Rezepte und Vorräte.


### 2.2 Nicht-funktionale Anforderungen
- Webanwendung mit responsivem Design (Desktop, Tablet, Mobile)
- Einhaltung von WCAG-Richtlinien
- DSGVO-Konformität
- Gute Performance und Skalierbarkeit (>1000)
- Erweiterbare Struktur

---

## 3. Rahmenbedingungen
- Technologiestack:
- Betrieb auf Linux-Servern und langfristig mit Anbindung als Phone - App
- Entwicklungszeitraum: ca. 6 Monate
- Budget: studentisches Projekt, keine externen Dienstleister

---

## 4. Abnahmekriterien
- Alle definierten Kernfunktionen müssen implementiert sein.
- Weitgehende Testabdeckung ist automatisiert Integriert und stellt die Qualität der Anwendung sicher.
- System läuft sicher und ist Performant.
- WCAG-konformität eingehalten.
- Datensicherheit ist anhand standard gewährleistet.
- Dokumentation anhand Arc42 deckt das System ab.
- Datenschutzanforderungen gemäß DSGVO werden eingehalten.