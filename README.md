# Regions Catalog Service

This service provides used with all basic CRUD operations on regions.

### Technologies
Used technologies are: ASP.NET CORE 3.1, Dapper (lightweight ORM), Oracle (RDBMS).

I chose Dapper over EF because current project is small and uses elementary data scheme so there is no need in full-feature ORM like EF (it will only slow app down).

While development Oracle RDBMS was launched in docker container.

### Interface (UI)
For convenience (and demo) purposes Swagger (interactive Postman-like way to mess around with API) specification was implemented. Demonstration of API with use of Swagger located in /demo folder.

### Structure / architecture
Project structured in a 'Clean Architecture'-like (Robert Martin) style. 

### Possible improvements
- Use Unit Of Work pattern over Repositories to unify working with DB.
- Add centralized error handling (e.g. middleware).
- Transform Resources to DTO if more adjacent services will appear and data interchange will increase (all that will live in RegionsDirectory.Common project).
- Caching. For the beginning simple In-memory caching will be enough since there is only one service. But further Distributed cache with Redis or Memcached can be implemented on purpose.
- Unit tests.

Currently have no time for caching (with current structure in-memory caching will be tricky to implement, hard to cache resources retrieved with filters and no need in caching all collection) and unit tests (as always...)