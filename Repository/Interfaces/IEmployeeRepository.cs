using System.Collections.Generic;
using System.Threading.Tasks;
using employee_management.Models;

namespace employee_management.Repository.Interfaces
{
    // 🔹 Interface defines what methods a class must implement (OOP: Abstraction)
    // Abstraction hides the internal logic, showing only what is necessary.
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(); // Get all employees
        Task<Employee> GetByIdAsync(int id);       // Get employee by ID
        Task AddAsync(Employee employee);          // Add new employee
        Task UpdateAsync(Employee employee);       // Update existing employee
        Task DeleteAsync(int id);                  // Delete employee
    }
}
