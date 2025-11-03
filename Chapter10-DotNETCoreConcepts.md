# 📘 Chapter 10: .NET Core Concepts

---

## 🟩 1. Basics

### 1. What is .NET Core?
**Answer:**  
.NET Core is an open-source, cross-platform, modular framework for building modern, cloud-based, internet-connected applications. It supports Windows, Linux, and macOS and can be used to build web, desktop, mobile, IoT, and microservices-based applications.

---

### 2. What are the advantages of .NET Core over .NET Framework?
**Answer:**
- Cross-platform support (Windows, Linux, macOS)
- High performance and lightweight
- Modular via NuGet packages
- Side-by-side versioning
- Unified development model (.NET 5+)
- Open-source and community-driven

---

### 3. What is the difference between SDK, Runtime, and CLR?
| Component | Description |
|------------|--------------|
| **SDK (Software Development Kit)** | Includes compiler, tools, templates, and runtime. Used for building applications. |
| **Runtime** | Required to run .NET applications (without development tools). |
| **CLR (Common Language Runtime)** | Manages execution of .NET programs (memory, exceptions, GC, etc.). |

---

### 4. What are the key features of .NET Core?
- Cross-platform development  
- Unified base class libraries  
- Dependency Injection built-in  
- High performance and scalability  
- Command-line interface (CLI) support  
- Flexible deployment options  

---

### 5. What are major components of .NET Core?
- **CoreCLR** – Execution engine  
- **CoreFX** – Base class libraries  
- **Roslyn** – Compiler  
- **ASP.NET Core** – Web framework  
- **Entity Framework Core** – ORM for database access  

---

## 🟦 2. Architecture & Runtime

### 6. Explain the .NET Core architecture.
**Answer:**
The architecture has 3 layers:
1. **.NET Runtime (CoreCLR)** – Executes code, handles GC, JIT, threading.  
2. **Base Class Library (CoreFX)** – Provides APIs for file I/O, collections, networking, etc.  
3. **Application Layer** – Your application code and dependencies.

---

### 7. What is CLR / CoreCLR?
**Answer:**  
CoreCLR is the runtime used in .NET Core to execute managed code. It provides memory management, JIT compilation, and garbage collection.

---

### 8. What is CTS, CLS, and CLR in .NET Core?
- **CTS (Common Type System):** Defines how types are declared and used.  
- **CLS (Common Language Specification):** Ensures cross-language compatibility.  
- **CLR (Common Language Runtime):** Executes code and manages resources.

---

### 9. What is CoreFX?
**Answer:**  
CoreFX is the set of foundational libraries that form the .NET Core Base Class Library (BCL). It contains collections, I/O, XML, networking, etc.

---

### 10. What is the role of the JIT compiler in .NET Core?
The **Just-In-Time (JIT)** compiler converts Intermediate Language (IL) code to native machine code at runtime.

---

## 🟨 3. Cross-Platform & SDK

### 11. How is .NET Core cross-platform?
It uses platform-agnostic IL code and a runtime that has specific builds for each OS. This allows code to run on any supported platform.

---

### 12. What is .NET CLI?
Command-line interface used for creating, building, running, and publishing .NET applications.

Example:
```bash
dotnet new console
dotnet build
dotnet run
```

---

### 13. Difference between SDK and Runtime in .NET Core
- **SDK** = tools + compiler + runtime (for development)  
- **Runtime** = only execution engine (for deployment)

---

### 14. What is `dotnet restore`, `build`, `run`, `publish`?
| Command | Description |
|----------|-------------|
| `restore` | Downloads dependencies |
| `build` | Compiles project |
| `run` | Builds and executes project |
| `publish` | Prepares app for deployment |

---

### 15. What is RID (Runtime Identifier)?
A unique ID that identifies OS + architecture (e.g., `win10-x64`, `linux-arm`). Used in self-contained deployments.

---

## 🟧 4. Application Model

### 16. What types of applications can be built with .NET Core?
- Console apps  
- Web apps (ASP.NET Core)  
- Web APIs  
- Microservices  
- Cloud apps  
- IoT apps  

---

### 17. What is ASP.NET Core?
It’s a cross-platform framework for building web applications and APIs. It uses middleware, dependency injection, and hosting models.

---

### 18. What are middlewares in ASP.NET Core?
Middleware components process HTTP requests and responses in a pipeline.

Example:
```csharp
app.Use(async (context, next) =>
{
    Console.WriteLine("Before request");
    await next();
    Console.WriteLine("After request");
});
```

---

### 19. Explain the Startup.cs class.
Contains configuration methods:
- `ConfigureServices()` → registers dependencies.  
- `Configure()` → defines the request pipeline.

---

### 20. What is Program.cs file?
It’s the entry point of a .NET Core application. It configures and runs the host builder.

---

## 🟥 5. Dependency Injection & Services

### 21. What is dependency injection in .NET Core?
A design pattern to manage object creation and lifetime through a built-in IoC container.

Example:
```csharp
services.AddScoped<IUserService, UserService>();
```

---

### 22. What are lifetimes of services?
| Lifetime | Description |
|-----------|--------------|
| **Transient** | Created every time it’s requested |
| **Scoped** | One per request |
| **Singleton** | Single instance for app lifetime |

---

### 23. How to register and resolve services?
```csharp
services.AddSingleton<IService, ServiceImpl>();
var service = provider.GetService<IService>();
```

---

### 24. What is IServiceCollection and IServiceProvider?
- **IServiceCollection** – used to register services.  
- **IServiceProvider** – used to resolve services.

---

### 25. What are Hosted Services and Background Services?
Used for background tasks. Implement `IHostedService` or inherit `BackgroundService`.

---

## 🟪 6. Configuration & Environment

### 26. How does configuration work in .NET Core?
It loads settings from multiple providers: `appsettings.json`, environment variables, command line, etc.

---

### 27. What are configuration providers?
- JSON files (`appsettings.json`)  
- Environment variables  
- Command-line arguments  
- In-memory collection

---

### 28. How to use appsettings.json?
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=AppDb;Trusted_Connection=True;"
  }
}
```

```csharp
var conn = Configuration["ConnectionStrings:DefaultConnection"];
```

---

### 29. What is IConfiguration and IOptions?
- **IConfiguration**: Access configuration values directly.  
- **IOptions<T>**: Bind configuration sections to strongly-typed objects.

---

### 30. What are environment variables in .NET Core?
Used to define runtime environment (Development, Staging, Production).

```csharp
if (env.IsDevelopment())
    app.UseDeveloperExceptionPage();
```

---

## 🟫 7. Middleware & Pipeline

### 31. Explain the request pipeline in .NET Core.
Every request passes through middleware components sequentially before reaching the endpoint.

---

### 32. Difference between Use, Run, and Map methods.
| Method | Description |
|---------|-------------|
| `Use()` | Adds middleware that can call the next one |
| `Run()` | Terminates the pipeline |
| `Map()` | Branches the pipeline based on request path |

---

### 33. What is Kestrel?
Kestrel is a cross-platform, high-performance web server included with ASP.NET Core. It can run behind IIS, Nginx, or standalone.

---

### 34. What is IWebHostBuilder?
Used in ASP.NET Core 2.x for building and configuring the web host (server, middleware, DI).

---

### 35. What is the Hosting Environment?
It determines app behavior depending on the environment (Development, Staging, Production).

---

## ⚪ 8. Deployment & Performance

### 36. What are types of deployment in .NET Core?
- **Framework-dependent** – requires .NET runtime installed.  
- **Self-contained** – includes .NET runtime in deployment.

---

### 37. What is self-contained vs framework-dependent deployment?
| Type | Includes Runtime? | Size | Portability |
|-------|------------------|------|--------------|
| Self-contained | Yes | Large | High |
| Framework-dependent | No | Small | Requires runtime |

---

### 38. How to publish a .NET Core app?
```bash
dotnet publish -c Release -o ./publish
```

---

### 39. What is the Garbage Collector (GC) in .NET Core?
Manages memory automatically by releasing unused objects.

---

### 40. What is Server GC vs Workstation GC?
| GC Type | Description |
|----------|-------------|
| **Server GC** | Optimized for scalability and throughput |
| **Workstation GC** | Optimized for low-latency desktop apps |

---

## ⚫ 9. Advanced & Runtime

### 41. What is AOT compilation?
Ahead-of-Time compilation precompiles IL into native code before execution, reducing startup time.

---

### 42. What is ReadyToRun (R2R)?
Precompiled format that speeds up app startup by reducing JIT work.

---

### 43. Difference between .NET 5, 6, 7, 8 and .NET Core 3.1?
- .NET 5+ unifies .NET Core and .NET Framework.  
- .NET 6 and 8 are LTS (Long-Term Support) versions.  
- Improved performance and AOT support.

---

### 44. How does .NET Core handle side-by-side execution?
Multiple versions of .NET Core can coexist on the same machine. Each app uses its targeted runtime.

---

### 45. What is NativeAOT in .NET 8?
Compiles apps to native binaries for faster startup and reduced memory footprint.

---

## 🟨 10. Security & Diagnostics

### 46. What is Data Protection API?
Provides cryptographic APIs for secure data storage and authentication tokens.

---

### 47. What is User Secrets in .NET Core?
Stores sensitive data (like connection strings) securely during development.

---

### 48. What are Logging Providers?
Components that log messages to various targets (Console, Debug, File, Application Insights).

---

### 49. What is Health Checks middleware?
Used to monitor application health (useful in microservices and cloud).

---

### 50. How to handle global exceptions?
Use middleware or `UseExceptionHandler()` to capture and log unhandled exceptions.

---

## 🟦 11. ASP.NET Core MVC Add-ons

### 51. What are Filters in ASP.NET Core MVC?
Filters allow code to run before or after certain MVC stages (e.g., Action, Result).

---

### 52. Types of Filters in MVC
- Authorization Filters  
- Action Filters  
- Result Filters  
- Exception Filters  

---

### 53. How to create a custom filter?
```csharp
public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Action starting");
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Action finished");
    }
}
```

---

### 54. What are Tag Helpers?
Tag Helpers enable server-side C# code to participate in creating and rendering HTML elements in Razor views.

Example:
```html
<form asp-action="Login"></form>
```

---

### 55. What are View Components?
Reusable rendering logic, similar to partial views but with controller-like behavior.

---

✅ **End of Chapter 10: .NET Core Concepts**
