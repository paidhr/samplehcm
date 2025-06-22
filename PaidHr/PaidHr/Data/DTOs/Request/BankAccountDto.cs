namespace PaidHr.Data.DTOs.Request;

public class BankAccountDto
{
    public string AccountNumber { get; set; }
    public string BankName { get; set; }
    public string AccountType { get; set; }
    public int EmployeeId { get; set; } 
}