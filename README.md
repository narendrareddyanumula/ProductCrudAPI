# Product CRUD API

A .NET Core API project for CRUD operations on a PostgreSQL database using clean architecture principles, with unit and integration testing included.

## Table of Contents

1. [Introduction](#introduction)
2. [Technologies Used](#technologies-used)
3. [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
4. [Configuration](#configuration)
5. [Running the Application](#running-the-application)
6. [Testing](#testing)
    - [Unit Tests](#unit-tests)
    - [Integration Tests](#integration-tests)
7. [Deployment](#deployment)
8. [Contributing](#contributing)
9. [License](#license)

## Introduction

This project implements a .NET Core API for managing products stored in a PostgreSQL database. It follows clean architecture principles to ensure separation of concerns and maintainability.

## Technologies Used

- .NET Core 6.0
- PostgreSQL 13
- Entity Framework Core 6.0
- AutoMapper
- xUnit for unit testing
- Moq for mocking
- Docker (optional, for deployment)

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Docker](https://www.docker.com/get-started) (optional)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/product-crud-api.git
   cd product-crud-api
2.Restore dependencies:
 dotnet restore
3.Set up the database:
 -Create a PostgreSQL database and update the connection string in appsettings.json.
### Configuration
Modify appsettings.json to set up database connections and any other configurations needed.

###Running the Application
  dotnet run --project WebApi/WebApi.csproj
###Testing
 ## Unit Tests
    dotnet test Core.UnitTests/Core.UnitTests.csproj
 ## Integration Tests
    1.Ensure the API is running locally.
    2.Run integration tests:
      dotnet test IntegrationTests/IntegrationTests.csproj



