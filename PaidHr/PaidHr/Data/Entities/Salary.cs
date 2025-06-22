namespace PaidHr.Data.Entities;

public class Salary
{
    public int Id { get; set; }
    public string SalaryStatus { get; set; }
    public DateTime DatePaid { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deductions { get; set; }
    public decimal NetPay { get; set; }
    public int PayrollId { get; set; }
    public Payroll Payroll { get; set; }
}