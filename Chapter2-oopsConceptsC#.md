# Chapter 2: OOP Concepts in C#

Object-Oriented Programming (OOP) is a paradigm based on objects and classes. It helps organize code into reusable, scalable, and maintainable components.

---

## 🔹 1. What is Object-Oriented Programming (OOP)?

**Answer:**
OOP is a programming paradigm that uses objects and classes to structure software programs. Objects represent real-world entities and contain data (fields) and behavior (methods).

**Example:**

```csharp
class Car {
    public string Model;
    public void Start() {
        Console.WriteLine("Car started");
    }
}

Car myCar = new Car();
myCar.Model = "BMW";
myCar.Start();
```

**Summary:** OOP organizes code around objects instead of functions, improving reusability and maintainability.

---

## 🔹 2. What are the main principles of OOP?

**Answer:**
There are four main OOP principles:

1. **Encapsulation** – Hiding data using access modifiers.
2. **Abstraction** – Showing essential features and hiding the background details.
3. **Inheritance** – Acquiring properties of one class into another.
4. **Polymorphism** – Same function behaving differently based on context.

**Summary:** Core principles of OOP are Encapsulation, Abstraction, Inheritance, and Polymorphism.

---

## 🔹 3. What is a Class in C#?

**Answer:**
A class is a blueprint or template for creating objects. It defines the properties (data) and methods (behavior) that its objects will have.

**Example:**

```csharp
public class Person {
    public string Name;
    public void Speak() {
        Console.WriteLine($"Hello, my name is {Name}");
    }
}
```

**Summary:** A class defines structure and behavior for objects.

---

## 🔹 4. What is an Object?

**Answer:**
An object is an instance of a class. It occupies memory and interacts with other objects through methods and properties.

**Example:**

```csharp
Person p1 = new Person();
p1.Name = "John";
p1.Speak();
```

**Summary:** Object = Instance of a class that holds real data.

---

## 🔹 5. Explain Encapsulation with example.

**Answer:**
Encapsulation means restricting direct access to object data and providing controlled access through methods or properties.

**Example:**

```csharp
public class BankAccount {
    private double balance;

    public void Deposit(double amount) {
        if(amount > 0)
            balance += amount;
    }

    public double GetBalance() => balance;
}
```

**Summary:** Encapsulation hides data and ensures controlled access.

---

## 🔹 6. Explain Abstraction with example.

**Answer:**
Abstraction hides implementation details and shows only essential features to the user.

**Example:**

```csharp
abstract class Animal {
    public abstract void MakeSound();
}

class Dog : Animal {
    public override void MakeSound() => Console.WriteLine("Bark");
}
```

**Summary:** Abstraction = Hiding internal logic, exposing only necessary details.

---

## 🔹 7. Explain Inheritance with example.

**Answer:**
Inheritance allows one class to inherit the fields and methods of another class using the `:` symbol.

**Example:**

```csharp
class Animal {
    public void Eat() => Console.WriteLine("Eating...");
}

class Dog : Animal {
    public void Bark() => Console.WriteLine("Barking...");
}
```

**Summary:** Inheritance promotes reusability by allowing classes to derive from existing ones.

---

## 🔹 8. What is Polymorphism? Explain with example.

**Answer:**
Polymorphism means "many forms"—a single interface or method behaves differently based on context.

**Example (Runtime Polymorphism):**

```csharp
class Animal {
    public virtual void Speak() => Console.WriteLine("Animal sound");
}
class Dog : Animal {
    public override void Speak() => Console.WriteLine("Bark");
}
```

**Summary:** Polymorphism allows methods to behave differently depending on the object type.

---

## 🔹 9. What is Method Overloading and Overriding?

**Answer:**

* **Overloading (Compile-time polymorphism):** Same method name, different parameters.
* **Overriding (Runtime polymorphism):** Redefining a base class method in the derived class.

**Example:**

```csharp
class MathOp {
    public int Add(int a, int b) => a + b; // Overload 1
    public double Add(double a, double b) => a + b; // Overload 2
}

class Animal {
    public virtual void Speak() => Console.WriteLine("Animal sound");
}
class Dog : Animal {
    public override void Speak() => Console.WriteLine("Bark");
}
```

**Summary:** Overloading = Same name, diff params. Overriding = Redefining base method.

---

## 🔹 10. What are Access Modifiers in C#?

**Answer:**
Access modifiers define the visibility of class members.

* **public** – accessible everywhere
* **private** – accessible within class only
* **protected** – accessible in derived classes
* **internal** – accessible within the same assembly

**Example:**

```csharp
public class Employee {
    private int salary;
    protected void Display() { }
}
```

**Summary:** Access modifiers control visibility of members.

---

## 🔹 11. What is Constructor in C#?

**Answer:**
A constructor is a special method called automatically when an object is created. It initializes class members.

**Example:**

```csharp
class Student {
    public string Name;
    public Student(string name) {
        Name = name;
    }
}
```

**Summary:** Constructor initializes object state.

---

## 🔹 12. What is Destructor in C#?

**Answer:**
A destructor is used to perform cleanup before an object is destroyed. It is declared using `~ClassName()`.

**Example:**

```csharp
class Sample {
    ~Sample() {
        Console.WriteLine("Object destroyed");
    }
}
```

**Summary:** Destructor releases resources before object removal.

---

## 🔹 13. What is an Interface?

**Answer:**
An interface defines a contract that implementing classes must follow. It only contains method signatures, not implementation.

**Example:**

```csharp
interface IAnimal {
    void Speak();
}

class Dog : IAnimal {
    public void Speak() => Console.WriteLine("Bark");
}
```

**Summary:** Interface defines what a class should do, not how.

---

## 🔹 14. What is an Abstract Class?

**Answer:**
An abstract class cannot be instantiated and may contain abstract and non-abstract methods.

**Example:**

```csharp
abstract class Shape {
    public abstract void Draw();
}
class Circle : Shape {
    public override void Draw() => Console.WriteLine("Drawing Circle");
}
```

**Summary:** Abstract class = base class with abstract methods.

---

## 🔹 15. What is the difference between Abstract Class and Interface?

| Feature              | Abstract Class                 | Interface          |
| -------------------- | ------------------------------ | ------------------ |
| Methods              | Can have implementation        | No implementation  |
| Multiple Inheritance | Not supported                  | Supported          |
| Fields               | Can have fields                | Cannot have fields |
| Use                  | Common base with partial logic | Common contract    |

**Summary:** Abstract = partial logic, Interface = pure contract.

---

## 🔹 16. What is a Static Class?

**Answer:**
Static classes cannot be instantiated and contain only static members.

**Example:**

```csharp
static class MathUtil {
    public static int Add(int a, int b) => a + b;
}
```

**Summary:** Static classes hold utility methods shared across application.

---

## 🔹 17. What is a Sealed Class?

**Answer:**
A sealed class cannot be inherited.

**Example:**

```csharp
sealed class FinalClass { }
```

**Summary:** Sealed classes prevent inheritance for security or stability.

---

## 🔹 18. What is this keyword in C#?

**Answer:**
`this` refers to the current class instance. It is used to access class members or differentiate between local and instance variables.

**Example:**

```csharp
class Person {
    string name;
    public Person(string name) {
        this.name = name;
    }
}
```

**Summary:** `this` refers to the current instance of the class.

---

## 🔹 19. What is base keyword in C#?

**Answer:**
`base` is used to access members of the base class from a derived class.

**Example:**

```csharp
class Parent {
    public void Show() => Console.WriteLine("Parent");
}
class Child : Parent {
    public void Display() {
        base.Show();
    }
}
```

**Summary:** `base` accesses parent class members.

---

## 🔹 20. What is the difference between new and override keywords?

**Answer:**

* **new** – Hides base class method.
* **override** – Extends/redefines base class method behavior.

**Example:**

```csharp
class BaseClass {
    public virtual void Show() => Console.WriteLine("Base");
}
class Derived : BaseClass {
    public new void Show() => Console.WriteLine("New Base");
    public override void Show() => Console.WriteLine("Override Base");
}
```

**Summary:** `new` hides; `override` replaces base implementation.

---

✅ **End of Chapter 2: OOP Concepts in C#**
