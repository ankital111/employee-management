# Chapter 3: Advanced C# Concepts

This chapter covers advanced C# topics focusing on performance, memory management, and modern C# features.

---

## 🔹 1. What is a Delegate in C#?

**Answer:**
A delegate is a type that references a method. It is used to pass methods as arguments and enables callback mechanisms.

**Example:**

```csharp
public delegate void GreetDelegate(string name);

class Program {
    static void Greet(string name) => Console.WriteLine($"Hello {name}");

    static void Main() {
        GreetDelegate gd = Greet;
        gd("John");
    }
}
```

**Summary:** Delegate = Type-safe function pointer.

---

## 🔹 2. What is an Event in C#?

**Answer:**
Events are built on delegates and are used for communication between objects (publisher/subscriber model).

**Example:**

```csharp
class Alarm {
    public event Action OnRing;
    public void Ring() => OnRing?.Invoke();
}
```

**Summary:** Events notify subscribers when something happens.

---

## 🔹 3. What is a Lambda Expression?

**Answer:**
Lambda expressions are shorthand for anonymous methods using the `=>` syntax.

**Example:**

```csharp
Func<int, int> square = x => x * x;
Console.WriteLine(square(5));
```

**Summary:** Lambda = Inline, concise function syntax.

---

## 🔹 4. What is LINQ in C#?

**Answer:**
Language Integrated Query (LINQ) provides a query syntax to retrieve and manipulate data from different sources.

**Example:**

```csharp
int[] nums = { 1, 2, 3, 4, 5 };
var even = from n in nums where n % 2 == 0 select n;
```

**Summary:** LINQ simplifies data querying directly within C#.

---

## 🔹 5. What are Generics?

**Answer:**
Generics allow defining classes, methods, and interfaces with placeholders for data types.

**Example:**

```csharp
class GenericBox<T> {
    public T Value;
}
```

**Summary:** Generics promote code reusability and type safety.

---

## 🔹 6. What is Reflection in C#?

**Answer:**
Reflection allows inspection of metadata about assemblies, types, and members at runtime.

**Example:**

```csharp
Type t = typeof(string);
Console.WriteLine(t.FullName);
```

**Summary:** Reflection = Runtime type inspection.

---

## 🔹 7. What is an Attribute?

**Answer:**
Attributes add metadata to program elements like classes or methods.

**Example:**

```csharp
[Obsolete("Use NewMethod instead")]
void OldMethod() { }
```

**Summary:** Attributes provide additional metadata for reflection and validation.

---

## 🔹 8. What is Boxing and Unboxing?

**Answer:**

* **Boxing:** Converting a value type to `object`.
* **Unboxing:** Extracting value type from an object.

**Example:**

```csharp
int x = 10;
object obj = x; // Boxing
int y = (int)obj; // Unboxing
```

**Summary:** Boxing moves value types to heap; unboxing extracts them back.

---

## 🔹 9. What is the difference between Value Type and Reference Type?

| Value Type          | Reference Type          |
| ------------------- | ----------------------- |
| Stored in stack     | Stored in heap          |
| Holds actual data   | Holds reference to data |
| Examples: int, bool | Examples: class, array  |

**Summary:** Value = copies data, Reference = references memory.

---

## 🔹 10. What is a Struct in C#?

**Answer:**
Structs are value types that can contain fields, methods, and constructors but cannot inherit from other structs or classes.

**Example:**

```csharp
struct Point {
    public int X, Y;
}
```

**Summary:** Struct = lightweight object for small data structures.

---

## 🔹 11. What is Difference Between Class and Struct?

| Feature     | Class     | Struct        |
| ----------- | --------- | ------------- |
| Type        | Reference | Value         |
| Inheritance | Supported | Not supported |
| Memory      | Heap      | Stack         |

**Summary:** Class = heavy, Struct = lightweight.

---

## 🔹 12. What is a Nullable Type?

**Answer:**
Nullable types allow value types to hold `null`.

**Example:**

```csharp
int? age = null;
```

**Summary:** Nullable types handle missing or undefined values safely.

---

## 🔹 13. What is async and await in C#?

**Answer:**
`async` and `await` are used for asynchronous programming to avoid blocking the main thread.

**Example:**

```csharp
async Task DownloadDataAsync() {
    await Task.Delay(2000);
    Console.WriteLine("Download complete");
}
```

**Summary:** Async/await enables non-blocking, parallel operations.

---

## 🔹 14. What is Task and Thread difference?

| Thread                  | Task                      |
| ----------------------- | ------------------------- |
| Low-level construct     | High-level abstraction    |
| No automatic management | Managed by Task Scheduler |
| More control            | Easier async handling     |

**Summary:** Task simplifies thread management and async workflows.

---

## 🔹 15. What is Garbage Collection (GC)?

**Answer:**
Garbage Collection automatically reclaims unused memory from managed heap.

**Summary:** GC frees memory for unreachable objects.

---

## 🔹 16. What are Dispose() and Finalize() methods?

**Answer:**

* **Dispose():** Manual resource cleanup via `IDisposable`.
* **Finalize():** Automatic cleanup by GC before object destruction.

**Example:**

```csharp
class Sample : IDisposable {
    public void Dispose() => Console.WriteLine("Disposed");
}
```

**Summary:** Dispose = manual cleanup, Finalize = GC cleanup.

---

## 🔹 17. What is Dependency Injection (DI)?

**Answer:**
DI is a design pattern that allows removing hard-coded dependencies between classes.

**Example:**

```csharp
interface ILogger { void Log(); }
class FileLogger : ILogger { public void Log() => Console.WriteLine("File log"); }
class App {
    private readonly ILogger _logger;
    public App(ILogger logger) { _logger = logger; }
}
```

**Summary:** DI increases flexibility and testability.

---

## 🔹 18. What is Extension Method?

**Answer:**
Extension methods add new methods to existing types without modifying them.

**Example:**

```csharp
public static class StringExtensions {
    public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);
}
```

**Summary:** Extension methods extend functionality without inheritance.

---

## 🔹 19. What is Record in C# 9?

**Answer:**
Records are immutable reference types designed for data storage.

**Example:**

```csharp
public record Person(string Name, int Age);
```

**Summary:** Record = immutable class for data containers.

---

## 🔹 20. What are Tuples in C#?

**Answer:**
Tuples store multiple values of different types together.

**Example:**

```csharp
var person = ("John", 30);
Console.WriteLine(person.Item1);
```

**Summary:** Tuples = lightweight structure to group values.

---

## 🔹 21. What is Pattern Matching?

**Answer:**
Pattern matching simplifies conditional logic based on data type or value.

**Example:**

```csharp
object obj = 42;
if (obj is int num) Console.WriteLine(num);
```

**Summary:** Pattern matching enhances readability with conditional type checks.

---

## 🔹 22. What is Indexer in C#?

**Answer:**
Indexers allow objects to be indexed like arrays.

**Example:**

```csharp
class Sample {
    private int[] data = new int[5];
    public int this[int index] {
        get => data[index];
        set => data[index] = value;
    }
}
```

**Summary:** Indexers allow objects to act like arrays.

---

## 🔹 23. What is Difference between var, dynamic, and object?

| Keyword | Compile-time Type     | Runtime Type     | Performance |
| ------- | --------------------- | ---------------- | ----------- |
| var     | Fixed                 | Fixed            | Fast        |
| dynamic | Determined at runtime | Variable         | Slower      |
| object  | Base of all types     | Requires casting | Medium      |

**Summary:** Use `var` when type known, `dynamic` when unknown.

---

## 🔹 24. What are Anonymous Types?

**Answer:**
Anonymous types create objects without defining a class explicitly.

**Example:**

```csharp
var person = new { Name = "John", Age = 30 };
```

**Summary:** Anonymous types are for temporary, read-only grouped data.

---

## 🔹 25. What is Difference Between == and Equals()?

**Answer:**

* **==** compares object references (by default).
* **Equals()** compares object values.

**Example:**

```csharp
string a = "Hello";
string b = "Hello";
Console.WriteLine(a == b); // True
```

**Summary:** Override Equals() for custom value comparison.

---

✅ **End of Chapter 3: Advanced C# Concepts**
