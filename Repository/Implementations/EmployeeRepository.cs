using System.Collections.Generic;
using System.Threading.Tasks;
using employee_management.Data;
using employee_management.Models;
using employee_management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace employee_management.Repository.Implementations
{
    // 🔹 EmployeeRepository handles all Employee data operations using EF Core
    // Demonstrates OOP concepts: Inheritance, Abstraction, Encapsulation, and Polymorphism
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor Injection (OOP: Dependency Injection)
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all employees (Async + LINQ)
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            // EF Core translates this to SQL: SELECT * FROM Employees
            return await _context.Employees.ToListAsync();
        }

        // Get employee by ID
        public async Task<Employee> GetByIdAsync(int id)
        {
            // SELECT * FROM Employees WHERE Id = id
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        // Add new employee
        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync(); // 🔹 Saves to database
        }

        // Update existing employee
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(); // 🔹 Applies changes
        }

        // Delete employee
        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
