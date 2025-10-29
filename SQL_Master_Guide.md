# SQL Master Guide – Learn SQL in One Day (with C# Integration)

---

## 🧭 Introduction to Databases & SQL

**Database:** A structured collection of data stored electronically.  
**SQL (Structured Query Language):** A language used to interact with relational databases — for creating, reading, updating, and deleting data.

### Why SQL?
- Stores and organizes large amounts of data.
- Ensures data integrity and security.
- Integrates easily with programming languages like C#.

---

## 🧱 SQL Basics – Syntax & Data Types

### Common SQL Commands
| Command Type | Description | Example |
|---------------|-------------|----------|
| DDL | Data Definition Language (structure) | CREATE, ALTER, DROP |
| DML | Data Manipulation Language (data) | INSERT, UPDATE, DELETE |
| DQL | Data Query Language (retrieve) | SELECT |
| TCL | Transaction Control Language | COMMIT, ROLLBACK |
| DCL | Data Control Language | GRANT, REVOKE |

### Common Data Types
- `INT` – Integer numbers  
- `VARCHAR(n)` – Text (up to n characters)  
- `DATE` – Dates  
- `FLOAT` / `DECIMAL` – Numbers with decimals  
- `BIT` – Boolean (0/1)

---

## 🏗️ DDL – Data Definition Language

### CREATE Database & Table
```sql
CREATE DATABASE EmployeeDB;
USE EmployeeDB;

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Age INT,
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE
);
```

### ALTER Table
```sql
ALTER TABLE Employees ADD Email VARCHAR(100);
ALTER TABLE Employees DROP COLUMN Age;
```

### DROP Table
```sql
DROP TABLE Employees;
```

---

## ✏️ DML – Data Manipulation Language

### INSERT
```sql
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
VALUES ('Ankita', 'Patil', 1, 55000, '2024-04-12');
```

### UPDATE
```sql
UPDATE Employees SET Salary = 60000 WHERE EmployeeID = 1;
```

### DELETE
```sql
DELETE FROM Employees WHERE EmployeeID = 3;
```

### SELECT
```sql
SELECT * FROM Employees;
SELECT FirstName, Salary FROM Employees WHERE Salary > 50000;
```

---

## 🔍 Filtering, Sorting & Functions

### WHERE, ORDER BY, LIKE
```sql
SELECT * FROM Employees WHERE Salary BETWEEN 40000 AND 80000;
SELECT * FROM Employees WHERE FirstName LIKE 'A%';
SELECT * FROM Employees ORDER BY Salary DESC;
```

### Aggregate Functions
```sql
SELECT COUNT(*) AS TotalEmployees FROM Employees;
SELECT AVG(Salary) AS AvgSalary FROM Employees;
SELECT MAX(Salary) AS HighestSalary FROM Employees;
```

### String & Date Functions
```sql
SELECT UPPER(FirstName), LOWER(LastName) FROM Employees;
SELECT GETDATE() AS TodayDate, YEAR(JoinDate) AS JoinYear FROM Employees;
```

---

## 🔗 Joins (Combining Tables)

| Type | Description |
|------|--------------|
| INNER JOIN | Returns matching rows from both tables |
| LEFT JOIN | Returns all rows from left table + matched from right |
| RIGHT JOIN | Returns all rows from right + matched from left |
| FULL JOIN | Returns all rows when there's a match in either table |
| SELF JOIN | A table joined to itself |

```sql
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName VARCHAR(50)
);

SELECT e.FirstName, d.DepartmentName
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID;
```

---

## 🔍 Subqueries, Views & Indexes

### Subquery
```sql
SELECT * FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);
```

### View
```sql
CREATE VIEW HighSalaryEmployees AS
SELECT FirstName, Salary FROM Employees WHERE Salary > 70000;

SELECT * FROM HighSalaryEmployees;
```

### Index
```sql
CREATE INDEX idx_Department ON Employees(DepartmentID);
```

---

## ⚙️ Stored Procedures & Triggers

### Stored Procedure
```sql
CREATE PROCEDURE GetEmployeesByDept @DeptID INT
AS
BEGIN
    SELECT * FROM Employees WHERE DepartmentID = @DeptID;
END;
EXEC GetEmployeesByDept 1;
```

### Trigger
```sql
CREATE TRIGGER trgAfterInsert
ON Employees
AFTER INSERT
AS
BEGIN
    PRINT 'New employee record added';
END;
```

---

## 🔒 Transactions, ACID & Constraints

### Transactions
```sql
BEGIN TRANSACTION;
UPDATE Employees SET Salary = Salary + 1000 WHERE DepartmentID = 1;
COMMIT;  -- or ROLLBACK;
```

### ACID Properties
| Property | Description |
|-----------|--------------|
| Atomicity | All operations succeed or none do |
| Consistency | Database remains valid before & after transaction |
| Isolation | Transactions run independently |
| Durability | Data persists after success |

### Constraints
```sql
ALTER TABLE Employees ADD CONSTRAINT chk_Salary CHECK (Salary > 0);
ALTER TABLE Employees ADD CONSTRAINT fk_Dept FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID);
```

---

## ⚡ Optimization & Normalization

### Normalization (Data Organization)
- **1NF:** Each column holds one value  
- **2NF:** Each non-key depends on full primary key  
- **3NF:** Remove indirect dependencies

### Performance Tips
- Use **indexes** wisely (too many slow down writes)
- Avoid `SELECT *`, specify needed columns
- Use **stored procedures** instead of dynamic SQL
- Use **pagination** for large results

---

## 🧠 Error Handling & Security

### TRY–CATCH in SQL
```sql
BEGIN TRY
  INSERT INTO Employees (FirstName, Salary) VALUES ('Test', -100);
END TRY
BEGIN CATCH
  PRINT ERROR_MESSAGE();
END CATCH;
```

### Security Tips
- Use **user roles** and permissions (GRANT, REVOKE)
- Avoid direct SQL from C# (use parameters to prevent SQL Injection)
- Use **views** for restricted data access

---

## 💻 C# Integration with SQL

### Using ADO.NET
```csharp
using System.Data.SqlClient;

string connectionString = "Server=.;Database=EmployeeDB;Trusted_Connection=True;";
string query = "SELECT * FROM Employees WHERE DepartmentID = @DeptID";

using (SqlConnection con = new SqlConnection(connectionString))
{
    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.AddWithValue("@DeptID", 1);
    con.Open();

    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader["FirstName"]);
    }
}
```

### Using Dapper
```csharp
using Dapper;
using System.Data.SqlClient;

using (var connection = new SqlConnection(connectionString))
{
    var employees = connection.Query<Employee>("SELECT * FROM Employees WHERE DepartmentID = @DeptID", new { DeptID = 1 });
    foreach (var emp in employees)
        Console.WriteLine(emp.FirstName);
}
```

### Using Entity Framework Core
```csharp
public class EmployeeContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
}
```

---

## 🧩 Real Project Example – Employee Management System

### Database Design
**Tables:**
- Employees(EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
- Departments(DepartmentID, DepartmentName)
- EmployeeLogs(LogID, EmployeeID, Action, LogDate)

### SQL Example
```sql
CREATE TRIGGER trg_LogInsert
ON Employees
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeLogs (EmployeeID, Action, LogDate)
    SELECT EmployeeID, 'INSERT', GETDATE() FROM inserted;
END;
```

---

## 🧾 Quick Reference Commands

| Category | Command | Example |
|-----------|----------|----------|
| Create DB | CREATE DATABASE | CREATE DATABASE School; |
| Create Table | CREATE TABLE | CREATE TABLE Students (...); |
| Insert | INSERT INTO | INSERT INTO Students VALUES (...); |
| Update | UPDATE | UPDATE Students SET Name='Asha'; |
| Delete | DELETE | DELETE FROM Students WHERE ID=1; |
| Select | SELECT | SELECT * FROM Students; |
| Join | INNER JOIN | SELECT * FROM A INNER JOIN B ON A.ID=B.ID; |
| Procedure | CREATE PROCEDURE | CREATE PROCEDURE GetStudent AS ... |
| Trigger | CREATE TRIGGER | CREATE TRIGGER trgInsert ON Table ... |
| Transaction | BEGIN TRAN | BEGIN TRAN; ... COMMIT; |

---

## 🎯 Interview Quick Notes

1. **Difference between DELETE, TRUNCATE, DROP**
   - DELETE: Removes selected rows (can rollback)
   - TRUNCATE: Removes all rows (cannot rollback)
   - DROP: Deletes table structure itself

2. **Primary vs Unique Key**
   - Primary: Only one allowed, auto index
   - Unique: Multiple allowed, allows NULL

3. **INNER vs LEFT JOIN**
   - INNER: Only matching records
   - LEFT: All left + matches from right

4. **Clustered vs Non-clustered Index**
   - Clustered: Sorts data physically
   - Non-clustered: Separate structure

5. **SQL Injection Prevention**
   - Use parameterized queries or stored procedures

---

## ✅ Summary

By the end of this guide, you should understand:
- How SQL stores and manipulates data
- How to connect SQL with C#
- How to create real systems like Employee Management using joins, triggers, and transactions

