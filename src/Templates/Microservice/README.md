# Microservice Service
 
## Clean Architecture

The Microservice Service is comprised of 6 projects, each responsible for a single piece of application logic:

- Api
  - Dependency Injection container configuration
  - API documentation generation (Swagger)
- Presentation
  - API contract specification
  - Routing
  - Authentication
- Application
  - Application logic
  - Error reporting
- Persistance
  - Data store access
  - ORM configuration
- Infrastructure
  - External service access (API, Service Bus, etc.)
- Domain
  - Domain logic
  - Invariant enforcement
  
These project layers work together to form a robust, testable, maintainable, and extensible system.
