# Product CRUD API

you can do this project by Leveraging Custom PostgreSQL Functions in EFCore by following steps:

##1. Create the PostgreSQL Function

    ```
    CREATE OR REPLACE FUNCTION get_all_products() RETURNS SETOF products AS $$
    BEGIN
        RETURN QUERY SELECT * FROM products;
    END;
    $$ LANGUAGE plpgsql;
    
    CREATE OR REPLACE FUNCTION insert_product(p_name VARCHAR, p_price DECIMAL) RETURNS VOID AS $$
    BEGIN
        INSERT INTO products (name, price) VALUES (p_name, p_price);
    END;
    $$ LANGUAGE plpgsql;
    ```

##2. Map the Function to EF Core DbContext

```
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } // Assuming Product model exists

    // Define DbFunction for getAll()
    [DbFunction("get_all_products", Schema = "public")]
    public virtual IEnumerable<Product> GetAllProducts() 
    {
        // The actual implementation will be provided by EF Core at runtime
        throw new NotImplementedException();
    }

    // Other DbSet and DbFunction definitions
}
```
##3. Register the Function in Migration
```
dotnet ef migrations add AddGetAllProductsFunction
dotnet ef database update
```

##4. Use the Function in Your API
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _context.GetAllProducts().ToList();
        return Ok(products);
    }

    // Other API endpoints
}
##Notes
Security and Validation: Ensure that your PostgreSQL functions and mappings are secure and validate inputs to prevent SQL injection.
Testing: Test your API endpoints and function mappings thoroughly to ensure they behave as expected.
Documentation: Update your README or project documentation to include details about custom PostgreSQL functions used in your API.
By following these steps, you can effectively integrate custom PostgreSQL functions into your .NET Core API project using Entity Framework Core, enabling more complex database operations directly from your API.


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



