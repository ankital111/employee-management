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

Q3. Difference between List, Dictionary, HashSet, Queue, Stack
Collection	Description	Key Feature
List<T>	Ordered, index-based	Fast lookup by index
Dictionary<TKey,TValue>	Key-value pairs	Fast lookup by key
HashSet<T>	Unordered, unique items	Ensures no duplicates
Queue<T>	FIFO (First In, First Out)	Used for processing order
Stack<T>	LIFO (Last In, First Out)	Used for backtracking
