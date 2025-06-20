namespace PaidHr.Data.Entities;

public class Tax
{
    public int Id { get; set; }
    public string TaxType { get; set; }
    public decimal TaxRate { get; set; }
    public int PayrollId { get; set; }
    public Payroll Payroll { get; set; }}