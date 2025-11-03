# Chapter 10: .NET Core Concepts (Easy Version)

This chapter covers **Top 25 .NET Core Interview Questions and Answers** in simple and easy language.

---

### 1. What is .NET Core?
.NET Core is an open-source, cross-platform framework from Microsoft.  
It helps build apps that can run on **Windows, Linux, and macOS**.

**Example:**  
- ASP.NET Core → Web apps  
- .NET CLI → Command-line tools

---

### 2. Difference between .NET Core and .NET Framework
| Feature | .NET Framework | .NET Core |
|----------|----------------|------------|
| Platform | Windows only | Cross-platform |
| Open Source | ❌ No | ✅ Yes |
| Performance | Slower | Faster |
| Hosting | IIS only | Kestrel, IIS, Nginx, Apache |

---

### 3. What are the advantages of .NET Core?
- Cross-platform support  
- High performance and scalability  
- Unified framework for web, desktop, and mobile  
- Easy deployment and lightweight runtime  
- Open source and community-driven

---

### 4. What is CLR in .NET Core?
**CLR (Common Language Runtime)** runs .NET programs.  
It handles **memory, garbage collection, and type safety**.

---

### 5. What is the difference between SDK and Runtime?
- **SDK:** Contains tools and compilers for development.  
- **Runtime:** Needed only to run the app.  

Example:  
Developers install SDK; users only need Runtime.

---

### 6. What is Kestrel Server?
Kestrel is the **default web server** for ASP.NET Core apps.  
It’s lightweight, fast, and cross-platform.  
It can run standalone or behind IIS, Apache, or Nginx.

---

### 7. What are Middlewares in ASP.NET Core?
Middleware is code that processes HTTP requests and responses in a pipeline.  

**Example:**
```csharp
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(...);
```

Each middleware runs in order — like a chain.

---

### 8. What is Dependency Injection (DI)?
DI is a way to **provide objects that a class needs**, instead of creating them inside the class.

**Example:**
```csharp
services.AddScoped<IUserService, UserService>();
```

✅ Makes code flexible, testable, and easy to maintain.

---

### 9. What are configuration files in .NET Core?
- `appsettings.json` → Main config file (like database, keys).  
- You can use `IConfiguration` to read values.  

**Example:**
```csharp
var connection = Configuration["ConnectionStrings:Default"];
```

---

### 10. What are Environments in .NET Core?
Environments help you run different settings for **Development**, **Staging**, and **Production**.

Example:  
`ASPNETCORE_ENVIRONMENT=Development`

---

### 11. What is the difference between IHost and IWebHost?
- **IWebHost** → Used for web apps (ASP.NET Core 2.x).  
- **IHost** → Used for any app (generic host, from .NET Core 3+).  

Now, most apps use **IHost**.

---

### 12. What are Filters in ASP.NET Core MVC?
Filters allow you to run code **before or after** controller actions.  
Types: Authorization, Action, Result, and Exception filters.

**Example:**
```csharp
[Authorize]
public IActionResult Dashboard() { ... }
```

---

### 13. What are Tag Helpers?
Tag Helpers let you use **C# in HTML**.

**Example:**
```html
<a asp-controller="Home" asp-action="Index">Home</a>
```
Easier than writing Razor code manually.

---

### 14. What are View Components?
Reusable mini-controllers that return a view.

**Example:**
```csharp
public class MenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View("Menu");
}
```

---

### 15. What is the Startup class?
Defines how your app behaves when it starts.  

**Contains:**  
- `ConfigureServices()` → Add services.  
- `Configure()` → Set up middleware.

---

### 16. What is Program.cs in .NET 6/7/8?
In minimal hosting, `Program.cs` does everything — builds, configures, and runs the app.  

**Example:**
```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();
```

---

### 17. What is the difference between AddScoped, AddSingleton, AddTransient?
| Lifetime | Description |
|-----------|--------------|
| **Singleton** | One instance for whole app |
| **Scoped** | One per request |
| **Transient** | New each time it’s used |

---

### 18. What is the command-line tool for .NET Core?
`dotnet` CLI is used for managing .NET Core projects.

**Examples:**
```
dotnet new mvc
dotnet build
dotnet run
dotnet publish
```

---

### 19. What are NuGet Packages?
NuGet is a package manager for .NET.  
Used to add external libraries like Entity Framework, Serilog, etc.

---

### 20. What are Assemblies and DLLs?
An assembly is a **compiled output** (.dll or .exe) that contains your code.  
They can be reused across projects.

---

### 21. What is Cross-Platform Development?
.NET Core allows you to run the same app on Windows, macOS, and Linux without changing code.

---

### 22. What are Logging Providers?
Used to capture logs in files, console, or cloud.

**Example:**
```csharp
builder.Logging.AddConsole();
```

---

### 23. What is Configuration Provider?
It reads configuration from files, environment, or secrets.

**Example:**  
`appsettings.json`, environment variables, command-line args.

---

### 24. What is Middleware Order Important?
Yes! Middleware runs in order — wrong order can break your app.  
Always put `UseRouting()` before `UseEndpoints()`.

---

### 25. What are Minimal APIs?
Introduced in .NET 6 — allows you to build APIs with less code.

**Example:**
```csharp
var app = WebApplication.CreateBuilder(args).Build();
app.MapGet("/hello", () => "Hello, Ankita!");
app.Run();
```

---

✅ **Summary:**  
- .NET Core = fast, open, and cross-platform.  
- Uses Kestrel, DI, and Middleware pipeline.  
- Config is flexible with `appsettings.json` and environments.  
- Easy deployment + high performance.

---
