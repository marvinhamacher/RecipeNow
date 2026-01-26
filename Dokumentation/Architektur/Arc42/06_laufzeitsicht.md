<!---
Artefakte der Systemdokumentation wurden teilweise auf basis
von ChatGPT (OpenAI) & der Projektvorlage Studurizer erstellt, und manuell angepasst.
Vorlage: https://github.com/Johann110/Studurizer-Fallstudie-Software-Engineering/tree/main/Systemdokumentation
-->
# 06 – Laufzeitsicht

Dieses Kapitel zeigt das dynamische Verhalten des Systems anhand exemplarischer Szenarien.

## 1. Registration eines Nutzers

Beim Login werden die Zugangsdaten überprüft, ein Token oder Session-Cookie erstellt und der Nutzer weitergeleitet.

```mermaid
sequenceDiagram
    participant Browser
    participant Frontend
    participant Backend (Authentication)
    participant DB

    Browser->>Frontend: Registration-Formular ausfüllen
    Frontend->>Backend (Authentication): Interner POST-Request
    Backend (Authentication)->>DB: Anlegung: UserIdentity mit E-Mail + Passwort-Hash anlegen
    DB-->>Backend (Authentication): Benutzer angelegt
    Backend (Authentication)-->>Frontend: NavigationManager zu '/'
    Frontend-->>Browser: Weiterleitung zur Homepage
```

## 2. Login eines Nutzers

Beim Login werden die Zugangsdaten überprüft, ein Token oder Session-Cookie erstellt und der Nutzer weitergeleitet.

```mermaid
sequenceDiagram
    participant Browser
    participant Frontend
    participant Backend (Authentication)
    participant DB

    Browser->>Frontend: Login-Formular ausfüllen
    Frontend->>Backend (Authentication): Interner POST-Request
    Backend (Authentication)->>DB: Anfrage: Nutzer mit E-Mail + Passwort-Hash
    DB-->>Backend (Authentication): Benutzer gefunden
    Backend (Authentication)-->>Frontend: Session-Cookie setzen, NavigationManager zu '/'
    Frontend-->>Browser: Weiterleitung zum Dash
```
## 3. Erstellung von Zutaten
```mermaid
sequenceDiagram
    participant Nutzer
    participant Frontend
    participant Backend (Services und Persistance von Ingredient)
    participant DB

    Nutzer->>Frontend: Formular „Neue Zutat“ (Nur Sichtbar für Admins)
    Frontend->>Backend (Services und Persistance von Ingredient): Interner Post (Name, Preis pro Einheit, Messangabe & Bildpfad)
    Backend (Services und Persistance von Ingredient)->>DB: INSERT neue Zutat
    DB-->>Backend Backend (Services und Persistance von Ingredient): Bestätigung
    Backend Backend (Services und Persistance von Ingredient)-->>Frontend: Erfolgs-Response, NavigationManager zu '/ingredients' 
    Frontend-->>Nutzer: Liste aktualisiert
```

<!---
Wird am ende vom Projekt um 2 Punkte Erweitert: Vorratskammer interkation sowie das vorschlagen von Rezepten
-->
