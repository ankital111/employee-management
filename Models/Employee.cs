using System;

namespace employee_management.Models
{
    // 🔹 Employee class represents one Employee entity (OOP: Encapsulation)
    // Encapsulation = keeping related data & behavior together in one class.
    public class Employee
    {
        // These are auto-implemented properties (data fields of Employee)
        public int Id { get; set; }            // Unique Employee ID
        public string Name { get; set; }       // Employee Name
        public string Department { get; set; } // Department Name
        public decimal Salary { get; set; }    // Employee Salary
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Auto timestamp
    }
}
