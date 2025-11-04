# 🧠 .NET Q&A Guide

---

## 💻 C# Concepts

### 🔹 Q1: What is the difference between `ref` and `out`?

**Answer:**
Both `ref` and `out` are used to pass arguments **by reference**, but:

- **ref:** The variable **must be initialized** before passing.
- **out:** The variable **can be uninitialized**, but **must be assigned inside the method** before returning.

**Example:**
```csharp
void Add(ref int x) { x = x + 10; }
void Multiply(out int y) { y = 5; }

int a = 2;
Add(ref a); // a becomes 12

int b;
Multiply(out b); // b = 5
```

---

### 🔹 Q2: Explain boxing and unboxing.

**Answer:**
- **Boxing:** Converting a **value type** (like `int`) into an **object (reference type)**.
- **Unboxing:** Converting that **object back to a value type**.

**Example:**
```csharp
int num = 10;          // Value type
object obj = num;      // Boxing
int newNum = (int)obj; // Unboxing
```

---

### 🔹 Q3: What are delegates and events?

**Answer:**
- A **delegate** is like a **function pointer** — it holds a reference to a method.
- An **event** is built on delegates and used to **notify other parts of the program** when something happens.

**Example:**
```csharp
public delegate void Notify();  // Declare delegate
public event Notify ProcessCompleted;  // Declare event
```

---

## ⚙️ OOP Concepts

### 🔹 Q4: Explain encapsulation, inheritance, and polymorphism with examples.

**Encapsulation:**
Wrapping data (variables) and methods inside a class.
```csharp
class Student {
  private int age;
  public void SetAge(int a) { age = a; }
  public int GetAge() { return age; }
}
```

**Inheritance:**
A class can use members of another class.
```csharp
class Animal { public void Eat() {} }
class Dog : Animal { public void Bark() {} }
```

**Polymorphism:**
Same method behaves differently in different classes.
```csharp
class Shape { public virtual void Draw() => Console.WriteLine("Drawing shape"); }
class Circle : Shape { public override void Draw() => Console.WriteLine("Drawing circle"); }
```

---

### 🔹 Q5: What is abstraction and why is it important?

**Answer:**
Abstraction means **showing only essential features** and hiding complex details.  
It makes the code **simpler and easier to maintain**.

**Example:**
```csharp
abstract class Shape {
  public abstract void Draw(); // Only definition
}

class Circle : Shape {
  public override void Draw() { Console.WriteLine("Drawing Circle"); }
}
```

---

## 🌐 ASP.NET / MVC

### 🔹 Q6: What is the difference between ViewBag, ViewData, and TempData?

| Type | Data Type | Lifetime | Usage Example |
|------|------------|-----------|----------------|
| **ViewData** | Dictionary | Current request | `ViewData["Name"] = "Ankita";` |
| **ViewBag** | Dynamic property | Current request | `ViewBag.Name = "Ankita";` |
| **TempData** | Dictionary | Next request (redirect) | `TempData["Name"] = "Ankita";` |

---

### 🔹 Q7: Explain routing in MVC.

**Answer:**
Routing maps **URL requests to Controller actions**.

Example:  
`/Home/Index` → calls `HomeController.Index()`

**Defined in `RouteConfig.cs`:**
```csharp
routes.MapRoute(
  name: "Default",
  url: "{controller}/{action}/{id}",
  defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
);
```

---

### 🔹 Q8: How to handle exceptions in Web API?

**Answer:**
You can handle exceptions using:
1. **Try-Catch blocks**
2. **Exception filters** (`IExceptionFilter`)
3. **Global exception handling** in `Startup.cs`

**Example:**
```csharp
try {
   // code
} catch(Exception ex) {
   return BadRequest(ex.Message);
}
```

---

## 🗄️ SQL

### 🔹 Q9: How to find the 2nd highest salary without using TOP or LIMIT?

**Answer:**
```sql
SELECT MAX(Salary)
FROM Employees
WHERE Salary < (SELECT MAX(Salary) FROM Employees);
```

---

### 🔹 Q10: Difference between primary key, unique key, and foreign key.

| Key Type | Description | Allows NULL |
|-----------|--------------|--------------|
| **Primary Key** | Uniquely identifies each record | ❌ No |
| **Unique Key** | Ensures unique values in a column | ✅ Yes (one NULL allowed) |
| **Foreign Key** | Links two tables | ✅ Yes |

---

## 🔐 Bonus Topics

### 🔹 Q11: What is authentication vs authorization?

**Answer:**
- **Authentication:** Verifies **who the user is** (login).  
- **Authorization:** Determines **what the user can access** (permissions).

---

### 🔹 Q12: What is Dependency Injection (DI) and why do we use it?

**Answer:**
DI is a pattern that **injects dependencies (objects)** instead of creating them inside the class.

**Benefits:**
- Loose coupling  
- Easier testing  
- Better maintainability  

**Example:**
```csharp
public class StudentService {
   private readonly IStudentRepository _repo;
   public StudentService(IStudentRepository repo) {
       _repo = repo;
   }
}
```

---


This file contains easy-to-understand Q&A for .NET developer — focused on real-time usage, architecture, and clear explanation.

---

## 2. OOPS with Real-Time Examples

| Concept | Explanation | Example |
|----------|--------------|----------|
| **Encapsulation** | Binding data using classes | `Account` class hides balance |
| **Inheritance** | Reuse code from parent class | `Employee : Person` |
| **Polymorphism** | Same method behaves differently | `CalculateSalary()` |
| **Abstraction** | Hiding implementation details | `IShape` with `Draw()` method |

💬 *Project use:* Used abstraction for repositories and services.

---

## 3. Dependency Injection in C#

**Q:** What is DI and why is it used?  
**A:** DI injects dependencies from outside instead of creating inside the class, reducing tight coupling.

**Example:**
```csharp
public class OrderService
{
    private readonly IEmailService _email;
    public OrderService(IEmailService email) => _email = email;
}
```
**Startup:**
```csharp
services.AddScoped<IEmailService, EmailService>();
```
💬 Used DI for services like logging, email, and data access.

---

## 4. Method Overloading vs Method Overriding

| Feature | Overloading | Overriding |
|----------|--------------|------------|
| Purpose | Same name, diff parameters | Redefine in derived class |
| Type | Compile-time | Runtime |
| Keyword | None | `override` |
| Example | `Add(int, int)` / `Add(double, double)` | Override `ToString()` |

---

## 5. Abstraction vs Interface

| Aspect | Abstract Class | Interface |
|---------|----------------|-----------|
| Members | Can have fields, methods | Only methods/properties |
| Usage | When classes share base | When you need contracts |
| Example | `abstract class Vehicle` | `interface IDrive` |

---

## 6. Middleware in ASP.NET Core & Configuration

**Middleware:** Software that handles requests/responses in a pipeline.  
Example:
```csharp
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(...);
```
**Configuration:** Comes from `appsettings.json` or environment.

```json
"ConnectionStrings": { "Default": "Server=.;Database=MyDb;" }
```

💬 Added custom middleware for logging and global exception handling.

---

## 7. REST API Verbs (GET, POST, PUT, DELETE)

| Verb | Purpose | Example |
|------|----------|----------|
| GET | Read | `/api/users` |
| POST | Create | `/api/users` |
| PUT | Update | `/api/users/1` |
| DELETE | Remove | `/api/users/1` |

---

## 8. Difference Between PUT and POST

| Feature | POST | PUT |
|----------|------|------|
| Action | Create | Update |
| Idempotent | No | Yes |
| Example | Add new record | Update existing |

---

## 9. Liskov Substitution Principle (SOLID)

Derived classes should replace base classes without breaking behavior.  
Example: `Bird` and `Sparrow` okay, but `Bird` and `Penguin` not (as penguin can’t fly).

---

## 10. Common Design Patterns

| Pattern | Purpose | Example |
|----------|----------|----------|
| Singleton | One instance only | `LoggerService` |
| Factory | Creates object dynamically | `ShapeFactory` |
| Repository | Handles DB operations | `UserRepository` |

---

## 11. Service Lifetimes – Transient, Scoped, Singleton

| Type | Lifetime | Example |
|------|-----------|----------|
| Transient | New each time | Utility services |
| Scoped | Per request | Repository |
| Singleton | One per app | Logger |

---

## 12. Stored Procedures & Functions

| Type | Purpose | Returns |
|------|----------|----------|
| Procedure | Perform tasks | 0+ results |
| Function | Return value | Scalar/Table |

---

## 13. SQL Query to Delete a Row

```sql
DELETE FROM Employee WHERE Id = 5;
```

---

## 14. SQL Query to Remove Duplicates

```sql
DELETE FROM Employee
WHERE Id NOT IN (SELECT MIN(Id) FROM Employee GROUP BY Email);
```

---

## 15. Azure App Services & Functions

| Service | Use |
|----------|------|
| App Service | Host web apps |
| Function App | Serverless tasks |
| Key Vault | Secure secrets |
| Blob Storage | File storage |

💬 Deployed APIs on Azure App Service and used Function App for background jobs.

---

## 16. Angular Core Concepts

| Concept | Description |
|----------|-------------|
| Component | UI block |
| Service | Shared logic |
| Module | App structure |
| Binding | Connect data to UI |
| Directive | Adds DOM behavior |

---

## 17. jQuery Fundamentals

| Concept | Example |
|----------|----------|
| DOM | `$('#id').hide();` |
| Event | `$('#btn').click(...);` |
| AJAX | `$.get('/api/data');` |

---

## 18. Middleware Deep Dive

Middleware executes sequentially and can modify requests/responses.

💬 Added custom error middleware in project for cleaner exception handling.

---

## 19. SOLID Principles Simplified

| Principle | Meaning | Example |
|------------|----------|----------|
| SRP | One job per class | `EmailService` only sends mail |
| OCP | Extend without change | New payment type |
| LSP | Replace base safely | `CreditCardPayment` inherits `Payment` |
| ISP | Split large interfaces | `IReadRepo`, `IWriteRepo` |
| DIP | Depend on abstractions | Inject `ILogger` |

---

## 20. Azure Services Overview

| Service | Use |
|----------|-----|
| App Service | Host APIs |
| Azure SQL | Cloud DB |
| Function App | Background jobs |
| Key Vault | Store secrets |
| Blob Storage | Files |

---

## 21. Architectural Flow

```
Client (Angular)
↓
Controller (API)
↓
Service (Business Logic)
↓
Repository (DB Access)
↓
SQL / Azure SQL
```

💬 Used layered architecture for cleaner and testable apps.

---

## 22. Dependency Injection in Middleware

Middleware can use injected services.

Example:
```csharp
public class LogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogMiddleware> _logger;
    public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
    {
        _next = next; _logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        _logger.LogInformation($"Request: {context.Request.Path}");
        await _next(context);
    }
}
```

---

## 23. Azure Deployment & Scaling

1. Push code to Azure DevOps  
2. Build with CI/CD pipeline  
3. Deploy to App Service  
4. Use staging slots  
5. Enable auto-scale

---

## 24. Project-Level Architecture Summary

| Layer | Role | Example |
|--------|------|----------|
| API | Routing | Controllers |
| Service | Business logic | `OrderService` |
| Repository | Data access | `CustomerRepo` |
| DTOs | Models | `UserDto` |
| Infrastructure | Logging/Azure | `LoggerService` |

---

## 25. Tip 💡

✅ Define → ✅ Give example → ✅ Link with project  

Example:  
> “I used Dependency Injection in my project to inject services like Email and Logging, which made the app modular and testable.”

---
