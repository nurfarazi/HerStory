# HerStory foundation E-commerce

# [Project demo](https://youtu.be/Twp0uTYXYeE)

## Project Summery

- [x] What You are Looking For:
    - [x] Use of design patterns where appropriate.
        - Note : I spend most of the time here designing and structuring the project, 
        - Repository pattern
            - Decouple Business code from data Access. As a result, the persistence Framework can be changed without a great effort
            - Separation of Concerns
            - Minimize duplicate query logic
            - Increase Testability
            - For example please visit `HerStory.Infra>Data>GenericRepository`,
        - Unit of Work pattern
            - Increases the level of abstraction and 
            - Keep business logic free of data access code
            - Increased maintainability
            - Increased Testability
            - More classes and interfaces but less duplicated code 
            - For example please visit `HerStory.Infra>Data>UnitOfWork`, 
        - Specification Design pattern: This design pattern describes a query in an object. So to encapsulate a paged query that searches for some products
            - For example please visit `HerStory.API>Specification` 
    - [x] Understanding of read-optimisation strategies.
    - [x] Use of async methods. `100% Done`
        - Both client and backend are using async heavily you and look for it anywhere.
    - [x] Understanding of OAuth2.0 mechanisms. `50% Done`
        - Due to time constraint could not finish this part properly but you can login using google SSO but it does not save user info database. So it’s half done.    
- [x] Product Catalogue `100% Done`
    - [x] The entire catalogue is visible if the user does not make and specific search query.
    - [x] It should be possible to categorize products
    - [x] The product catalogue is paginated during display. 
    - [x] Each product has the following fields: 
        - [x] Description
        - [x] Image
        - [x] Price 
        - [x] Title  
- [x] Product Search `100% Done`
    - [x] The fields in which searching happens is configurable from system end.
        - Fully configurable: also you can add multiple field easily super easily by just changing the specification class, 
        for example please visit `HerStory.API>Specification>ProductSpec` 
    - [x] Search is case insensitive. 
    - [x] The customer can search for the product they want by typing into an input box and clicking "Search" 
        - Note: Because I did not managed to complete the authentication part properly this part also skipped.
- [x] Login Process `50% Done`
    - [x] In order to complete checkout, all customers must log in using Google Account SSO `50% Done`
        - Note : Due to time constraint could not finish this part properly.
    - [x] The customer should not be required to add any additional login information like name,  email etc, all should be retrieved from Google.
        - Note : It does take the user information but this application not doing anything with it.
    - [ ] Phone can be collected additionally if required.
            - Note : Due to time constraint could not finish this part properly. 
- [x] Discount Coupon `30% Done`
    - [x] During the checkout process the system allows the user to input a discount coupon code.
        - Note: Failed to complete its UI part in client site but designed the entity in database layer. Please check the `HerStory.Core>Entity>Coupon` model
    - [x] The coupon codes used are a few varieties. (UI Not Implemented)
        - [x] Gives a flat discount of a fixed amount = 300 BDT. 
        - [x] Gives a percentage discount with a max limit eg: 15% up to 300 BDT 
        - [x] Gives a percentage discount with no max value. 
        
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

 - Create a database called `her_story`
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
You dont need to run client site separately for demo, I have build the compressed version of the client in `wwwroot`.
run this if you want to edit any feature :)

## Requirement to run the client
- [Angular CLI](https://github.com/angular/angular-cli) version 10.0.5.
- [Node](https://nodejs.org/en/) version 14.2.0
- npm version 6.14.5 (npm installed with node so no worry)

## Development server

`cd Client` 

Run `npm install` (First time), 

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

#### NOTE: Dont forget the run the backend separately by using `dotner run watch`

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. directory. Use the `--prod` flag for a production build.

## Troubleshoot

- Always check your npm version before run
- For clean install just remove the `dist` and `node_module` folder and run `npm i` and `ng serve`