# Blog_Engine
Technical test API developed for Zemoga.

# Technical Implementation Details
The solution was implemented following good practices and a clean architecture. The technical details of the implemented solution are described below:

- The implementation was done using .Net Core 3.1.
- The Onion architecture was used.
- The ORM used was Entity Framework Core with the Code First approach.
- Data access was implemented using the Repository design pattern.
- The Unit Of Work design pattern was used for transaction control.
- A Middleware was implemented for exception handling, with the aim of controlling all generated exceptions.
- Application authentication is performed through JWT tokens.
- User password encryption is done using the SHA-256 algorithm.
- Data persistence was done in a SQL Server database.

# API Execution Manual
In the repository, in the path Manuales/ManualDeEjecución.Docx, you can find the execution manual with the step-by-step instructions for execution.
In the path Postman/Collection.Json, you can find the collection that can be imported into Postman to perform tests.

The estimated time for test execution is 35 minutes.
