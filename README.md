[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg?style=flat-square)](https://opensource.org/licenses/MIT)
[![Open in Visual Studio Code](https://open.vscode.dev/badges/open-in-vscode.svg)](https://open.vscode.dev/meysamhadeli/University-Microservices)
# University-Microservices
> Implementing an University application with Domain-Driven Design and CQRS in .Net Core.

🌀 Keep in mind this repository is work in progress and will be complete over time 🚀

# Support ⭐
If you like my work, feel free to:

- ⭐ this repository. And we will be happy together :)


Thanks a bunch for supporting me!

## 1. The Goals of This Project

- the **microservices** with **DDD** implementation.
- correct separation of bounded contexts.
- example of communications between bounded contexts through asynchronous **rabbitMq**.
- example of simple **CQRS** implementation and **event driven architecture**.
- using **outbox pattern** for message passing between modules.
- using **best practice** and **design patterns**.

## 2. Plan
> This project is currently under development.

The issues are represented in [https://github.com/meysamhadeli/University-Microservices/issues](https://github.com/meysamhadeli/University-Microservices/issues)

High-level plan is represented in the table

| Feature | Status |
| ------- | ------ |
| Building Blocks | Completed ✔️ |
| Cources Service | Completed ✔️ |
| Departments Service | Completed ✔️ |
| Instructors Service | Completed ✔️ |
| Students Service | Completed ✔️ |
| API Gateway | Under Development 👷‍♂️ |
| Identity Server | Not Started 🚩 |


## 3. Technologies - Libraries
- ✔️ **[`.NET Core 5`](https://dotnet.microsoft.com/download)** - .NET aspnet-api-versioning)** - Set of libraries which add service API versioning to ASP.NET Web API, OData with ASP.NET Web API, and ASP.NET Core
- ✔️ **[`EF Core`](https://github.com/dotnet/efcore)** - Modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations
- ✔️ **[`CAP`](https://github.com/dotnetcore/CAP)** - An EventBus with local persistent message functionality for system integration in SOA or Microservice architecture
- ✔️ **[`FluentValidation`](https://github.com/FluentValidation/FluentValidation)** - Popular .NET validation library for building strongly-typed validation rules
- ✔️ **[`Swagger & Swagger UI`](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)** - Swagger tools for documenting API's built on ASP.NET Core
- ✔️ **[`Serilog`](https://github.com/serilog/serilog)** - Simple .NET logging with fully-structured events
Framework 4.5 and higher, which is simple and customisable
- ✔️ **[`Polly`](https://github.com/App-vNext/Polly)** - Polly is a .NET resilience and transient-fault-handling library that allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner
- ✔️ **[`Scrutor`](https://github.com/khellang/Scrutor)** - Assembly scanning and decoration extensions for Microsoft.Extensions.DependencyInjection
- ✔️ **[`Opentelemetry-dotnet`](https://github.com/open-telemetry/opentelemetry-dotnet)** - The OpenTelemetry .NET Client
- ✔️ **[`EasyCaching`](https://github.com/dotnetcore/EasyCaching)** - Open source caching library that contains basic usages and some advanced usages of caching which can help us to handle caching more easier.
- ✔️ **[`Ocelot`](https://github.com/ThreeMammals/Ocelot)** - API Gateway created using .NET Core
- ✔️ **[`SEQ`](https://github.com/serilog/serilog-sinks-seq)** - Seq collects data over HTTP, while your applications use the best available structured logging APIs for your platform.
- 
## 4. Services Structure
Inner each service used clean architecture but we can use also vertical slice architecture also.

![](./assets/clean-architecture.png)

Our clean architecture in each service consists of 4 main parts:
- **Api** - This layer responsible for hosting microservice on .net core webapi and using swagger for documentation.
- **Application** - Here you should find the implementation of use cases related to the module. the application is responsible for requests processing. Application contains use cases, domain events, integration events and its contracts, internal commands.
- **Domain** - Domain Model in Domain-Driven Design terms implements the applicable Bounded Context
- **Infrastructure** - This is where the implementation of secondary adapters should be. Secondary adapters are responsible for communication with the external dependencies.
infrastructural code responsible for module initialization, background processing, data access, communication with Events Bus and other external components or systems

