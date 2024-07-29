Entities
========
- represent any object with id like Person


Value Object
============
- represent any object without id like Adress

Aggregate Roots
===============
- represent any entity that hold multi entity as its children like Order with OrderItems
- all child entities come from db as once and updated as once
- its like transaction boundary like invoice and invoice lines

Notifications
===============
- its like events that will raised inside entities (RaiseNotification) and we will use mediator to handle this notifications