ADependencyInjection
===================
- where we register all auto-mapper profiles inside dependency Injections system of .Net Core
- where we register all mediators services configurations inside dependency injection system of .Net Core

Contracts
===========
- where all interfaces for persistence or infrastructure live

CQRS
=====
- stand for (Command and Query Responsibility Seggregation)
- this pattern used to seperate commands actions from query actions
- we use extension called (mediator) its behavioral design pattern to implement CQRS Pattern

HandleExceptions
================
- its way to handel custom exceptions 

ObjectMapping (AutoMapper)
==========================
- is Extension For .Net Core to Mapping Between Objects , mean convert from object to another 
- we can use it to convert from entities to view models (DTO) data Transfer Object to reduce the details of entity as source to the target DTO (ViewModel) that will be interacted with UI



Validation (Fluent Validation)
==============================
- extension for make validation over DTO objects


