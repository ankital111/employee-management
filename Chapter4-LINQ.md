# 📘 Chapter 4: LINQ (Language Integrated Query)

---

## 🌱 **1. What is LINQ in C#?**
**Answer:**
LINQ (Language Integrated Query) is a feature in C# that allows you to write queries directly within the C# language to retrieve and manipulate data from different data sources (Collections, SQL, XML, etc.) in a consistent way.

**Example:**
```csharp
var result = from n in numbers
             where n > 10
             select n;
```
---

## 🌿 **2. What are the different types of LINQ?**
**Answer:**
LINQ can be used with various data sources:
- **LINQ to Objects** – Collections, arrays, lists, etc.
- **LINQ to SQL** – Query SQL Server databases.
- **LINQ to Entities** – Used with Entity Framework.
- **LINQ to XML** – Work with XML data.
- **LINQ to DataSet** – Query DataSets in memory.

---

## 🌾 **3. What are the two ways to write LINQ queries?**
**Answer:**
1. **Query Syntax (Declarative):**
   ```csharp
   var result = from n in numbers where n > 10 select n;
   ```
2. **Method Syntax (Fluent):**
   ```csharp
   var result = numbers.Where(n => n > 10).Select(n => n);
   ```

---

## 🌼 **4. What is deferred execution in LINQ?**
**Answer:**
Deferred execution means the query is not executed when it is defined, but when it is iterated (e.g., in a `foreach` loop).  
This improves performance by delaying data retrieval until it’s actually needed.

**Example:**
```csharp
var query = numbers.Where(n => n > 10); // Not executed yet
foreach (var n in query)  // Executed here
    Console.WriteLine(n);
```
---

## 🌻 **5. What is immediate execution in LINQ?**
**Answer:**
Some methods (like `ToList()`, `ToArray()`, `Count()`, `Sum()`) cause immediate execution and return the results right away.

**Example:**
```csharp
var result = numbers.Where(n => n > 10).ToList(); // Executes immediately
```
---

## 🌳 **6. Difference between `Select()` and `SelectMany()`**
**Answer:**
- `Select()` → Projects each element of a collection.
- `SelectMany()` → Flattens a collection of collections into one sequence.

**Example:**
```csharp
var result = students.Select(s => s.Subjects);      // List<List<string>>
var flat = students.SelectMany(s => s.Subjects);    // List<string>
```
---

## 🌲 **7. Difference between `First()`, `FirstOrDefault()`, `Single()`, and `SingleOrDefault()`**
| Method | Throws Exception? | Returns |
|--------|--------------------|----------|
| `First()` | Yes if not found | First element |
| `FirstOrDefault()` | No | First element or default |
| `Single()` | Yes if 0 or >1 elements | Single element |
| `SingleOrDefault()` | Yes if >1 | Single or default value |

---

## 🌺 **8. What is `Where()` used for in LINQ?**
**Answer:**
Filters data based on a predicate (condition).

**Example:**
```csharp
var adults = persons.Where(p => p.Age > 18);
```
---

## 🌸 **9. Explain the use of `OrderBy()` and `ThenBy()`**
**Answer:**
Used for sorting data.
```csharp
var sorted = persons.OrderBy(p => p.LastName).ThenBy(p => p.FirstName);
```
---

## 🌹 **10. Difference between `Take()` and `Skip()`**
**Answer:**
- `Take(n)` → Takes first `n` records.
- `Skip(n)` → Skips first `n` records.

```csharp
var top5 = students.Take(5);
var next5 = students.Skip(5).Take(5);
```
---

## 🌻 **11. What are aggregate functions in LINQ?**
**Answer:**
- `Count()`, `Sum()`, `Min()`, `Max()`, `Average()`, `Aggregate()`

```csharp
int count = numbers.Count();
int total = numbers.Sum();
double avg = numbers.Average();
```
---

## 🍀 **12. What is `GroupBy()` in LINQ?**
**Answer:**
Used to group elements based on a key.

```csharp
var grouped = students.GroupBy(s => s.Department);
```
---

## 🌼 **13. Explain `Join()` in LINQ**
**Answer:**
Used to combine data from two collections based on a matching key.

```csharp
var result = from s in students
             join d in departments on s.DeptId equals d.Id
             select new { s.Name, d.Name };
```
---

## 🌺 **14. What is `Distinct()` in LINQ?**
**Answer:**
Removes duplicate elements from a sequence.

```csharp
var uniqueNames = names.Distinct();
```
---

## 🌾 **15. What is `Any()` and `All()`?**
**Answer:**
- `Any()` → Returns true if any element satisfies a condition.
- `All()` → Returns true if all elements satisfy a condition.

```csharp
bool hasAdults = persons.Any(p => p.Age > 18);
bool allAdults = persons.All(p => p.Age > 18);
```
---

## 🌳 **16. What is `Contains()` in LINQ?**
**Answer:**
Checks if a collection contains a specific element.

```csharp
bool exists = numbers.Contains(5);
```
---

## 🌲 **17. Explain `Union()`, `Intersect()`, and `Except()`**
| Method | Description |
|--------|--------------|
| `Union()` | Combines elements and removes duplicates |
| `Intersect()` | Common elements from both collections |
| `Except()` | Elements in first but not in second |
---

## 🌼 **18. What is `Let` keyword in LINQ?**
**Answer:**
Used to create a temporary variable to store intermediate results.

```csharp
var result = from n in numbers
             let square = n * n
             where square > 50
             select square;
```
---

## 🌺 **19. What are anonymous types in LINQ?**
**Answer:**
Used to create an object without defining a class.

```csharp
var result = from s in students
             select new { s.Name, s.Age };
```
---

## 🌹 **20. What are Expression Trees in LINQ?**
**Answer:**
Expression trees represent code in a tree-like structure.  
They’re used mainly in LINQ to SQL or Entity Framework for translating C# expressions to SQL.

---

## 🌻 **21. How does LINQ to SQL differ from LINQ to Objects?**
| LINQ to SQL | LINQ to Objects |
|--------------|----------------|
| Queries SQL Server databases | Works with in-memory collections |
| Uses deferred SQL translation | Executes in memory |
| Requires DataContext | Works directly with objects |
---

## 🌿 **22. What is `ToLookup()` in LINQ?**
**Answer:**
Similar to `GroupBy()` but returns a one-to-many dictionary (`ILookup<TKey, TValue>`).

```csharp
var lookup = persons.ToLookup(p => p.Department);
```
---

## 🌾 **23. What is the difference between `GroupBy()` and `ToLookup()`?**
| `GroupBy()` | `ToLookup()` |
|--------------|--------------|
| Deferred execution | Immediate execution |
| Returns IEnumerable<IGrouping> | Returns ILookup |
---

## 🌺 **24. What is `Zip()` in LINQ?**
**Answer:**
Merges two sequences element-wise.

```csharp
var result = numbers.Zip(names, (n, name) => $"{name}-{n}");
```
---

## 🌻 **25. What are Parallel LINQ (PLINQ) queries?**
**Answer:**
PLINQ allows parallel execution of LINQ queries for better performance on multicore processors.

```csharp
var result = numbers.AsParallel().Where(n => n > 10).ToList();
```
---

## 🌲 **26. What are limitations of LINQ?**
- Hard to optimize for complex SQL.
- Debugging complex queries can be difficult.
- Deferred execution may cause unexpected behavior.
- Not suitable for all performance-critical scenarios.

---

## 🌳 **27. What is the difference between IQueryable and IEnumerable?**
| Feature | IEnumerable | IQueryable |
|----------|-------------|-------------|
| Execution | In-memory | Remote (e.g., SQL) |
| Filtering | Done in-memory | Done in data source |
| Use case | LINQ to Objects | LINQ to SQL/EF |
---

## 🌼 **28. What is projection in LINQ?**
**Answer:**
Selecting specific fields from objects (not the whole object).

```csharp
var names = students.Select(s => s.Name);
```
---

## 🌿 **29. How can you handle exceptions in LINQ?**
Use try-catch around LINQ query execution (especially for database queries).

```csharp
try
{
    var result = context.Students.Where(s => s.Age > 18).ToList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
---

## 🌻 **30. What are extension methods in LINQ?**
**Answer:**
LINQ methods (`Where`, `Select`, etc.) are implemented as **extension methods** on `IEnumerable` and `IQueryable` interfaces.

---

## 🌹 **31. How to debug LINQ queries?**
- Use `.ToList()` to force execution.
- Use breakpoints inside query projections.
- Use `Immediate Window` in Visual Studio.
- Use logging in EF (`Database.Log` or `ILogger`).
---

## 🌾 **32. What is query comprehension syntax in LINQ?**
**Answer:**
Declarative syntax similar to SQL.
```csharp
var query = from s in students
            where s.Age > 20
            select s.Name;
```
---

## 🌳 **33. What are lambda expressions in LINQ?**
**Answer:**
Short syntax for inline functions used in LINQ.

```csharp
var result = students.Where(s => s.Age > 18);
```
---

## 🌲 **34. Can LINQ queries be dynamic?**
**Answer:**
Yes, using `System.Linq.Dynamic` or `Expression Trees` to build queries at runtime.

---

## 🌼 **35. What is difference between LINQ and SQL?**
| LINQ | SQL |
|------|-----|
| Integrated with C# | Separate language |
| Type-safe | Not type-safe |
| Checked at compile time | Checked at runtime |
| Works with objects | Works with tables |
