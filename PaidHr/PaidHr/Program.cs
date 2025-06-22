
using Microsoft.EntityFrameworkCore;
using PaidHr.Data.Entities;
using PaidHr.Interfaces;
using PaidHr.Repository;
using PaidHr.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PidHrDb"));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPayrollService, PayrollService>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddScoped<ILeaveManagementService, LeaveManagementService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

SeedData(app.Services.CreateScope().ServiceProvider);

app.MapControllers();
app.Run();

static void SeedData(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Example seed Employee
    if (!db.Employees.Any())
    {
        var employee = new Employee
        {
            FirstName = "John Doe",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            PhoneNumber = "088888888",
            DateCreated = DateTime.UtcNow.AddYears(-2),
            Role = "Developer",
            BankAccount = new BankAccount
            {
                BankName = "Demo Bank",
                AccountNumber = "123456789",
                AccountType = "Current"
            }
        };
        db.Employees.Add(employee);
        db.SaveChanges();
        // Dummy payroll processing
        var payroll = new Payroll
        {
            EmployeeId = employee.Id,
            DateCreated = DateTime.UtcNow,
            IsProcessed = true,
            Salary = new Salary
            {
                BaseSalary = 5000,
                Bonus = 500,
                Deductions = 200,
                NetPay = 5300,
                SalaryStatus = "Paid",
                DatePaid = DateTime.Now
            }
        };
        db.Payrolls.Add(payroll);
        db.SaveChanges();
    }
}