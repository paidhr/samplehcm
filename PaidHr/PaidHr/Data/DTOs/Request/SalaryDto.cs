namespace PaidHr.Data.DTOs.Request;

public class SalaryDto
{
    public string SalaryStatus { get; set; }
    public DateTime DatePaid { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deductions { get; set; }
    public decimal NetPay { get; set; }
}