# Northwind application

Northwind Traders Access database is a sample database that shipped with Microsoft Office suite. The Northwind database contains sales data for a fictitious company called Northwind Traders, which imports and exports specialty foods from around the world.

The sample application is to learn the best practices and patterns in ASP.NET Core and domain drive design. The Northwind Traders application domain per se is not a complex domain and this application is to learn domain-driven design. Microsoft recommends it only for complex domains where the model provides clear benefits in formulating a common understanding of the domain. 

## Core

Application Core processes request and generates result. Mediator pattern can ease the job to send the request(query/command) to the right handler.

Application Core has features (business logic) to handle the requests.

The core should contain all the business logic. Business logic should not depend on operating system-specific or persistence specific technologies. Infrastructure may change along the way as technology evolves, but often the application domain models changes slower that the infrastructure.

Application core should do the heavy lifting to ease the pain for fellow developers. Take care of the common repetitive workloads like data parsing, converting, mapping, formatting, etc.,

Keep it stupidly simple and don't over-engineer, create the abstractions for the feature, mock it and set up unit tests, implement  and use test cases to verify the implementation, refactor the code, use tests to make sure all specifications are met.

### Models

The domain entities are used by persistence, should not have any dependencies on others. Entities have CRUD operations from a persistence.

Many other models conceptualize or organize the data in structure. They are materialized by specification to contain the results to return.

Application Core works on models and contracts (interfaces / abstractions) only, don't put concrete implementation inside. To promote contracts can lead to loose coupling of the modules, easier for testing and improve maintainability.

In implementation you can use 3rd party or open source projects to speed up the development process. But the Core should be protected. The less 3rd-party libraries, the less dependencies, and the architect is cleaner.

The common modules can be abstracted at the application level:

* persistence (repository, unit of work, transaction, ...)
* validation
* logging, auditing
* mapping between types
* formatting results (JSON/XML)
* Identity (authentication and authorization)
* 3rd party services (email, media processing)

It can utilize Microsoft.Extensions packages as they are helpful and already used in many .NET official packages.

Models can be bound together by a root entity to become an aggregate which has a group of features. 

## Infrastructure

Implement the services, features needed to make the application work.

Usually it handles security (authentication and authorization), HTTP request and responses, performance, data persistence.

### API

The application programming interfaces offering services to user interface and/or other services communicates with it.

Dependency injection in API wires up the abstractions and implementations for Domain, i.e., IRepository and EFCore, logger and Serilog, IMapper and Automapper.


### Persistence

Implement the CRUD operations.

It can be EFCore, Dapper, ADO.NET, as long as they implement the contract.

## Unit tests

