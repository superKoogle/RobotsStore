# Robots Store
## Description and Architecture

This is a robots shop site.
The project is written with ASP.NET Core 7.0
The architecture of the project is REST API based, and divided into 4 Layers: Controllers, Bussiness and Data layer. 
The layers communicate with each other through Dependency Injection, and using global Entities project.
DTO entities were also used, in order to prevent circular dependency between the objects and provide encapsulation.
The conversion from entities to DTO object and vice versa was done by AutoMapper.
The connection to the database via EntitiesFramework of Microsoft, in the method of db first.

Integrated Error Handling with dedicated middleware and logging to file.

Scalability - The functions are asynchronous all along the project (using async await), in order to maintain scalability.

Swagger is used in the project.

## Securing
Validations are made in both client and server sides, in order to prevent unneccessary network traffic and ensure safety.
All passwords used by users are strong, by using special libraries to ensure password strength.

## Configuration
The project is using `appsettings.json` file to hold configuratins settings, such as connection string and log targets.

## Dependencies
### Frameworks
- ASP.NET Core 7.0
### Packages
- Entity Framework Core
- NLog
- zxcvbn-core
- Swashbuckle


## Installation
1. Clone the repository to your local machine.
2. Open the project in your preferred IDE.
3. Run the application.
## Usage
1. Open a Application pages or use swagger.
2. Navigate to the API endpoints to interact with the application.
