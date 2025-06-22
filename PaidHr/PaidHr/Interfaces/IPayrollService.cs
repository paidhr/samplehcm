using PaidHr.Data.Entities;

namespace PaidHr.Interfaces;

public interface IPayrollService
{
    Task<Payroll> ProcessPayrollAsync(int employeeId);
    Task<decimal> CalculateNetPayAsync(int payrollId);
    Task GeneratePayslipAsync(int payrollId);

}