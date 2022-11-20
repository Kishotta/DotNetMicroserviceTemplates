# DotNetMicroserviceTemplates

## Installation

You can install the latest version of the templates using the `dotnet new` CLI:
```
dotnet new --install Kishotta.Utilities.Microservice.Templates
```

To uninstall the templates, se the `dotnet new` CLI:
```
dotnet new --uninstall Kishotta.Utilities.Microservice.Templates
```

## Usage

To effectively use these templates, you'll need an existing dotnet solution to attach the projects to. You can create this by:

- Create a new folder for your application with `mkdir MyAwesomeApp` then navigate into it with `cd MyAwesomeApp`
- Create a `src` folder to seperate application code from repository concerns: `mkdir src` `cd src`
- Create a dotnet solution to build and bundle your `.csproj` projects: `dotnet new sln --name MyAwesomeApp`
- Create a new folder for your application microservices with `mkdir Services` then navigate into with `cd Services`
- Create a new microservice using the `microservice` template: `dotnet new microservice --name MyAwesomeService`
- Run the new service and try out the swagger page with `cd MyAwesomeService/MyAwesomeService.Api` and `dotnet run` 
