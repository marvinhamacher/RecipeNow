<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 02 – Randbedingungen

In diesem Kapitel werden die nicht-funktionalen Anforderungen sowie die technischen, organisatorischen und rechtlichen Rahmenbedingungen für das System „RecipeNow“ beschrieben. Diese Randbedingungen sind verbindlich für Planung, Architektur und Entwicklung.

---

## Technische Randbedingungen

- Datenbank: SQLite  
  Leichtgewichtige, dateibasierte relationale Datenbank, geeignet für Prototypen und kleinere Deployments.

- Web-Framework: ASP.NET  
  Umsetzung der Anwendung mit Razor Pages und Blazor Components innerhalb des .NET-Ökosystems.

- Programmiersprache: C#  
  Einheitliche Programmiersprache für Frontend- und Backend-Logik.

- Containerisierung: Docker  
  Nutzung von Containern zur Sicherstellung reproduzierbarer Entwicklungs-, Test- und Laufzeitumgebungen.

- Serverumgebung:  
  Lokale Ausführung während der Entwicklung sowie Deployment auf einem Linux-Server mittels Docker.

---

## Organisatorische Randbedingungen

- Benutzerverwaltung:  
  Benutzerkonten werden administrativ angelegt; eine öffentliche Registrierung ist nicht vorgesehen.

- Zugangskontrolle:  
  Rollensystem mit mindestens zwei Rollen:
    - User
    - Admin  
      Erweiterungen des Rollenkonzepts sind grundsätzlich möglich.

- Barrierefreiheit:  
  Die Benutzeroberfläche ist gemäß den Richtlinien der WCAG 2.2 zu gestalten.

- Projektumfang:  
  Entwicklung erfolgt in einem kleinen Team mit begrenzten zeitlichen Ressourcen.

---

## Rechtliche Randbedingungen

- Datenschutz:  
  Verarbeitung personenbezogener Daten erfolgt unter Berücksichtigung der DSGVO. Es werden nur notwendige Daten gespeichert.

- Barrierefreiheit:  
  Orientierung an anerkannten Standards zur digitalen Barrierefreiheit, insbesondere WCAG 2.2.

- Open-Source-Komponenten:  
  Es dürfen ausschließlich Open-Source-Komponenten verwendet werden, deren Lizenzen eine Weiterverwendung erlauben (z. B. MIT, Apache 2.0).

---
