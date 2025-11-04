# C#  Preparation — Core Concepts (Q&A with Examples)

This guide helps you understand and revise C# fundamentals with clear answers, examples, and additional cross-questions often asked .

---

## 🟩 1. C# Overview

**Q1. What is C# and why is it used?**  
C# (pronounced *C Sharp*) is an object-oriented, type-safe, modern programming language developed by Microsoft.  
It’s mainly used for:
- Building web, desktop, mobile, and cloud applications.  
- Game development with Unity.  
- Runs on the .NET Framework or .NET Core (now unified as .NET 5+).

**Example:**
```csharp
using System;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}
```

**Cross Question:**  
👉 Why is C# called a type-safe language?  
Because it prevents type errors by ensuring variables are used according to their declared data types at compile-time.

---

**Q2. How is C# different from Java?**

| Feature | C# | Java |
|----------|----|------|
| Platform | .NET CLR | JVM |
| Memory Mgmt | Garbage Collected | Garbage Collected |
| Delegates/Events | Supported | Not natively supported |
| Properties | Built-in | Not built-in |
| Evolving | Rapid (Microsoft updates often) | Slower |

**Cross Question:**  
👉 Can C# run on JVM?  
No, C# runs on the CLR (Common Language Runtime). But tools like IKVM used to allow Java interoperability.

---

**Q3. What platforms can C# run on?**  
- Windows (.NET Framework)  
- Cross-platform (.NET Core / .NET 5/6/7/8)  
- Mobile (Xamarin / MAUI)  
- Web (ASP.NET Core)  

---

## 🟩 2. Structure of a C# Program

**Q1. What are namespaces, classes, and methods?**
- **Namespace**: Logical grouping of classes (like a folder).  
- **Class**: Blueprint of objects (contains data and methods).  
- **Method**: Block of code that performs an action.

**Example:**
```csharp
namespace DemoApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hi!");
        }
    }
}
```

**Cross Question:**  
👉 Can a namespace contain another namespace?  
Yes, namespaces can be nested.

---

**Q2. Why do we use `Main()` method? Can a C# program have multiple Main methods?**  
`Main()` is the entry point of execution.  
Yes, multiple classes can have `Main()` but only one is defined as the startup in project settings.

**Cross Question:**  
👉 Can `Main()` return a value?  
Yes, it can return `int` to indicate status (0 = success).

---

## 🟩 3. Data Types

**Q1. What are value types and reference types?**  
- **Value Types:** Stored directly in memory (int, float, struct, bool).  
- **Reference Types:** Store memory reference (class, string, array, object).

**Cross Question:**  
👉 Where are these stored?  
Value types → Stack, Reference types → Heap.

---

**Q2. What happens when you assign one struct to another?**  
A **copy** is made (since structs are value types).

**Example:**
```csharp
struct Point { public int X, Y; }
Point p1 = new Point { X = 10, Y = 20 };
Point p2 = p1;
p2.X = 50; // Does not affect p1
```

---

**Q3. Difference between `int` and `Int32`?**  
No difference. Both represent 32-bit integers.  
`int` → keyword alias for `System.Int32`.

---

## 🟩 4. Variables & Constants

**Q1. Difference between `var`, `dynamic`, and `object`**

| Type | Compile-time | Runtime | Type Safety |
|------|---------------|----------|--------------|
| `var` | Known | Known | Strongly typed |
| `dynamic` | Unknown | Determined at runtime | Weakly typed |
| `object` | Known | Can store any type | Requires casting |

**Cross Question:**  
👉 Can `var` be null?  
No, unless used with nullable types.

---

**Q2. When should you use `var` vs explicit typing?**  
- Use `var` when type is obvious from right-hand side.  
- Use explicit typing for clarity and readability.

---

**Q3. Can constants be assigned at runtime?**  
No. `const` must be assigned at compile-time.  
Use `readonly` for runtime constants.

---

## 🟩 5. Operators

**Q1. What types of operators are available in C#?**  
Arithmetic, Logical, Comparison, Bitwise, Assignment, Conditional (`?:`), Null (`??`), and Null-conditional (`?.`).

---

**Q2. Difference between `==` and `Equals()`?**  
- `==` compares **values or references** (depending on type).  
- `Equals()` checks for **content equality** and can be overridden.

**Example:**
```csharp
string a = "Hi", b = "Hi";
Console.WriteLine(a == b);     // True
Console.WriteLine(a.Equals(b)); // True
```

**Cross Question:**  
👉 If you override `Equals()`, should you override `GetHashCode()`?  
Yes, to maintain consistency in collections.

---

**Q3. What are `??` and `?.` operators?**
- `??`: Null coalescing — provides default if null.  
- `?.`: Null conditional — avoids NullReferenceException.

---

## 🟩 6. Control Statements

**Q1. What are conditional statements in C#?**  
`if`, `else if`, `else`, `switch`, and `?:` (ternary operator).

---

**Q2. Difference between `switch` and `if-else`?**  
- `if-else`: For range or complex conditions.  
- `switch`: For checking discrete values.

**Cross Question:**  
👉 Can switch use strings or enums?  
Yes, from C# 7 onwards.

---

## 🟩 7. Loops

**Q1. What loops are supported?**  
`for`, `foreach`, `while`, `do-while`, and `goto` (rarely used).

---

**Q2. Difference between `for` and `foreach`?**  
- `for`: Manual index, can modify elements.  
- `foreach`: Read-only iteration.

---

**Q3. How to exit from multiple nested loops?**  
Use **labels** or **return**.

**Example:**
```csharp
outer:
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        if (j == 1) break outer;
    }
}
```

---

## 🟩 8. Arrays

**Q1. What is an array and how do you declare it?**
```csharp
int[] numbers = new int[3] { 1, 2, 3 };
```

---

**Q2. Difference between `Array` and `List<>`?**

| Feature | Array | List<> |
|----------|--------|--------|
| Size | Fixed | Dynamic |
| Namespace | System | System.Collections.Generic |
| Performance | Slightly faster | More flexible |

---

**Q3. Can arrays be resized?**  
No, but you can use `Array.Resize()` or convert to `List<>`.

---

## 🟩 9. Strings

**Q1. How are strings stored in memory?**  
Strings are **immutable reference types**, stored on the **heap**.

---

**Q2. What is string interning?**  
Interning stores identical strings in a shared memory pool to optimize memory.

---

**Q3. Difference between `StringBuilder` and `string`?**

| Feature | string | StringBuilder |
|----------|----------|---------------|
| Mutability | Immutable | Mutable |
| Best for | Small text | Large/frequently modified text |
| Namespace | System | System.Text |

**Cross Question:**  
👉 Is `StringBuilder` thread-safe?  
No, but `StringBuilder` can be made thread-safe using `lock`.

---

## 🟩 10. Type Casting

**Q1. Difference between implicit and explicit casting?**
- **Implicit:** Auto conversion (safe).  
- **Explicit:** Requires cast (can lose data).

**Example:**
```csharp
int i = 10;
double d = i;      // Implicit
int j = (int)d;    // Explicit
```

---

**Q2. What is boxing and unboxing?**
- **Boxing:** Value → Object  
- **Unboxing:** Object → Value

```csharp
int x = 10;
object obj = x;     // boxing
int y = (int)obj;   // unboxing
```

**Cross Question:**  
👉 Is boxing expensive?  
Yes, because it involves memory allocation on the heap.

---

**Q3. When does InvalidCastException occur?**
When casting an object to an incompatible type.

```csharp
object obj = "Hello";
int i = (int)obj; // ❌ InvalidCastException
```

---

### ✅ Next Topics (Upcoming Sections)
Would include:
- OOP Concepts (Encapsulation, Inheritance, Polymorphism, Abstraction)  
- Exception Handling  
- Collections & Generics  
- LINQ  
- Async/Await  
- File Handling  
- Delegates & Events

---
**End of Part 1 — C# Fundamentals)**  









# 🧩 C# Fundamentals 

---

### **1. What is C#?**
C# (pronounced “C-sharp”) is a modern, object-oriented, type-safe programming language developed by Microsoft.  
It runs on the .NET platform and is used to build web, desktop, mobile, and cloud applications.  

**Key points:**  
- Developed by Microsoft in 2000  
- Combines features of C++ and Java  
- Runs on Common Language Runtime (CLR)

---

### **2. What are the main features of C#?**
✅ Object-oriented  
✅ Type-safe  
✅ Component-oriented  
✅ Supports garbage collection  
✅ Interoperable with other .NET languages  
✅ Rich standard library  
✅ Support for asynchronous programming (async/await)

---

### **3. What is the difference between C# and .NET?**
| Feature | C# | .NET |
|----------|----|------|
| Definition | Programming language | Framework/platform |
| Purpose | Used to write code | Provides runtime & libraries |
| Example | `Console.WriteLine("Hello");` | Provides `Console` class and runtime (CLR) |

---

### **4. What are value types and reference types in C#?**
- **Value types:** store data directly in memory.  
  Examples: `int`, `float`, `bool`, `struct`, `enum`
- **Reference types:** store the *reference (address)* of the data.  
  Examples: `class`, `object`, `string`, `array`, `interface`

---

### **5. What is the difference between struct and class?**
| Feature | struct | class |
|----------|---------|-------|
| Type | Value type | Reference type |
| Inheritance | Not supported | Supported |
| Default constructor | Not allowed | Allowed |
| Performance | Faster (stack memory) | Slightly slower (heap memory) |
| Example | `struct Point {}` | `class Person {}` |

---

### **6. What is the difference between `ref`, `out`, and `in` parameters?**
| Keyword | Purpose | Initialization Required? | Can Modify Inside Method? |
|----------|----------|---------------------------|-----------------------------|
| `ref` | Passes variable by reference | Yes | Yes |
| `out` | Used to return multiple values | No | Yes |
| `in` | Passes by reference but read-only | Yes | No |

---

### **7. What are nullable types in C#?**
Nullable types allow value types to hold `null`.  
Example:  
```csharp
int? age = null;
if (age.HasValue) Console.WriteLine(age.Value);
```
Used when data may not exist (e.g., database fields).

---

### **8. What is boxing and unboxing?**
- **Boxing:** Converting a *value type* to an *object type*.  
- **Unboxing:** Extracting the *value type* from the *object*.  

```csharp
int num = 10;
object obj = num;      // Boxing
int val = (int)obj;    // Unboxing
```

---

### **9. What is the difference between `var`, `dynamic`, and `object`?**
| Keyword | Type decided | Compile-time check | Use case |
|----------|---------------|--------------------|-----------|
| `var` | At compile-time | ✅ Yes | When type is known |
| `dynamic` | At runtime | ❌ No | For dynamic operations |
| `object` | Base type for all | ✅ Yes | Generic storage |

---

### **10. What are access modifiers in C#?**
Access modifiers control visibility of classes, methods, and members.  
| Modifier | Access Scope |
|-----------|---------------|
| `public` | Accessible everywhere |
| `private` | Within the same class |
| `protected` | Within class and derived class |
| `internal` | Within the same assembly |
| `protected internal` | Derived or same assembly |
| `private protected` | Derived and same assembly only |

---

### **11. What is the difference between `const`, `readonly`, and `static`?**
| Keyword | Value change | When assigned | Use case |
|----------|---------------|---------------|-----------|
| `const` | Cannot change | Compile-time | Fixed values like PI |
| `readonly` | Cannot change after constructor | Runtime | Configurable constants |
| `static` | Shared across all objects | Any time | Shared members |

---

### **12. What is the difference between `==` and `.Equals()`?**
- `==` compares *reference* for objects (unless overridden).  
- `.Equals()` compares *values* by default.  

```csharp
string s1 = "abc";
string s2 = new string("abc");
Console.WriteLine(s1 == s2);       // True
Console.WriteLine(s1.Equals(s2));  // True
```

---

### **13. What is a namespace?**
A **namespace** organizes classes and avoids naming conflicts.  
```csharp
namespace MyApp.Models
{
    class Employee {}
}
```
You can use it via `using MyApp.Models;`

---

### **14. What are assemblies and namespaces in C#?**
- **Assembly:** The compiled output (.dll or .exe) containing IL code.  
- **Namespace:** Logical grouping of classes and types.  

Multiple namespaces can exist inside a single assembly.

---

### **15. What are properties in C#?**
Properties are *class members* that provide controlled access to private fields.  
```csharp
class Employee
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
```
Supports encapsulation.

---

### **16. What are indexers in C#?**
Indexers allow objects to be accessed like arrays.  
```csharp
class Sample
{
    private string[] data = new string[3];
    public string this[int i]
    {
        get => data[i];
        set => data[i] = value;
    }
}
```
Usage: `obj[0] = "Hello";`

---

### **17. What are partial classes?**
They allow a class to be split into multiple files.  
Useful in auto-generated code (e.g., designer files).

```csharp
partial class Employee {}
partial class Employee {}
```

---

### **18. What is an anonymous type?**
An anonymous type allows you to create an object without defining a class.  
```csharp
var person = new { Name = "John", Age = 25 };
Console.WriteLine(person.Name);
```

---

### **19. What is type inference?**
Type inference lets the compiler automatically determine the variable’s type using `var`.  
```csharp
var name = "Anki"; // compiler infers string
```

---

### **20. What is the `using` statement used for?**
Used to:
1. Import namespaces.  
   `using System;`
2. Automatically dispose resources (like files, DB connections).  
   ```csharp
   using(var file = new StreamWriter("test.txt"))
   {
       file.WriteLine("Hello");
   }
   ```
   After block ends → `Dispose()` called automatically.

---

✅ **End of Chapter 1 — C# Fundamentals**
