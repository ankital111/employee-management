using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_management.Models;
using employee_management.Repository.Interfaces;

namespace employee_management.Repository
{
    // 🔹 Repository implements data operations (OOP: Inheritance + Polymorphism)
    // This class implements the interface (abstraction).
    public class EmployeeRepository : IEmployeeRepository
    {
        // In-memory list acts like a database (for demo)
        private readonly List<Employee> _employees = new();

        // async = allows parallel / non-blocking calls
        public async Task<IEnumerable<Employee>> GetAllAsync() => await Task.FromResult(_employees);

        public async Task<Employee> GetByIdAsync(int id) =>
            await Task.FromResult(_employees.FirstOrDefault(e => e.Id == id));

        public async Task AddAsync(Employee employee)
        {
            _employees.Add(employee);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Department = employee.Department;
                existing.Salary = employee.Salary;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
                _employees.Remove(emp);

            await Task.CompletedTask;
        }
    }
}
