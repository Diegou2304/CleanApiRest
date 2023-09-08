# Clean Api Rest
A template for an API using Clean Architecture and SOLID Principles

## A project which uses Clean Architecture

A starting point for Clean Architecture with .NET Core.

CleanApiRest is one of many projects whose purpose is to show how a project could be implemented following SOLID principles and Clean Architecture.
This project utilizes Entity Framework Core, AutoMapper, SQL Server, MediatR and CQRS Design pattern.
## Important note
Note that the goal of this project and repository is not to provide a sample or reference application. It's meant to just be a template, but with enough pieces in place to show you where things belong as you set up your actual solution.


## Table Of Contents

- [Clean Api Rest](#clean-api-rest)
- [Getting Started](#getting-started)
  - [Using GitHub Repository](#using-github-repository)
  - [Create SQL Server Database](#create-sql-server-database)
  - [Update Connection String](#update-connection-string)
  - [Running Migrations](#running-migrations)
  - [Run the project](#run-the-project)
- [Goals](#goals)
  - [The main goal is you](#the-main-goal-is-you)
- [Design Decisions and Dependencies](#design-decisions-and-dependencies)
  - [The Api Project](#the-api-project)
  - [The Application Project](#the-application-project)
  - [The Infrastructure Project](#the-infrastructure-project)
  - [MediatR](#mediatr)
  - [Fluent Validation](#fluent-validation)
  - [AutoMapper](#auto-mapper)
- [Special Thanks](#special-thanks)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!


## Versions

The master branch is now using .NET 7 and EF Core 7. 

# Getting Started

To use this template, there is one option:

- Download this Repository (and modify as needed)

 ## Using GitHub Repository
 
To get started based on this repository, you need to get a copy locally. You have three options: fork, clone, or download. Most of the time, you probably just want to download.

You should **download the repository**, unblock the zip file, and extract it to a new folder if you just want to play with the project or you wish to use it as the starting point for an application.

You should **fork this repository** only if you plan on submitting a pull request. Or if you'd like to keep a copy of a snapshot of the repository in your own GitHub account.

You should **clone this repository** if you're one of the contributors and you have commit access to it. Otherwise you probably want one of the other options.
## Create SQL Server Database

The project uses one SQL Database, but is not programmed to create one from scratch. Please, create it using SQL Management Studio and
name it as you wish.
## Update Connection String

Inside the CleanApiRest.Api folder the file appsettings.development.json can be found. Please, once you have created the database, update the file 
with the database connection string.

```
{
  "ConnectionStrings": {
    "ConnectionString": "`Connection String"
  }
}
```
## Running Migrations
In Visual Studio, open the Package Manager Console, and run `Add-Migration InitialMigrationName`

After the migrations folder is created, please execute the following command `update-database`

**Important, you must select the CleanApiRest.Infrastructure in the Paquect Manager Console as the default project when executing these commands**

## Run the project

The solution file is located inside the CleanApiRest.Api folder, it has to be selected as an startup project.

To do that please right-click on CleanApiRest.Api project and select the option **Configure as default startup project**


# Goals

## The main goal is you


The goal of this repository is to provide a template that can be used as an starting point for your projects so you don´t have to worry about getting everything set from scratch. It follows SOLID principes using .NET Core.

Furthermore, the **MOST IMPORTANT REASONS BEHIND THE CREATION OF THE REPOSITORY** is to provide from beginners to intermediate developers a way to structure a project and also to share my knowledge to the community

Note that the goal of this project and repository is **not** to provide a sample or reference application. It's meant to just be a template, but with enough pieces in place to show you where things belong as you set up your actual solution.
# Design Decisions and Dependencies

There were several decision that were made in order to create this repository. Next, The three core layers of the solution will be explained and the tools which were utilize as well. 

## The Api Project

The api project basically consists on controllers and a middleware which are implemented in a way decoupling was achieved.

The folder structure is the following

```
|--Controllers
||--CarController
|--ApplicationMiddleware.cs
```

### Controllers

Each controller in this solution uses IMediator with the objective of decoupling it. Each action when executed
IMediator handles the request and delivers it to the application layer. Specifically to the Classes that implements
**IRequestHandler** interface inside the application layer.
```
 [ApiController]
  
    public class CarController : ControllerBase
    {
       
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
           
            _mediator = mediator;

        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<IEnumerable<GetCarsQueryResponse>>> Get([FromQuery] string? color)
        {
            var query = new GetCarsQueryResponse
            {
                Color = color,
            };

            var cars = await _mediator.Send(query);

            return Ok(cars);
            
        }
   }
```

### Middleware
There is one middleware that is registered in Program.cs
```
app.UseMiddleware<ApplicationMiddleware>();
```
The middleware's main task is to handle the response in case an exception is thrown by the handler class inside the application layer.


**The referential image shows a sneak peak of how the ASP.NET middleware works.**
![Alt text](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/index/_static/request-delegate-pipeline.png?view=aspnetcore-7.0)

## The Application Project

Each functionality, endpoint or request is handled by 3 main classes which are build, in this particular case, inside the Cars folder.

The proposed structure is the following
```
|-Feature
|--Functionality
    -Command or Query Class
    -Handler Class
    -Validator Class
```

If the proposed structure is followed, each entity's functionality must have its own classes inside the Funcionality folder.

## The Infrastructure Project

Most of your application's dependencies on external resources should be implemented in classes defined in the Infrastructure project. 

The Infrastructure project depends on `Microsoft.EntityFrameworkCore.SqlServer`.
## MediatR
MediatR is used in the Application and Api layer with the objective of decoupling the funcionalities and responsabilities.

This tools is implemented as follows:


**Dependency Inyection of the mediator Interface in CarController.cs**
```
 private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
           
            _mediator = mediator;

        }
```
**Interface Implementation of the IRequestHanlder Interface in Handler.cs**
```
 public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
```

**Interface Implementation of the IRequestHanlder Interface in Command/Result.cs**
```  
public class CreateCarCommand : IRequest<int>
```

Finally, all the services that MediatR uses are registered inside the ApplicationServiceRegistration.cs

```
 services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
```
## Fluent Validation

Each Command or Request classes have their on validator class which inherits from the AbstractValidator.cs: 
```
AbstractValidator<CreateCarCommand>
```

All validations that are written are registered in the **ApplicationServiceRegistration.cs**

```
services.AddFluentValidationAutoValidation();
```
## Auto Mapper

AutoMapper is used to avoid the exposition of domain entities to the client. it's used inside the controller or handler classes

To add more profile mappings just add them to the **MappingProfile.cs** class

```
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>();
            CreateMap<Car,GetCarsQueryResult >();
            CreateMap<Car, GetCarByIdResult >();
            //Add new Map
        }
     
    }
```

Also all the mappings profiles are being registered inside the **ApplicationServiceRegistration.cs**

``` 
services.AddAutoMapper(Assembly.GetExecutingAssembly());
```
# Special Thanks

Special thanks to my friends and colleagues who helped me by reviewing this project and by giving me directions and recommendations.

* [Luis Gerardo Figueroa Zurita](https://www.linkedin.com/in/luis-gerardo-figueroa-zurita-191242129/)
* [Ivan Mijael Vargas Bravo](https://www.linkedin.com/in/ivan-mijael-vargas-bravo-6323b5199/)


