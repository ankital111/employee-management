# Chapter 4: Expert C# and .NET Core Backend Development

---

## 🧠 Section 1: Advanced C# Concepts

### 1. What are Delegates?
**Concise:** Delegates are type-safe function pointers in C# used to reference methods dynamically.  
**Detailed:** A delegate defines a method signature and can hold references to one or more methods that match that signature. They enable event handling, callbacks, and functional-style programming.

```csharp
public delegate void Notify(string message);

public class Process {
    public Notify OnComplete;
    public void Start() {
        // Do work
        OnComplete?.Invoke("Process completed!");
    }
}
```

---

### 2. What are Events in C#?
**Concise:** Events are a way for a class to notify other classes when something happens.  
**Detailed:** Events are built on delegates and provide publish-subscribe communication between objects.

```csharp
public class FileDownloader {
    public event EventHandler DownloadCompleted;
    public void StartDownload() {
        // Downloading...
        DownloadCompleted?.Invoke(this, EventArgs.Empty);
    }
}
```

---

### 3. Explain `Func`, `Action`, and `Predicate` delegates.
| Type | Returns | Example |
|------|----------|----------|
| Action | void | `Action<int> print = x => Console.WriteLine(x);` |
| Func | Value | `Func<int, int> square = x => x * x;` |
| Predicate | bool | `Predicate<int> isEven = x => x % 2 == 0;` |

---

### 4. Async and Await in C#
**Concise:** Async allows non-blocking code execution using tasks.  
**Detailed:** The `async` keyword marks a method for asynchronous execution, and `await` pauses execution until a task completes.

```csharp
public async Task<string> GetDataAsync() {
    using HttpClient client = new();
    var response = await client.GetStringAsync("https://api.github.com");
    return response;
}
```

---

### 5. Reflection and Attributes
**Concise:** Reflection allows runtime inspection of assemblies and types.  
**Detailed:** Reflection is used for dynamic type loading, plugin systems, and dependency injection.

```csharp
Type t = typeof(MyClass);
foreach (var prop in t.GetProperties()) {
    Console.WriteLine(prop.Name);
}
```

Attributes are metadata annotations used by reflection.

```csharp
[Obsolete("Use NewMethod instead")]
public void OldMethod() {}
```

---

### 6. LINQ Deep Dive
**Concise:** LINQ provides a unified syntax to query objects, collections, or databases.  
**Detailed:** LINQ (Language Integrated Query) allows expressive data manipulation in memory and database.

```csharp
var highScores = from s in scores
                 where s > 90
                 orderby s descending
                 select s;
```

---

## ⚙️ Section 2: .NET Core and .NET 8 Backend Internals

### 1. Explain the .NET Core Request Pipeline.
The middleware pipeline handles HTTP requests sequentially:
```
Client → Kestrel → Middleware → Controller → Response
```
Example:
```csharp
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
```

### 2. What is Dependency Injection (DI)?
**Concise:** DI is a design pattern that provides required dependencies from outside a class.  
**Detailed:** In .NET Core, DI is built-in via the `IServiceCollection` container.

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

### 3. Middleware in .NET
**Concise:** Middleware are components executed in sequence to handle requests/responses.  
**Example:**
```csharp
public class LoggingMiddleware {
    private readonly RequestDelegate _next;
    public LoggingMiddleware(RequestDelegate next) => _next = next;
    public async Task InvokeAsync(HttpContext context) {
        Console.WriteLine($"Request: {context.Request.Path}");
        await _next(context);
    }
}
```

---

### 4. EF Core Optimization Techniques
- Use `AsNoTracking()` for read-only queries.  
- Batch updates with `SaveChangesAsync()`.  
- Use projections instead of fetching full entities.  
- Avoid N+1 queries with `Include()` and `ThenInclude()`.

---

## 🧩 Section 3: Real-World Backend API Structure

```
/MyApi
 ├── Program.cs
 ├── Controllers/
 │    └── UsersController.cs
 ├── Services/
 │    └── UserService.cs
 ├── Repositories/
 │    └── UserRepository.cs
 ├── Models/
 │    └── User.cs
 ├── Middleware/
 │    └── ExceptionMiddleware.cs
 └── appsettings.json
```

### 🔍 Explanation
| Folder | Purpose |
|---------|----------|
| Controllers | Handle HTTP requests |
| Services | Business logic |
| Repositories | Database communication (EF Core) |
| Middleware | Cross-cutting concerns like logging, error handling |
| Models | DTOs and Entity classes |
| Program.cs | Configure pipeline and services |

---

## 🎯 Section 4: Expert Interview Questions and Answers

| # | Question | Short Answer | Detailed Explanation |
|---|-----------|---------------|----------------------|
| 1 | What is the difference between `Task` and `Thread`? | Task is higher-level, managed by ThreadPool. | Task uses async model, auto manages threads efficiently, unlike manual Thread creation. |
| 2 | What are records in C#? | Immutable reference types. | Introduced in C# 9, used for data models with value-based equality. |
| 3 | What is `IQueryable` vs `IEnumerable`? | IQueryable supports DB queries. | `IQueryable` executes at database, `IEnumerable` in memory. |
| 4 | How does GC (Garbage Collector) work? | Manages memory automatically. | Frees unused objects from heap, runs in generations (0,1,2). |
| 5 | What is the use of `ConfigureServices` and `Configure` methods? | For DI and middleware setup. | `ConfigureServices` adds dependencies; `Configure` sets up middleware pipeline. |

---

## 🧾 Section 5: Quick Revision Notes

| Concept | Summary |
|----------|----------|
| Delegate | Type-safe method pointer |
| Event | Pub-sub mechanism using delegates |
| Async/Await | Non-blocking task-based programming |
| Middleware | Request/Response processing pipeline |
| DI | Inject services automatically |
| EF Core | ORM for database operations |
| Logging | Use `ILogger` or `Serilog` |
| Exception Handling | Centralized via middleware |

---

✅ **Next Steps:**
- Revise advanced concepts daily with practical examples.  
- Build a small REST API using .NET 8 applying all learned patterns.  
- Focus on explaining “Why” behind each concept in interviews.

