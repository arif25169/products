# Products

This solution contains three components

## ProductsAPI
This is the REST CRUD api in .net that uses IoC with autofac,
entity framework for ORM, automapper (for DTO to entity conversion),
 FluentValidation with webapi integration (with a customization to register with autofac)
, and a custom abstract implementation of services and an abstract CRUD controller to
simplify creation of REST CRUD endpoints

## ProductsDomain
This is a shared library to expose the database entities and business logic
services

## SPA
This is the single page application using bootstrap to present the UI
with interaction to the ProductsAPI.  Node, NPM, and yarn are required to build
the JS application

### Additions
To make this a production ready application, these are some examples of
functionality that would be required
* Authentication/Authorization
* Service hooks for before and after create/update actions
* Audit abilities for database data modifications
* Enhanced logging for troubleshooting issues, currenlty limited error logs are written
* Unit tests to cover both server side and client side code
