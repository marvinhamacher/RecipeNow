<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 03 – Kontextabgrenzung

## Fachlicher Kontext

Das System **„RecipeNow“** ist eine webbasierte Anwendung zur **Verwaltung von Rezepten und Vorräten**.  
Es unterstützt Nutzer:innen dabei, Zutaten zu organisieren, Rezepte anzulegen und den aktuellen Vorratsbestand zu verwalten.

Die Interaktion mit dem System erfolgt ausschließlich über eine Weboberfläche. Administrative Aufgaben werden über speziell autorisierte Bereiche durchgeführt.

Folgende externe Akteure und Systeme interagieren mit RecipeNow:

| Externe Instanz        | Beschreibung                                                                 |
|------------------------|------------------------------------------------------------------------------|
| **Nutzer:innen**       | Verwalten Rezepte, Zutaten und Vorräte über die Weboberfläche                |
| **Administrator:innen**| Verwalten Benutzerkonten und systemweite Einstellungen                       |
| **Barrierefreiheitsprüfende** | Überprüfen die Umsetzung der WCAG-2.2-Richtlinien                         |
| **Datenschutzbeauftragte:r** | Prüft die Einhaltung datenschutzrechtlicher Vorgaben (z. B. DSGVO)       |
| **Benachrichtigungssystem** | *Zukunftsplanung*: Versand von systeminternen Benachrichtigungen         |

---

## Technischer Kontext (Diagramm)

```mermaid
graph TD
    A[Nutzer:innen] -->|Web-UI| S[RecipeNow]
    B[Administrator:innen] -->|Web-UI im Admin-Bereich| S
    C[Barrierefreiheitsprüfende] -->|Review / Feedback| S
    D[Datenschutzbeauftragte:r] -->|Audit| S

    S -.->|zukünftig| N[Benachrichtigungssystem]
