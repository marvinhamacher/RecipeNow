<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# Pflichtenheft für die Lernplattform „RecipeNow"
## 1. Einleitung
### 1.1 Ziel des Dokuments
Dieses Pflichtenheft beschreibt die konkrete technische Umsetzung der Anforderungen aus dem Lastenheft für die Lernplattform „Studurizer".
"Ziel des Projekts „Studurizer“ ist die Entwicklung eines innovativen, barrierearmen Kursverwaltungssystems, das sich an etablierten Systemen wie MyCampus, Itslearning oder Iserv orientiert – jedoch mit einem stärkeren Fokus auf Barrierefreiheit und dem Einsatz neuer Technologien. Es wird als Webanwendung mit dem Framework Django realisiert."

### 1.2 Verantwortlichkeiten

- Auftraggeber: Bildungsinstitutionen
- Auftragnehmer: Study4U
- Projektleitung: Marvin Hamacher

## 2. Systemübersicht
„Studurizer“ ist eine Webanwendung, die mit dem Django-Framework (Python) entwickelt wird.
Für das Frontend werden HTML, CSS und JavaScript genutzt. Die Datenhaltung erfolgt über eine SQLite-Datenbank.
Der Fokus liegt auf intuitiver Benutzerführung, Barrierefreiheit und Erweiterbarkeit.

## 3. Technische Umsetzung der Anforderungen
### 3.1 Funktionale Anforderungen und deren Umsetzung
| Modul             | Beschreibung                                                                     |
| ----------------- | -------------------------------------------------------------------------------- |


### 3.2 Nicht-funktionale Anforderungen und deren Umsetzung

| Anforderung       | Umsetzung                                                                 |
| ----------------- |---------------------------------------------------------------------------|
| Modularität       | Trennung in klare Softwareteile und Namespaces wurden deutlich eingeteilt |
| Datenspeicherung  | SQLite für schnelle Entwicklung und einfache Wartung                      |
| Sicherheit        | CSRF-Schutz, Passwort-Hashing, Rechteverwaltung                           |
| Erweiterbarkeit   | Nutzung von ASPNET und Razor Best Practices, Modulare Architektur         |
| Responsive Design | Bootstrap Columns und Rowsysteme um resizablity zu ermöglichen            |

## 4. Architektur und Systemdesign

### 4.1 Systemkomponenten

* **Backend:**  
* **Datenbank:** SQLite
* **Frontend:** HTML, CSS, JavaScript/Razor embedded Code
* **TXT-Export:**

### 4.2 Beispielhafte Datenbankstruktur (Auszug)

#### Tabelle: courses

| Id | Name  | PricePerUnit | Measurement |
|----|-------|--------------|-------------|
| 1  | Gurke | 1.5f         | 0           |

## 5. Testfälle und Abnahme

### 5.1 Testfälle



### 5.2 Abnahmekriterien



## 6. Zeit- und Ressourcenplanung

### 6.1 Zeitplan

| Phase          | Zeitraum |
| -------------- |----------|
| Planung        | 1 Woche  |
| Umsetzung      | 2 Wochen |
| Test & Abnahme | 2 Woche  |

### 6.2 Ressourcen

* 2 Entwickler\:innen (1 Richtung Dokumentation, Schulung, Fullstackentwicklung und Architektur, 1 Richtung xxx)

---

Letzte Aktualisierung: 06. Mai 2025
