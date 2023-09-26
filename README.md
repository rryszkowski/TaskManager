# TaskManager
This is a sample project presenting using CQRS with MediatR.

## Architecture
Project is built using Clean Architecture approach. It is divided into 4 layers:
* Presentation - REST API with classic controllers
* Application - use cases
* Domain - business logic and repository interfaces
* Infrastructure - infrastructure layer

## Technologies
* .Net 7.0
* CQRS
* MediatR
* Docker
* REST

## Database
* MongoDB

## Tests
* Architectural tests
* Integration tests in Docker
 
### Libraries in tests
* xUnit
* Moq
* FluentAssertions
* NetArchTest.Rules

## Side notes
* AssemblyReference static classes in each project are used to reference projects with reflections.
* MongoMaps static class in infrastructure is for configuring MongoDB entities, similarily to EF fluent API configuratio.