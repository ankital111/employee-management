# SOLID Principles in C# (.NET 8)

SOLID is an acronym for five design principles that make your software **scalable, maintainable, testable, and reusable.**

| Letter | Principle                       | Key Idea                                           |
| :----: | :------------------------------ | :------------------------------------------------- |
|  **S** | Single Responsibility Principle | One class = One responsibility                     |
|  **O** | Open/Closed Principle           | Open for extension, closed for modification        |
|  **L** | Liskov Substitution Principle   | Derived classes must be replaceable for their base |
|  **I** | Interface Segregation Principle | Prefer small, specific interfaces                  |
|  **D** | Dependency Inversion Principle  | Depend on abstractions, not concrete classes       |

---

## 1. Single Responsibility Principle (SRP)

> A class should have only one reason to change.

Each class or module should focus on one task.

### Wrong Example:

```csharp
public class EmployeeService
{
    public void AddEmployee(Employee emp)
    {
        // Save employee to database
    }

    public void GenerateReport()
    {
        // Also generate PDF report (not related)
    }
}
```

### Correct Example:

```csharp
public class EmployeeService
{
    private readonly IEmployeeRepository _repository;
    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public void AddEmployee(Employee emp)
    {
        _repository.AddAsync(emp);
    }
}

public class ReportService
{
    public void GenerateReport(List<Employee> employees)
    {
        // Logic for PDF or Excel report
    }
}
```

**In your project:**

* `EmployeeService` handles business logic
* `EmployeeRepository` handles database logic
* `ReportService` or `LoggingService` handle their own concern

---

## 2. Open/Closed Principle (OCP)

> Software entities should be open for extension, but closed for modification.

You should be able to add new features without modifying existing code.

### Wrong Example:

```csharp
public class SalaryCalculator
{
    public decimal CalculateBonus(Employee emp)
    {
        if (emp.Department == "HR") return emp.Salary * 0.10m;
        else if (emp.Department == "IT") return emp.Salary * 0.20m;
        return 0;
    }
}
```

### Correct Example:

```csharp
public interface IBonusCalculator
{
    decimal Calculate(Employee emp);
}

public class HRBonusCalculator : IBonusCalculator
{
    public decimal Calculate(Employee emp) => emp.Salary * 0.10m;
}

public class ITBonusCalculator : IBonusCalculator
{
    public decimal Calculate(Employee emp) => emp.Salary * 0.20m;
}
```

Adding a new department means adding a new class—not changing old code.

---

## 3. Liskov Substitution Principle (LSP)

> Derived classes must be substitutable for their base classes.

### Correct Example:

```csharp
public abstract class Employee
{
    public abstract decimal GetBonus();
}

public class PermanentEmployee : Employee
{
    public override decimal GetBonus() => 1000;
}

public class ContractEmployee : Employee
{
    public override decimal GetBonus() => 500;
}
```

If subclasses behave differently but still respect the base contract, LSP is followed.

---

## 4. Interface Segregation Principle (ISP)

> Clients should not be forced to depend on interfaces they do not use.

### Wrong Example:

```csharp
public interface IEmployeeOperations
{
    void AddEmployee();
    void GenerateReport();
    void SendEmail();
}
```

### Correct Example:

```csharp
public interface IEmployeeRepository
{
    void AddEmployee();
}

public interface IReportService
{
    void GenerateReport();
}

public interface INotificationService
{
    void SendEmail();
}
```

Separate small interfaces make the system more flexible.

---

## 5. Dependency Inversion Principle (DIP)

> High-level modules should not depend on low-level modules. Both should depend on abstractions.

### Wrong Example:

```csharp
public class EmployeeController
{
    private EmployeeRepository _repo = new EmployeeRepository(); // tightly coupled
}
```

### Correct Example:

```csharp
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _repo;

    public EmployeeController(IEmployeeRepository repo)
    {
        _repo = repo; // abstraction injected
    }
}
```

**Dependency Injection setup:**

```csharp
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
```

---

## Benefits of SOLID

| Principle | Benefit                                    |
| :-------- | :----------------------------------------- |
| **S**     | Each class easier to maintain              |
| **O**     | Add features without breaking old ones     |
| **L**     | Derived classes behave correctly           |
| **I**     | Interfaces small & focused                 |
| **D**     | Easily testable & replaceable dependencies |

---

## Tips

* **Why SOLID principles?** → Improve readability, maintainability, and scalability.
* **Which SOLID principle uses Dependency Injection?** → Dependency Inversion.
* **Difference between SRP and OCP?** → SRP is about *responsibility*, OCP is about *extensibility*.
* **Example of LSP violation?** → Subclass throws `NotImplementedException`.
* **Why use interfaces?** → Abstraction, loose coupling, flexibility.

---

These principles will make your .NET 8 project clean, extensible, and professional-grade.
