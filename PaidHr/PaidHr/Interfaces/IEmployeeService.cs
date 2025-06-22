using PaidHr.Data.DTOs.Request;
using PaidHr.Data.Entities;

namespace PaidHr.Interfaces;

public interface IEmployeeService
{
    Task<Employee> CreateAsync(EmployeeDto employee);
    Task<Employee> UpdateAsync(Employee employee);
    Task DeleteAsync(int employeeId);
    Task<Employee> GetByIdAsync(int employeeId);
    Task<IEnumerable<Employee>> GetAllAsync();
}