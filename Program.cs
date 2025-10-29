using Microsoft.EntityFrameworkCore;
using employee_management.Data;
using employee_management.Repository.Interfaces;
using employee_management.Services;
using employee_management.Middleware;
using employee_management.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// 🔹 1. Configure Database (Dependency Injection)
// ========================================
// Here we tell EF Core to use SQL Server and get the connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ========================================
// 🔹 2. Register Repository and Service (OOP + DI)
// ========================================
// - Repository Pattern: Handles data access (Database logic)
// - Service Layer: Handles business logic
// - Dependency Injection (DI): Allows us to easily replace implementations during testing or scaling
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();

// ========================================
// 🔹 3. Add Controllers
// ========================================
// Controllers handle API requests (e.g., GET, POST, PUT, DELETE)
builder.Services.AddControllers();

// ========================================
// 🔹 4. Add Swagger for API Documentation
// ========================================
// Swagger helps test APIs visually without using Postman
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ========================================
// 🔹 5. Use Middleware (OOP - Encapsulation)
// ========================================
// Middleware are small building blocks in the request pipeline
// You can log requests, handle errors, authenticate users, etc.
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

// ========================================
// 🔹 6. Enable Swagger UI (Development Tool)
// ========================================
// Swagger UI provides a web page to test your APIs
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // ✅ This line must be inside the Development check
}

// ========================================
// 🔹 7. Map Controllers and Run the App
// ========================================
app.MapControllers();
app.Run();
