# E-commerce Demo Project for experimenting with .NET Core and Angular

# [Project demo](https://youtu.be/Twp0uTYXYeE)

## What This Project Has:

### Design Patterns and Strategies:
- **Repository Pattern**: Ensures decoupling of business code from data access, facilitating easy changes to the persistence framework with minimal effort. It promotes separation of concerns, minimizes duplicate query logic, enhances testability, and reduces code duplication.
    - Example: `HerStory.Infra>Data>GenericRepository`
- **Unit of Work Pattern**: Increases abstraction, keeps business logic free of data access code, and improves maintainability and testability. It introduces more classes and interfaces but significantly reduces code duplication.
    - Example: `HerStory.Infra>Data>UnitOfWork`
- **Specification Design Pattern**: Encapsulates queries within objects to simplify complex queries, such as paged searches for products.
    - Example: `HerStory.API>Specification`
- **Read-Optimisation Strategies**: Implemented to enhance data retrieval performance.
- **Asynchronous Methods**: Utilized extensively across both client and backend for improved performance and responsiveness.
- **OAuth2.0 Mechanisms**: Partially implemented with Google SSO for authentication, though user info is not persisted in the database.

### Core Features:
- **Product Catalogue**: Fully implemented with features like visibility of the entire catalogue without specific search queries, product categorization, pagination, and detailed product fields (Description, Image, Price, Title).
- **Product Search**: Fully implemented with configurable fields for search, case-insensitive search functionality, and a user-friendly search interface.
- **Login Process**: Partially implemented with Google Account SSO for checkout. Additional login information retrieval is designed but not fully integrated.
- **Discount Coupon System**: Partially implemented with the ability to input discount codes during checkout. The system supports flat discounts, percentage discounts with a max limit, and percentage discounts with no max value. The UI for this feature is not completed, but the database design is in place.
        
 ## TODO:
    - back-end : Implemet redis for basket management 
    - back-end : Dockerize the application
    - back-end : implement Identity with google SSO properly
    - back-end : Order management
    - back-end : Coupon management
    - back-end : Payment management
    - client : Introduce authguard
    - client : Coupon management
     
 ### Prerequisites to run the project 
 
 You will need the following tools:
 
 - [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
 - [PostgreSQL](https://www.postgresql.org/download/)
 - [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.3 or later)
 - [Entity Framework Core .NET Core CLI](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet)

### Database create 

 - Create a database called `productdb` in PostgreSQL
 - Follow this sequence to populate database 
    1. populate `ProductType`
    2. populate `Product`
    3. populate `Coupon`
    4. populate `Order`  
  
### Database update

`dotnet ef database update -p HerStory.Infra -s HerStory.API`

### Run project

`dotnet run watch`

### Add new migration 

`dotnet ef migrations add InitialCreate -p HerStory.Infra -s HerStory.API -o Data/Migrations`

### Remove migration 

`dotnet ef migrations remove -p HerStory.Infra -s HerStory.API -o Data/Migrations` 

### Drop Database
`dotnet ef database drop -p HerStory.Infra -s HerStory.API` 

# Swagger UI
 Check Swagger UI `https://localhost:5001/swagger/index.html`

# Client
You don't need to run client site separately for demo, I have built the compressed version of the client in `wwwroot`.
run this if you want to edit any feature :)

## Requirement to run the client
- [Angular CLI](https://github.com/angular/angular-cli) version 10.0.5.
- [Node](https://nodejs.org/en/) version 14.2.0
- npm version 6.14.5 (npm installed with node so no worry)

## Development server

`cd Client` 

Run `npm install` (First time), 

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

#### NOTE: Don't forget the run the backend separately by using `dotner run watch`

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. directory. Use the `--prod` flag for a production build.

## Troubleshoot

- Always check your npm version before run
- For clean install just remove the `dist` and `node_module` folder and run `npm i` and `ng serve`