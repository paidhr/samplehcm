namespace PaidHr.Data.Entities;

public class BankAccount
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string BankName { get; set; }
    public string AccountType { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}