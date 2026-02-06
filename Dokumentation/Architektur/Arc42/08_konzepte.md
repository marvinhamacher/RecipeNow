<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 08 – Konzepte

Dieses Kapitel beschreibt zentrale Querschnittskonzepte, die unabhängig von einzelnen Modulen im gesamten System gelten.

---

## Sicherheitskonzept

- Authentifizierung und Autorisierung erfolgen über die integrierten Mechanismen von ASP.NET.
- Der Zugriff auf geschützte Bereiche ist rollenbasiert geregelt.
- Passwörter werden gehasht und gesalzen gespeichert (Standardmechanismen von ASP.NET Identity).
- Schutz vor typischen Webangriffen erfolgt durch:
  - Anti-Forgery-Tokens (CSRF-Schutz)
  - Serverseitige und clientseitige Validierung von Eingaben
- Es existiert keine öffentliche Registrierung; Benutzerkonten werden administrativ angelegt.

---

## Barrierefreiheitskonzept

- Umsetzung nach den Richtlinien der WCAG 2.2.
- Verwendung von semantischem HTML in Razor Pages und Blazor Components.
- Vollständige Bedienbarkeit per Tastatur.
- Unterstützung von Screenreadern durch korrekte ARIA-Attribute.
- Ausreichende Farbkontraste und sichtbare Fokuszustände.

---

## Benutzer- und Rollenkonzept

- Benutzer werden in zwei Rollen eingeteilt:
  - User:  
    Zugriff auf grundlegende Funktionen der Anwendung.
  - Admin:  
    Erweiterte Rechte zur Verwaltung von Inhalten und Benutzern.
- Jede Rolle besitzt eigene Pages bzw. Funktionsbereiche, die über Autorisierungsregeln abgesichert sind.
- Die Rollenprüfung erfolgt zentral über das ASP.NET-Autorisierungssystem.

---

## Persistenzkonzept

- Die Persistierung der Daten erfolgt über eine relationale SQLite-Datenbank.
- SQLite wird aufgrund der einfachen Integration und des geringen Administrationsaufwands eingesetzt.
- Das Persistenzmodell ist so gestaltet, dass ein späterer Wechsel auf eine andere relationale Datenbank grundsätzlich möglich ist.

---

## Fehlermanagement

- Fehler werden zentral behandelt und protokolliert.
- Benutzer erhalten benutzerfreundliche Fehlermeldungen, ohne interne Systemdetails preiszugeben.
- Technische Details werden ausschließlich für Entwicklungs- und Debug-Zwecke verwendet.
- Unerwartete Fehler führen nicht zum Abbruch der Anwendung.

---

## Benachrichtigungskonzept

- Rückmeldungen an Benutzer erfolgen primär über UI-Feedback (z. B. Erfolgsmeldungen oder Fehlhinweise).
- Benachrichtigungen werden kontextbezogen und verständlich dargestellt.
- Es werden keine externen Benachrichtigungssysteme (z. B. E-Mail oder Push) eingesetzt.
- Das Konzept ist erweiterbar, falls zukünftige Anforderungen zusätzliche Benachrichtigungskanäle erfordern.

---