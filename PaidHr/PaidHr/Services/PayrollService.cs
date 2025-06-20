using Microsoft.EntityFrameworkCore;
using PaidHr.Data.Entities;
using PaidHr.Interfaces;
using PaidHr.Repository;


namespace PaidHr.Services;

public class PayrollService: IPayrollService
{
    private readonly AppDbContext _context;

    public PayrollService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Payroll> ProcessPayrollAsync(int employeeId)
    {
        // Dummy payroll processing
        var payroll = new Payroll
        {
            EmployeeId = employeeId,
            DateCreated = DateTime.UtcNow.AddDays(-14),
            IsProcessed = true,
            Salary = new Salary
            {
                BaseSalary = 5000,
                Bonus = 500,
                Deductions = 200,
                NetPay = 5300,
                SalaryStatus = "Paid"
            }
        };

        _context.Payrolls.Add(payroll);
        await _context.SaveChangesAsync();

        return payroll;
    }

    public async Task<decimal> CalculateNetPayAsync(int payrollId)
    {
        var payroll = await _context.Payrolls
            .Include(p => p.Salary)
            .FirstOrDefaultAsync(p => p.Id == payrollId);

        return payroll?.Salary?.NetPay ?? 0;
    }

    public async Task GeneratePayslipAsync(int payrollId)
    {
        // Dummy implementation, this should generate PDF or HTML
        var payroll = await _context.Payrolls.FindAsync(payrollId);
        if (payroll != null)
        {
            payroll.IsProcessed = true;
            await _context.SaveChangesAsync();
        }
    }
}
