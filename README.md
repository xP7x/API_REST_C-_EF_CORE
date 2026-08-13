# API_REST_C-_EF_CORE
ASP.NET Core RESTful API for managing Dragon Ball Z characters — CRUD with Entity Framework Core.


ProjetoDBZ is a lightweight RESTful API built with ASP.NET Core 7 and Entity Framework Core to manage Personagem resources (create, read, update, delete). It includes model validation, database migrations, and conventional HTTP responses (Created, Ok, NotFound, BadRequest). Endpoints are exposed under /api/personagens.
Quick highlights:

Features: CRUD endpoints, model validation, EF Core migrations, async actions, HTTP status semantics.
Tech stack: ASP.NET Core 7, Entity Framework Core, C#, .NET CLI.
Quick start:
Restore & build: dotnet restore && dotnet build
Apply migrations: dotnet ef database update
Run: dotnet run
