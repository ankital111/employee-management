using System.Collections.Generic;
using System.Threading.Tasks;
using employee_management.Models;
using employee_management.Repository.Interfaces;

namespace employee_management.Services
{
    // 🔹 Service layer holds business logic
    // It uses Dependency Injection to access repository
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        // Dependency Injection = object is provided, not created inside
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // Example of async method calling repository
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() =>
            await _repository.GetAllAsync();

        public async Task<Employee> GetEmployeeByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task AddEmployeeAsync(Employee employee) =>
            await _repository.AddAsync(employee);

        public async Task UpdateEmployeeAsync(Employee employee) =>
            await _repository.UpdateAsync(employee);

        public async Task DeleteEmployeeAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
