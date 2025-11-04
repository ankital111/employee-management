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
