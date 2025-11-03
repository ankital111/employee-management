# 🧩 Chapter 3: Collections and Generics in C#

---

## 📘 Overview
Collections in C# are used to store, manage, and manipulate groups of related objects.  
They exist in both **non-generic** (`ArrayList`, `Hashtable`) and **generic** (`List<T>`, `Dictionary<TKey,TValue>`) forms.

Generics provide **type safety**, **performance**, and **code reusability** — key to writing efficient, modern C# code.

---

## 🎯 Basic & Intermediate Questions

---

### **Q1. What are collections in C#?**
Collections are classes that store multiple objects.  
They help manage data dynamically — adding, removing, and iterating through elements.

📦 Types:
- **Non-generic** (System.Collections): `ArrayList`, `Hashtable`, `Queue`, `Stack`
- **Generic** (System.Collections.Generic): `List<T>`, `Dictionary<TKey,TValue>`, `HashSet<T>`, etc.

---

### **Q2. What is the difference between Array and ArrayList?**

| Feature | Array | ArrayList |
|----------|--------|-----------|
| Type Safety | Fixed type | Stores `object`, not type-safe |
| Size | Fixed | Dynamic |
| Performance | Fast (no boxing) | Slower (boxing/unboxing for value types) |
| Namespace | System | System.Collections |

Example:
```csharp
int[] arr = new int[3] {1, 2, 3};
ArrayList list = new ArrayList {1, "two", 3.0}; // mixed types
```

---

### **Q3. Difference between List, Dictionary, HashSet, Queue, Stack**

| Collection | Description | Key Feature |
|-------------|--------------|--------------|
| `List<T>` | Ordered, index-based | Fast lookup by index |
| `Dictionary<TKey,TValue>` | Key-value pairs | Fast lookup by key |
| `HashSet<T>` | Unordered, unique items | Ensures no duplicates |
| `Queue<T>` | FIFO (First In, First Out) | Used for processing order |
| `Stack<T>` | LIFO (Last In, First Out) | Used for backtracking |

---

### **Q4. Difference between IEnumerable, ICollection, and IList**

| Interface | Description | Example |
|------------|-------------|----------|
| `IEnumerable<T>` | Allows iteration (`foreach`) | `foreach (var i in list)` |
| `ICollection<T>` | Extends `IEnumerable`, supports Count/Add/Remove | `list.Add(1)` |
| `IList<T>` | Extends `ICollection`, supports index access | `list[0]` |

---

### **Q5. What are generics and why are they useful?**
Generics allow defining **classes, interfaces, and methods** with placeholders for data types.

**Benefits:**
- Type safety
- Better performance (no boxing/unboxing)
- Code reusability

Example:
```csharp
List<int> numbers = new List<int> { 1, 2, 3 };
```

---

### **Q6. What is covariance and contravariance?**
- **Covariance (`out`)** → Allows a derived type to be assigned to a base type reference.
- **Contravariance (`in`)** → Allows a base type to be assigned to a derived type reference.

Example:
```csharp
IEnumerable<string> strings = new List<string>();
IEnumerable<object> objs = strings; // ✅ Covariance

Action<object> actObj = (obj) => { };
Action<string> actStr = actObj; // ✅ Contravariance
```

---

### **Q7. What are generic constraints where T : class, struct, new()?**

| Constraint | Description |
|-------------|-------------|
| `where T : class` | Only reference types |
| `where T : struct` | Only value types |
| `where T : new()` | Must have public parameterless constructor |

Example:
```csharp
class Factory<T> where T : new()
{
    public T Create() => new T();
}
```

---

### **Q8. What are tuples in C#?**
Tuples group multiple values into a single object without creating a class.

```csharp
var person = (Name: "Ankita", Age: 32);
Console.WriteLine($"{person.Name}, {person.Age}");
```

---

### **Q9. What is a SortedList vs SortedDictionary?**

| Feature | SortedList<TKey,TValue> | SortedDictionary<TKey,TValue> |
|----------|-------------------------|-------------------------------|
| Storage | Backed by array | Backed by binary tree |
| Access | Faster read | Faster insert/delete |
| Memory | Less overhead | More overhead |
| Order | Always sorted | Always sorted |

---

### **Q10. What are concurrent collections?**
Thread-safe collections in `System.Collections.Concurrent`.

Examples:
- `ConcurrentBag<T>`
- `ConcurrentQueue<T>`
- `ConcurrentStack<T>`
- `ConcurrentDictionary<TKey,TValue>`

They handle **multi-threaded scenarios** without explicit locks.

---

## 🚀 Advanced Collections & Generics Interview Questions

---

### **Q21. What is the difference between IEnumerable, ICollection, IList, and IQueryable?**
| Interface | Purpose | Execution Type |
|------------|----------|----------------|
| `IEnumerable<T>` | Basic iteration | In-memory |
| `ICollection<T>` | Add/remove/count | In-memory |
| `IList<T>` | Indexed access | In-memory |
| `IQueryable<T>` | LINQ provider | Deferred (SQL) |

---

### **Q22. How does HashSet<T> ensure uniqueness?**
Uses **hashing** + `Equals()` and `GetHashCode()` to check duplicates.

```csharp
HashSet<string> hs = new() { "A", "B", "A" };
Console.WriteLine(hs.Count); // 2
```

---

### **Q23. Difference between Dictionary and ConcurrentDictionary**

| Feature | Dictionary | ConcurrentDictionary |
|----------|-------------|----------------------|
| Thread Safe | ❌ No | ✅ Yes |
| Performance | Faster | Slightly slower |
| Use Case | Single thread | Multi-threaded |

---

### **Q24. ReadOnlyCollection vs ImmutableCollection**

| Feature | ReadOnlyCollection<T> | ImmutableCollection<T> |
|----------|-----------------------|-------------------------|
| Mutability | Wraps mutable list | True immutability |
| Namespace | `System.Collections.ObjectModel` | `System.Collections.Immutable` |

---

### **Q25. IEnumerable vs IEnumerator**

| Interface | Purpose |
|------------|----------|
| `IEnumerable<T>` | Exposes `GetEnumerator()` |
| `IEnumerator<T>` | Has `MoveNext()` & `Current` |

---

### **Q26. What is yield return in C#?**
Creates an iterator without creating a separate collection.

```csharp
IEnumerable<int> GetNumbers()
{
    for (int i = 1; i <= 3; i++)
        yield return i;
}
```

---

### **Q27. How does Dictionary<TKey, TValue> handle collisions?**
- Uses **hash buckets**
- Collision handled via **chaining (linked lists)** or **probing**

---

### **Q28. Shallow Copy vs Deep Copy**

| Copy Type | Description |
|------------|-------------|
| Shallow | Copies references only |
| Deep | Copies objects fully |

---

### **Q29. Can you create generic class with multiple type parameters?**
```csharp
public class Pair<T1, T2>
{
    public T1 Key { get; set; }
    public T2 Value { get; set; }
}
```

---

### **Q30. Using LINQ with Collections**
```csharp
var grouped = employees.GroupBy(e => e.Dept);
foreach (var group in grouped)
{
    Console.WriteLine(group.Key);
    foreach (var emp in group) Console.WriteLine(emp.Name);
}
```

---

### **Q31. Covariance and Contravariance in Generics**
| Concept | Keyword | Direction |
|----------|----------|-----------|
| Covariance | `out` | Derived → Base |
| Contravariance | `in` | Base → Derived |

---

### **Q32. Ensuring Thread Safety in Collections**
- Use `lock` statement  
- Use **Concurrent Collections**

```csharp
lock (objLock) list.Add(1);
```

---

### **Q33. List<T> vs LinkedList<T>**

| Feature | List<T> | LinkedList<T> |
|----------|-----------|---------------|
| Storage | Array | Nodes |
| Access | O(1) by index | O(n) |
| Insert/Delete | Slow | Fast |
| Use Case | Random access | Frequent insertions |

---

### **Q34. Modifying Collection during Iteration**
Throws `InvalidOperationException`.

✅ Use `for` loop or copy via `.ToList()`.

---

### **Q35. Custom Comparer in Collections**
```csharp
class CaseInsensitiveComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y) =>
        string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
    public int GetHashCode(string obj) => obj.ToLower().GetHashCode();
}
```

---

## 🏁 Summary

| Concept | Description |
|----------|--------------|
| Collections | Manage groups of objects |
| Generics | Enable type safety & reusability |
| Interfaces | Define behavior for iteration & access |
| Advanced Topics | Thread safety, immutability, performance |

---

✅ **Ready for Interview:**  
This chapter covers **35+ essential & advanced** C# questions for .NET developer interviews — perfect for companies like **Barclays, Accenture, or Microsoft**.
