
# 🧩 C# Fundamentals — Interview Questions & Answers

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
