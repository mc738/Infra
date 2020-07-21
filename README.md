# Infra

Infra is a library for handling boilerplate infrastructure in projects.

The goal is to reduce project set up time and handle concerns such as retrieving data and mapping objects.

# Repositories

The library provides a generic repository to lay for data access.

Initially it is set up to support Sql Server via Entity Framework Core,
however the goal is to offer various repositories (and flexibly to create your own).

# Specifications

The library uses specifications handle querying and aggregating data from repositories.

# Mapping

The library looks to handle object mapping via various methods such as:

* **Function Mapping**
    * Mapping objects via user specified functions.