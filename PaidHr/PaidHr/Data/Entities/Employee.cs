namespace PaidHr.Data.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public ICollection<Payroll> Payrolls { get; set; }

    public ICollection<LeaveRequest> LeaveRequests { get; set; }
    public BankAccount BankAccount { get; set; }
    public DateTime DateCreated { get; set; }
    
}