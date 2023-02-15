# Northwind application

Northwind Traders Access database is a sample database that shipped with Microsoft Office suite. The Northwind database contains sales data for a fictitious company called Northwind Traders, which imports and exports specialty foods from around the world.

Microsoft recommends it only for complex domains where the model provides clear benefits in formulating a common understanding of the domain. Northwind Traders is not a complex domain and this application tries to use domain-driven design.

## Core

The domain entities should not have any dependencies on others.

Application works on domain models and contracts (interfaces / abstractions) only, don't put concrete implementation inside. To promote contracts can lead to loose coupling of the modules, easier for testing and improve maintainability.

The common modules can be abstracted at the application level:

* persistence (repository, unit of work, traction, ...)
* validation
* logging, auditing
* mapping between types
* Identity (authentication and authorization)
* 3rd party services (email, media processing)

Models can be bound together by a root entity to become an aggregate which has a group of features. 

It can utilize Microsoft.Extensions packages as they are helpful.

## Infrastructure

Implement the services, features needed to make the application work.

### Persistence

Implement the CRUD operations.

It can be EFCore, Dapper, ADO.NET, as long as they implement the contract.

## Unit tests

