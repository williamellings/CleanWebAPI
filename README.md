# CleanWebAPI

**CleanWebAPI** is a modern, secure ASP.NET Core Web API built following the principles of **Clean Architecture** and the **CQRS (Command Query Responsibility Segregation)** pattern. The project is designed to be scalable, testable, and maintainable by strictly separating concerns across its architectural layers.

## 🏛 Architecture Overview

The project is divided into four distinct layers, ensuring that the business logic remains independent of external frameworks:

* **Domain Layer**: The core of the application. It contains the enterprise entities (`Product`, `Category`) and the repository interfaces that define how data should be handled without knowing the implementation details.
* **Application Layer**: Orchestrates the business flow using the **CQRS** pattern with **MediatR**. It includes DTOs, AutoMapper profiles, and a **Pipeline Behavior** for automatic request validation via FluentValidation.
* **Infrastructure Layer**: Handles data persistence and external concerns. It implements the `DbContext` for Entity Framework Core and provides concrete implementations for the repositories using SQL Server.


* **API Layer**: The entry point of the application. It manages HTTP requests through Controllers, configures the Dependency Injection (DI) container, and handles JWT-based authentication and authorization.



## ✨ Key Features

* **Full CRUD Operations**: Complete lifecycle management (Create, Read, Update, Delete) for Products, including a one-to-many relationship with Categories.
* **JWT Authentication**: Secure endpoints protected by JSON Web Tokens.
* **Role-Based Access Control (RBAC)**: Fine-grained authorization with `Admin` and `User` roles. For example, deleting a product is restricted to the `Admin` role.
* **Automated Validation**: Requests are automatically validated before reaching the handlers using MediatR Pipeline Behaviors.
* **DTO Mapping**: Entity internal structures are never exposed; data is mapped to DTOs using AutoMapper.

## 🛠 Tech Stack

* **Framework**: ASP.NET Core 10.0
* **Database**: SQL Server with Entity Framework Core
* **Mediation**: MediatR (CQRS)
* **Mapping**: AutoMapper
* **Validation**: FluentValidation
* **Documentation**: Scalar & OpenApi

## 🚀 Getting Started

### Prerequisites

* .NET 10 SDK
* SQL Server (or SQL Express)

### Installation

1. Clone the repository to your local machine.
2. Navigate to the `CleanWebAPI.API` project folder.
3. Update the `DefaultConnection` string in `appsettings.json` to point to your SQL Server instance.
4. Open your terminal/Package Manager Console and run the following command to apply migrations and create the database:


```bash
dotnet ef database update --project ../CleanWebAPI.Infrastructure --startup-project .

```


5. Run the application:
```bash
dotnet run

```



## 📖 API Documentation

Once the application is running, you can explore and test the endpoints using the built-in **Scalar** documentation:

* **URL**: `https://localhost:7017/scalar/v1` (or your local port)

## 🔐 Authentication & Roles

The API uses JWT Bearer tokens for authentication. To test protected endpoints, you must first log in to receive a token.

### Test Credentials

| Role | Username | Password |
| --- | --- | --- |
| **Administrator** | `admin` | `password` |
| **Standard User** | `user` | `password` |

**Steps to test**:

1. Send a `POST` request to `/api/Auth/login` with the credentials above.
2. Copy the `token` from the response.
3. In Scalar or Postman, add the token as a **Bearer Token** in the `Authorization` header for subsequent requests.
