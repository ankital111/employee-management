# 🧠 .NET Interview Preparation Q&A Guide

A simple and easy-to-understand guide for quick .NET interview preparation.

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
