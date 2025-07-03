# Lazy Loading
## Definition:
Lazy Loading bedeutet, dass Navigations-Properties erst beim Zugriff aus der Datenbank geladen werden – nicht sofort beim Query.

Erfordert Konfiguration (UseLazyLoadingProxies + virtual + Proxy-Paket)

# Eager Loading
## Definition:
Eager Loading bedeutet, dass alle benötigten Daten per .Include() direkt in der ersten Query geladen werden.

**Eager Loading ist der Standard in EF Core 8**

