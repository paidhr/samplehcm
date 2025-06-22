using Microsoft.EntityFrameworkCore;
using PaidHr.Data.DTOs.Request;
using PaidHr.Data.Entities;
using PaidHr.Interfaces;
using PaidHr.Repository;

namespace PaidHr.Services;

public class EmployeeService: IEmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> CreateAsync(EmployeeDto employeedto)
    {
        var employee = new Employee()
        {
            FirstName = employeedto.FirstName,
            LastName = employeedto.LastName,
            Email = employeedto.Email,
            PhoneNumber = employeedto.PhoneNumber,
            Role = employeedto.Role,
            DateCreated = DateTime.Now,
            BankAccount = new BankAccount()
            {
                BankName = employeedto.BankName,
                AccountNumber = employeedto.BankAccountNumber,
                AccountType = employeedto.AcccountType
            }
        };
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task DeleteAsync(int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Employee> GetByIdAsync(int employeeId)
    {
        return await _context.Employees
            .Include(e => e.Payrolls)
            .Include(e => e.LeaveRequests)
            .Include(e => e.BankAccount)
            .FirstOrDefaultAsync(e => e.Id == employeeId);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .Include(e => e.Payrolls)
            .Include(e => e.LeaveRequests)
            .Include(e => e.BankAccount)
            .ToListAsync();
    }
}