# Query Optimisation

This repository contains code used for testing different methods of optimising queries in EF Core. The project consists of:
- A web API project
- A test suite

The API project contains the `DbContext` setup and configuration for entities. At the moment there is just an abstract `BaseEntity` class and a `Person` concrete class extending this. Additionally, there is a folder containing seed data (used in data migrations) and entity configurations to be used with the context. The project also contains a controller file with multiple classes, that return data in different ways. These different classes are used to test the time difference in endpoints. This project uses a SQL Server database with a connection string stored in `appsettings.json`

The test suite contains one test file currently, used to measure time differences. This project uses an InMemory database and stores comparisons of times in a CSV file locally. The CSV output shows the size of data being retrieved, the time taken, and the time difference between the methods being checked.