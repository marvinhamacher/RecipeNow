<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 10 – Qualitätsanforderungen

Dieses Kapitel beschreibt die nicht-funktionalen Anforderungen an das System Studurizer. Die Ziele orientieren sich an den Qualitätsattributen nach ISO/IEC 25010.

---

## Testbarkeit

- Für alle Create, Read, Update, Delete - Methodik ist eine automatisierte Testabdeckung vorgesehen.
- Es werden vorrangig Unit- und Integrationstests eingesetzt.
- Alle Tests laufen automatisiert im Rahmen des Build- und CI-Prozesses ab.

---

## Verständlichkeit und Clean Code

- Der Quellcode ist selbsterklärend, klar strukturiert und gut nachvollziehbar.
- Kommentare werden sparsam und ausschließlich bei komplexer Logik verwendet.
- Die Benennung von Klassen, Methoden und Variablen erfolgt sprechend und konsistent nach gängigen .NET-Best Practices.
- Die Anwendung folgt einer klaren Schichtenarchitektur (z. B. UI, Services, Datenzugriff).
- Das Projekt verfügt über eine ausführliche Projektdokumentation, welche Ziele, Umfang und Abgrenzungen des Systems eindeutig beschreibt.
- Eine README-Datei erleichtert das Aufsetzen, Konfigurieren und Starten der Anwendung.

---

## Barrierefreiheit

- Das System orientiert sich an den Richtlinien der WCAG 2.2.
- Es werden regelmäßige manuelle Tests mit Screenreadern und Tastaturnavigation durchgeführt.
- Farbkontraste, Fokuszustände und semantische HTML-Strukturen werden geprüft.
- Razor Pages und Blazor Components werden barrierearm umgesetzt.

---

## Sicherheit

- Passwörter werden gehasht und gesalzen gespeichert (ASP.NET Identity Standard).
- Der Zugriff auf geschützte Funktionen erfolgt rollen- und autorisierungsbasiert.
- Eingaben werden sowohl client- als auch serverseitig validiert.
- Schutzmechanismen wie Anti-Forgery-Tokens und sichere Session-Verwaltung werden eingesetzt.
- Eine öffentliche Registrierung ist nicht vorgesehen.

---

## Benutzerfreundlichkeit

- Die Benutzeroberfläche ist intuitiv, modern und übersichtlich gestaltet.
- Visuelle Effekte werden bewusst eingesetzt, ohne die Barrierefreiheit zu beeinträchtigen.
- Die Anwendung bietet eine klare Navigation und konsistente Interaktionsmuster.
- Das Design ist responsiv und auf Desktop- sowie mobilen Endgeräten nutzbar.

---

## Wartbarkeit

- Modularer Aufbau durch Razor Pages, Blazor Components und Services.
- Klare Trennung von Darstellung, Geschäftslogik und Datenzugriff.
- Einheitliche Projektstruktur innerhalb der ASP.NET-Lösung.
- Einsatz von Docker zur Sicherstellung reproduzierbarer Entwicklungs- und Testumgebungen.
- Dokumentation und README unterstützen eine langfristige Wartung und Erweiterbarkeit.
