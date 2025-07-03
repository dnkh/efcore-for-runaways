# Lazy Loading
## Definition:
Lazy Loading bedeutet, dass Navigations-Properties erst beim Zugriff aus der Datenbank geladen werden – nicht sofort beim Query.

**Vorteile:**

- Einfach bei einzelnen Zugriffen

- Spart Datenbank-Last, wenn Navigation nicht immer gebraucht wird

**Nachteile:**

- Gefahr der N+1-Falle bei Listen

- Schwer zu debuggen

- Erfordert Konfiguration (UseLazyLoadingProxies + virtual + Proxy-Paket)


# Eager Loading
## Definition:
Eager Loading bedeutet, dass alle benötigten Daten per .Include() direkt in der ersten Query geladen werden.

**Vorteile:**

- Performance-kontrolliert

- Kein N+1

- Klare SQL-Struktur

- Logging-freundlich

**Nachteile:**

- Man lädt evtl. unnötig viele Daten

- Komplexe Includes können ineffizient werden 

**Eager Loading ist der Standard in EF Core 8**

# Demo
Zuerst starten wie die Anwendungen und schauen auf die Anzahl der ausgeführten Queries.
Hier werden wir bei Eager Loading sehen das nur eine Query ausgeführt wird

Im nächsten Schritt aktivieren wir Lazy Loading, und schauen dann wieviel Querys ausgeführt werden
Hier ist klar zu sehen das für jeden Eintrag in der Blog Tabelle eine Query an die Db geschickt wird.
Das ist das N+1 Problem


Wenn man genau weiß was man tut kann man hier etwas Traffic sparen, ansonsten kann man sich aber auch die Performance kaputt machen ;-)
